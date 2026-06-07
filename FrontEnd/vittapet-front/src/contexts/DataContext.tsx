import React, { createContext, useState, useContext, useCallback, useEffect } from 'react';
import { Owner, Pet, Appointment, Vet, MedicalRecord } from '../types';
import { NotificationContext } from './NotificationContext';

interface DataContextType {
  vets: Vet[];
  owners: Owner[];
  pets: Pet[];
  appointments: Appointment[];
  medicalRecords: MedicalRecord[];
  setOwners: React.Dispatch<React.SetStateAction<Owner[]>>;
  setVets: React.Dispatch<React.SetStateAction<Vet[]>>;
  addOwner: (owner: Omit<Owner, 'id'>) => Promise<void>;
  addPet: (pet: Omit<Pet, 'id'>) => Promise<void>;
  updatePet: (petId: string, name: string, weightKg: number, isActive: boolean) => Promise<void>;
  deletePet: (petId: string) => Promise<void>;
  addAppointment: (app: Omit<Appointment, 'id' | 'status'>) => Promise<void>;
  updateAppointmentStatus: (id: string, status: Appointment['status']) => Promise<boolean>;
  deleteAppointment: (id: string) => Promise<void>;
  addMedicalRecord: (record: Omit<MedicalRecord, 'id' | 'recordedAt'>) => Promise<boolean>;
  updateOwnerProfile: (ownerId: string, email: string, phone: string, password?: string) => Promise<void>;
  updateVetProfile: (vetId: string, email: string, password?: string, specialties?: string[]) => Promise<void>;
  loadAllData: () => Promise<void>;
  loadVets: () => Promise<void>;
  loadOwners: () => Promise<void>;
  loadPets: (ownerId?: string) => Promise<void>;
  loadAppointments: () => Promise<void>;
  loadMedicalRecords: () => Promise<void>;
  loadOwnerById: (id: string) => Promise<void>;
  loadVetById: (id: string) => Promise<void>;
}

export const DataContext = createContext<DataContextType | undefined>(undefined);

const REG_API_URL = 'https://localhost:7204';
const APPT_API_URL = 'https://localhost:7221';

const mapSpeciesIdToString = (id: number): string => {
  switch (id) {
    case 0: return 'Cão';
    case 1: return 'Gato';
    case 2: return 'Ave';
    case 3: return 'Peixe';
    case 4: return 'Exótico';
    default: return 'Cão';
  }
};

const mapSpeciesStringToId = (str: string): number => {
  const normalized = (str || '').toLowerCase();
  if (normalized.includes('cã') || normalized.includes('cao') || normalized.includes('dog') || normalized.includes('cachor')) return 0;
  if (normalized.includes('gat') || normalized.includes('cat')) return 1;
  if (normalized.includes('av') || normalized.includes('passar') || normalized.includes('bird')) return 2;
  if (normalized.includes('peix') || normalized.includes('fish')) return 3;
  return 4; // Exótico
};

const mapStatusIdToString = (statusId: number): Appointment['status'] => {
  switch (statusId) {
    case 0: return 'Pendente';      // Scheduled
    case 1: return 'Em Andamento';  // InProgress
    case 2: return 'Concluído';     // Completed
    case 3: return 'Cancelado';     // Cancelled
    default: return 'Pendente';
  }
};

const calculateAge = (birthDateString: string | null): number => {
  if (!birthDateString) return 0;
  const parts = birthDateString.split('T')[0].split('-');
  if (parts.length !== 3) return 0;
  const year = parseInt(parts[0], 10);
  const month = parseInt(parts[1], 10) - 1; // 0-indexed
  const day = parseInt(parts[2], 10);

  const birthDate = new Date(year, month, day);
  const today = new Date();
  let age = today.getFullYear() - birthDate.getFullYear();
  const m = today.getMonth() - birthDate.getMonth();
  if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
    age--;
  }
  return age >= 0 ? age : 0;
};

export function DataProvider({ children }: { children: React.ReactNode }) {
  const notifCtx = useContext(NotificationContext);
  const showNotification = notifCtx?.showNotification ?? (() => {});

  const [vets, setVets] = useState<Vet[]>([]);
  const [owners, setOwners] = useState<Owner[]>([]);
  const [pets, setPets] = useState<Pet[]>([]);
  const [appointments, setAppointments] = useState<Appointment[]>([]);
  const [medicalRecords, setMedicalRecords] = useState<MedicalRecord[]>([]);

  const loadVets = useCallback(async () => {
    try {
      const vetsRes = await fetch(`${APPT_API_URL}/GetAllVeterinarian`);
      if (vetsRes.ok) {
        const data = await vetsRes.json();
        setVets(data.map((v: any) => ({
          id: v.id,
          name: v.fullName,
          specialty: v.specialties && v.specialties.length > 0 ? v.specialties.join(', ') : 'Clínica Geral',
          email: v.email,
          crmv: v.crmv ?? v.Crmv ?? '00000',
        })));
      }
    } catch (error) {
      console.error('Erro ao carregar veterinários:', error);
    }
  }, []);

  const loadOwners = useCallback(async () => {
    try {
      const ownersRes = await fetch(`${REG_API_URL}/GetAllOwner`);
      if (ownersRes.ok) {
        const data = await ownersRes.json();
        setOwners(data.map((o: any) => ({
          id: o.id,
          name: o.fullName,
          cpf: o.cpf,
          email: o.email,
          phone: o.phone,
        })));
      }
    } catch (error) {
      console.error('Erro ao carregar donos:', error);
    }
  }, []);

  const loadPets = useCallback(async (ownerId?: string) => {
    try {
      const url = ownerId ? `${REG_API_URL}/GetPetsByOwner/${ownerId}` : `${REG_API_URL}/GetAllPet`;
      const petsRes = await fetch(url);
      if (petsRes.ok) {
        const data = await petsRes.json();
        setPets(data.map((p: any) => ({
          id: p.id,
          ownerId: p.ownerId,
          name: p.name,
          species: mapSpeciesIdToString(p.species),
          breed: p.breed,
          birthDate: p.birthDate ? p.birthDate.split('T')[0] : '',
          weightKg: p.weightKg,
          isActive: p.isActive,
          age: calculateAge(p.birthDate),
        })));
      }
    } catch (error) {
      console.error('Erro ao carregar pets:', error);
    }
  }, []);

  const loadAppointments = useCallback(async () => {
    try {
      const apptsRes = await fetch(`${APPT_API_URL}/GetAllAppointment`);
      if (apptsRes.ok) {
        const data = await apptsRes.json();
        setAppointments(data.map((a: any) => {
          let dateString = '';
          let timeString = '';
          
          if (a.scheduledStart) {
            const normalized = (a.scheduledStart.endsWith('Z') || a.scheduledStart.includes('+') || a.scheduledStart.match(/-\d{2}:\d{2}$/))
              ? a.scheduledStart
              : `${a.scheduledStart}Z`;
            
            const localDate = new Date(normalized);
            
            const year = localDate.getFullYear();
            const month = String(localDate.getMonth() + 1).padStart(2, '0');
            const day = String(localDate.getDate()).padStart(2, '0');
            dateString = `${year}-${month}-${day}`;
            
            const hours = String(localDate.getHours()).padStart(2, '0');
            const minutes = String(localDate.getMinutes()).padStart(2, '0');
            timeString = `${hours}:${minutes}`;
          }

          return {
            id: a.id,
            petId: a.petId,
            vetId: a.veterinarianId,
            date: dateString,
            time: timeString,
            reason: a.reason,
            status: mapStatusIdToString(a.status),
            notes: a.notes,
          };
        }));
      }
    } catch (error) {
      console.error('Erro ao carregar consultas:', error);
    }
  }, []);

  const loadMedicalRecords = useCallback(async () => {
    try {
      const mrRes = await fetch(`${APPT_API_URL}/GetAllMedicalRecord`);
      if (mrRes.ok) {
        const data = await mrRes.json();
        setMedicalRecords(data.map((m: any) => {
          const id = m.id ?? m.Id;
          const appointmentId = m.appointmentId ?? m.AppointmentId;
          const diagnosis = m.diagnosis ?? m.Diagnosis;
          const treatment = m.treatment ?? m.Treatment;
          const prescriptions = m.prescriptions ?? m.Prescriptions ?? [];
          const followUpDate = m.followUpDate ?? m.FollowUpDate;
          const recordedAt = m.recordedAt ?? m.RecordedAt;
          return {
            id,
            appointmentId,
            diagnosis,
            treatment,
            prescriptions: prescriptions || [],
            followUpDate: followUpDate ? followUpDate.split('T')[0] : undefined,
            recordedAt,
          };
        }));
      }
    } catch (error) {
      console.error('Erro ao carregar prontuários:', error);
    }
  }, []);

  const loadOwnerById = useCallback(async (id: string) => {
    try {
      const res = await fetch(`${REG_API_URL}/GetOwner/${id}`);
      if (res.ok) {
        const o = await res.json();
        const mappedOwner = {
          id: o.id,
          name: o.fullName,
          cpf: o.cpf,
          email: o.email,
          phone: o.phone,
        };
        setOwners(prev => {
          const filtered = prev.filter(x => x.id !== id);
          return [...filtered, mappedOwner];
        });
      }
    } catch (error) {
      console.error('Erro ao carregar dono por ID:', error);
    }
  }, []);

  const loadVetById = useCallback(async (id: string) => {
    try {
      const res = await fetch(`${APPT_API_URL}/GetVeterinarian/${id}`);
      if (res.ok) {
        const v = await res.json();
        const mappedVet = {
          id: v.id,
          name: v.fullName,
          specialty: v.specialties && v.specialties.length > 0 ? v.specialties.join(', ') : 'Clínica Geral',
          email: v.email,
          crmv: v.crmv ?? v.Crmv ?? '00000',
        };
        setVets(prev => {
          const filtered = prev.filter(x => x.id !== id);
          return [...filtered, mappedVet];
        });
      }
    } catch (error) {
      console.error('Erro ao carregar veterinário por ID:', error);
    }
  }, []);

  const loadAllData = useCallback(async () => {
    await Promise.all([
      loadVets(),
      loadOwners(),
      loadPets(),
      loadAppointments(),
      loadMedicalRecords(),
    ]);
  }, [loadVets, loadOwners, loadPets, loadAppointments, loadMedicalRecords]);

  const addOwner = useCallback(async (owner: Omit<Owner, 'id'>) => {
    try {
      const res = await fetch(`${REG_API_URL}/CreateOwner`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          fullName: owner.name,
          cpf: owner.cpf,
          email: owner.email,
          password: owner.password || '12345678',
          phone: owner.phone,
        }),
      });

      if (res.ok) {
        showNotification('Dono cadastrado com sucesso!');
        await loadOwners();
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao cadastrar dono.', 'error');
      }
    } catch (error) {
      showNotification('Erro de rede ao cadastrar dono.', 'error');
    }
  }, [loadOwners, showNotification]);

  const addPet = useCallback(async (pet: Omit<Pet, 'id'>) => {
    try {
      const birthDateIso = pet.birthDate ? new Date(pet.birthDate).toISOString() : new Date().toISOString();
      const res = await fetch(`${REG_API_URL}/CreatePet`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          ownerId: pet.ownerId,
          name: pet.name,
          species: mapSpeciesStringToId(pet.species),
          breed: pet.breed || 'Vira-lata',
          birthDate: birthDateIso,
          weightKg: pet.weightKg !== undefined ? Number(pet.weightKg) : 0,
          isActive: pet.isActive !== undefined ? pet.isActive : true,
        }),
      });

      if (res.ok) {
        showNotification('Pet cadastrado com sucesso!');
        await loadPets();
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao cadastrar pet.', 'error');
      }
    } catch (error) {
      showNotification('Erro de rede ao cadastrar pet.', 'error');
    }
  }, [loadPets, showNotification]);

  const updatePet = useCallback(async (petId: string, name: string, weightKg: number, isActive: boolean) => {
    try {
      const res = await fetch(`${REG_API_URL}/UpdatePet/${petId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          name: name,
          weightKg: Number(weightKg),
          isActive: isActive,
        }),
      });

      if (res.ok) {
        showNotification('Pet atualizado com sucesso!');
        await loadPets();
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao atualizar pet.', 'error');
      }
    } catch (error) {
      showNotification('Erro de rede ao atualizar pet.', 'error');
    }
  }, [loadPets, showNotification]);

  const deletePet = useCallback(async (petId: string) => {
    try {
      const res = await fetch(`${REG_API_URL}/DeletePet/${petId}`, {
        method: 'DELETE',
      });

      if (res.ok) {
        showNotification('Pet removido!');
        await loadPets();
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao remover pet.', 'error');
      }
    } catch (error) {
      showNotification('Erro de rede ao remover pet.', 'error');
    }
  }, [loadPets, showNotification]);

  const addAppointment = useCallback(async (app: Omit<Appointment, 'id' | 'status'>) => {
    try {
      const pet = pets.find(p => p.id === app.petId);
      const ownerId = pet ? pet.ownerId : '';

      const scheduledStart = new Date(`${app.date}T${app.time}:00`);
      const scheduledEnd = new Date(scheduledStart.getTime() + 30 * 60 * 1000); // 30 minutos de duração

      const res = await fetch(`${APPT_API_URL}/CreateAppointment`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          petId: app.petId,
          ownerId: ownerId,
          veterinarianId: app.vetId,
          scheduledStart: scheduledStart.toISOString(),
          scheduledEnd: scheduledEnd.toISOString(),
          reason: app.reason || 'Consulta Geral',
          notes: app.notes || '',
        }),
      });

      if (res.ok) {
        showNotification('Consulta agendada!');
        await loadAppointments();
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao agendar consulta.', 'error');
      }
    } catch (error) {
      showNotification('Erro de rede ao agendar consulta.', 'error');
    }
  }, [pets, loadAppointments, showNotification]);

  const addMedicalRecord = useCallback(async (record: Omit<MedicalRecord, 'id' | 'recordedAt'>) => {
    try {
      const followUpDateIso = record.followUpDate ? new Date(record.followUpDate).toISOString() : new Date(Date.now() + 24 * 60 * 60 * 1000).toISOString(); // followUpDate deve ser posterior a recordedAt
      const res = await fetch(`${APPT_API_URL}/CreateMedicalRecord`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          diagnosis: record.diagnosis,
          treatment: record.treatment || '',
          prescriptions: record.prescriptions || [],
          appointmentId: record.appointmentId,
          followUpDate: followUpDateIso,
          recordedAt: new Date().toISOString(),
        }),
      });

      if (res.ok) {
        showNotification('Prontuário médico registrado!');
        await loadMedicalRecords();
        return true;
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao registrar prontuário médico.', 'error');
        return false;
      }
    } catch (error) {
      showNotification('Erro de rede ao registrar prontuário médico.', 'error');
      return false;
    }
  }, [loadMedicalRecords, showNotification]);

  const deleteAppointment = useCallback(async (id: string) => {
    try {
      const res = await fetch(`${APPT_API_URL}/DeleteAppointment/${id}`, {
        method: 'DELETE',
      });

      if (res.ok) {
        showNotification('Consulta cancelada!');
        await loadAppointments();
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao cancelar consulta.', 'error');
      }
    } catch (error) {
      showNotification('Erro de rede ao cancelar consulta.', 'error');
    }
  }, [loadAppointments, showNotification]);

  const updateAppointmentStatus = useCallback(async (id: string, status: Appointment['status']) => {
    try {
      let endpoint = '';
      if (status === 'Em Andamento') {
        endpoint = `${APPT_API_URL}/StartAppointment/${id}`;
      } else if (status === 'Concluído') {
        endpoint = `${APPT_API_URL}/CompleteAppointment/${id}`;
      } else if (status === 'Cancelado') {
        await deleteAppointment(id);
        return true;
      } else {
        return false;
      }

      const res = await fetch(endpoint, {
        method: 'PATCH',
      });

      if (res.ok) {
        showNotification(`Status da consulta atualizado para: ${status}`);
        await loadAppointments();
        return true;
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao atualizar status da consulta.', 'error');
        return false;
      }
    } catch (error) {
      showNotification('Erro de rede ao atualizar consulta.', 'error');
      return false;
    }
  }, [loadAppointments, showNotification, deleteAppointment]);

  const updateOwnerProfile = useCallback(async (ownerId: string, email: string, phone: string, password?: string) => {
    try {
      const res = await fetch(`${REG_API_URL}/UpdateOwner/${ownerId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          email: email,
          phone: phone,
          password: password || '',
        }),
      });

      if (res.ok) {
        showNotification('Perfil atualizado com sucesso!');
        await loadOwners();
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao atualizar perfil.', 'error');
      }
    } catch (error) {
      showNotification('Erro de rede ao atualizar perfil.', 'error');
    }
  }, [loadOwners, showNotification]);

  const updateVetProfile = useCallback(async (vetId: string, email: string, password?: string, specialties?: string[]) => {
    try {
      const res = await fetch(`${APPT_API_URL}/UpdateVeterinarian/${vetId}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({
          email: email,
          password: password || '',
          specialties: specialties || [],
        }),
      });

      if (res.ok) {
        showNotification('Perfil atualizado com sucesso!');
        await loadVets();
      } else {
        const errMsg = await res.text();
        showNotification(errMsg || 'Erro ao atualizar perfil.', 'error');
      }
    } catch (error) {
      showNotification('Erro de rede ao atualizar perfil.', 'error');
    }
  }, [loadVets, showNotification]);

  return (
    <DataContext.Provider value={{
      vets, owners, pets, appointments, medicalRecords,
      setOwners, setVets,
      addOwner, addPet, updatePet, deletePet,
      addAppointment, updateAppointmentStatus, deleteAppointment,
      addMedicalRecord,
      updateOwnerProfile, updateVetProfile,
      loadAllData,
      loadVets, loadOwners, loadPets, loadAppointments, loadMedicalRecords,
      loadOwnerById, loadVetById
    }}>
      {children}
    </DataContext.Provider>
  );
}

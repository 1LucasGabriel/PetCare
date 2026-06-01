using Registration.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class DeletePetUseCase
    {
        private readonly IPetRepository _petRepository;
        public DeletePetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public bool Run(Guid id)
        {
            var pet = _petRepository.GetById(id);

            if (pet == null)
            {
                throw new Exception("Pet not found.");
            }

            //TODO: Adicionar validação para verificar se o pet pode ser deletado (ex: não pode ser deletado se tiver consultas agendadas)

            _petRepository.Delete(id);
            return true;
        }
    }
}

# PetCare - Sistema de Consultas Veterinárias

Este é um projeto acadêmico desenvolvido para a disciplina de **Arquitetura de Software e Desenvolvimento Full Stack**. O objetivo é implementar um sistema completo com backend (API) e frontend funcional, fundamentado nos conceitos de **Domain-Driven Design (DDD)** e **Organização em Camadas**.

## 📌 Escopo do Projeto

O sistema é focado em clínicas veterinárias e está dividido em dois contextos delimitados (**Bounded Contexts**):

1. **Contexto de Cadastro (Registration)**:
   * Cadastro de Donos (Owners).
   * Cadastro de Pets associados aos seus respectivos donos.
2. **Contexto de Consultas (Appointment)**:
   * Cadastro de Veterinários.
   * Agendamento e gerenciamento de consultas (Appointments).
   * Registro de Prontuários Médicos (Medical Records) para consultas finalizadas.

---

## 🛠️ Arquitetura e Padrões de Design

O projeto segue as diretrizes do **DDD** e de **Clean Architecture**, dividindo cada microsserviço nas seguintes camadas:

```
[Cliente Frontend] 
       │ (HTTP JSON)
       ▼
┌────────────────────────────────────────────────────────┐
│                      BACKEND                           │
│                                                        │
│  [API / Controllers]                                   │
│         │                                              │
│         ▼                                              │
│  [Application / Use Cases]                             │
│         │                                              │
│         ▼                                              │
│  [Domain] (Entidades, Value Objects e Interfaces)      │
│         ▲                                              │
│         │                                              │
│  [Infrastructure] (Repositórios e Serviços Externos)   │
└────────────────────────────────────────────────────────┘
```

### Detalhes das Camadas:
* **Domain (Domínio)**: Contém o coração das regras de negócio. As validações de consistência e regras corporativas estão encapsuladas diretamente nas Entidades (`Pet.cs`, `AppointmentEntity.cs`, etc.) e em Value Objects (`CPF.cs`, `Email.cs`). Não utilizamos entidades anêmicas.
* **Application (Aplicação)**: Contém os Casos de Uso (`Use Cases`) que orquestram a execução das operações, garantindo o fluxo da informação sem expor regras diretamente na API.
* **Infrastructure (Infraestrutura)**: Implementa o acesso ao banco de dados PostgreSQL usando Entity Framework Core, além de conter os serviços de comunicação de rede.
* **API (Apresentação)**: Controllers REST que recebem requisições HTTP e retornam respostas no formato JSON para o frontend.

### 🔄 Comunicação entre Bounded Contexts (Integração Limpa)
Para manter o baixo acoplamento exigido pelo DDD:
* O contexto de **Cadastro** precisa verificar se um Pet possui consultas futuras antes de permitir a sua exclusão.
* Em vez de fazer uma consulta direta no banco de dados de outro contexto, a camada de aplicação do Cadastro utiliza a interface `IAppointmentService`.
* A infraestrutura do Cadastro implementa essa interface através do `AppointmentService.cs` realizando uma chamada HTTP REST para o endpoint `/CheckFutureAppointments/{petId}` no contexto de **Consultas**.

---

## ⚖️ Regras de Negócio Obrigatórias Implementadas

1. **Evitar duplicidade de CPF**: Validação no cadastro de donos que impede a criação caso o CPF já exista no repositório.
2. **Impedir consultas em horários conflitantes**: Validação no agendamento que garante que nem o Pet nem o Veterinário selecionado possuam outras consultas pendentes ou em andamento no mesmo intervalo de horário.
3. **Impedir exclusão de pets com consultas futuras**: O sistema barra a remoção de um animal caso haja consultas agendadas para ele no contexto de consultas.

---

## ⚙️ Tecnologias Utilizadas

### Backend (APIs)
* **Plataforma**: .NET Core 10.0
* **ORM**: Entity Framework Core
* **Banco de Dados**: PostgreSQL (banco compartilhado `petcare_db`, respeitando o isolamento lógico das tabelas por contexto)

### Frontend
* **Tecnologias**: React + TypeScript (Vite)
* **Estilização**: Vanilla CSS (CSS customizado moderno)

---

## 🚀 Como Executar o Projeto Localmente

### Pré-requisitos
* SDK do .NET 10.0+ instalado.
* Node.js (v18+) instalado.
* Banco de dados PostgreSQL ativo.

---

### Passo 1: Configurar o Banco de Dados

1. Certifique-se de que o PostgreSQL está rodando em `localhost:5432`.
2. A string de conexão padrão em ambos os projetos `appsettings.json` está configurada como:
   `Host=localhost;Port=5432;Database=petcare_db;Username=SEU_USER;Password=SUA_SENHA`
   *Caso a senha ou usuário do seu banco de dados local seja diferente, ajuste essa string nos arquivos `appsettings.json` dos projetos `Registration.API` e `Appointment.API`.*

---

### Passo 2: Executar o Backend

O backend consiste em duas APIs executadas em portas separadas:

#### Contexto de Cadastro (Porta 5290)
1. Navegue até a pasta da API de cadastro:
   ```bash
   cd Registration/Registration.API
   ```
2. Aplique as migrations do banco de dados (se necessário):
   ```bash
   dotnet ef database update
   ```
3. Execute o projeto:
   ```bash
   dotnet run
   ```

#### Contexto de Consultas (Porta 5289)
1. Abra um novo terminal e navegue até a pasta da API de consultas:
   ```bash
   cd Appointment/Appointment.API
   ```
2. Aplique as migrations do banco de dados (se necessário):
   ```bash
   dotnet ef database update
   ```
3. Execute o projeto:
   ```bash
   dotnet run
   ```

---

### Passo 3: Executar o Frontend

1. Abra um terminal na pasta do frontend:
   ```bash
   cd FrontEnd/vittapet-front
   ```
2. Instale as dependências:
   ```bash
   npm install
   ```
3. Inicie o servidor de desenvolvimento:
   ```bash
   npm run dev
   ```
4. Acesse a URL indicada no terminal (geralmente `http://localhost:5173`) no seu navegador.

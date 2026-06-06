using Registration.Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Application.UseCases
{
    public class DeleteOwnerUseCase
    {
        private readonly IOwnerRepository _ownerRepository;
        public DeleteOwnerUseCase(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        public bool Run(Guid id)
        {
            var owner = _ownerRepository.GetById(id);

            if (owner == null)
            {
                throw new Exception("Dono não encontrado.");
            }

            if (owner.Pets != null && owner.Pets.Count > 0)
            {
                throw new Exception("Não é possível deletar o dono porque há pets associados a ele.");
            }

            _ownerRepository.Delete(id);
            return true;
        }
    }
}

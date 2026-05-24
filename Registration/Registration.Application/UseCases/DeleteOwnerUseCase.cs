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
                throw new Exception("Owner not found.");
            }

            _ownerRepository.Delete(id);
            return true;
        }
    }
}

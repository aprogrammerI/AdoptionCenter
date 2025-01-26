using Domain.Domain_Models;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class PetService : IPetService
    {
        private readonly IRepository<Pet> repository;

        public PetService(IRepository<Pet> repository)
        {
            this.repository = repository;
        }

        public Pet CreateNewPet(Pet pet)
        {
            return repository.Insert(pet);
        }

        public Pet DeletePet(Guid id)
        {
            Pet pet = repository.Get(id);
            return repository.Delete(pet);
        }

        public Pet GetPetById(Guid? id)
        {
            return (Pet) repository.Get(id);
        }

        public List<Pet> GetPets()
        {
            return repository.GetAll().ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            return repository.Update(pet);
        }
    }
}

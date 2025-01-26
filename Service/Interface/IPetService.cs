using Domain.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPetService
    {
        public List<Pet> GetPets();
        public Pet GetPetById(Guid? id);
        public Pet CreateNewPet(Pet pet);
        public Pet UpdatePet(Pet pet);
        public Pet DeletePet(Guid id);
    }
}

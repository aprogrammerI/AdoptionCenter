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
    public class ShelterService : IShelterService
    {
        private readonly IRepository<Shelter> shelterRepository;
        private readonly IRepository<Pet> petRepository;

        public ShelterService(IRepository<Shelter> shelterRepository, IRepository<Pet> petRepository)
        {
            this.shelterRepository = shelterRepository;
            this.petRepository = petRepository;
        }

        public List<Shelter> GetShelters() => shelterRepository.GetAll().ToList();

        public Shelter GetShelterById(Guid? id) => shelterRepository.Get(id);

        public Shelter CreateNewShelter(Shelter shelter) => shelterRepository.Insert(shelter);

        public Shelter UpdateShelter(Shelter shelter) => shelterRepository.Update(shelter);

        public Shelter DeleteShelter(Guid id)
        {
            var shelter = shelterRepository.Get(id);
            return shelterRepository.Delete(shelter);
        }

        public List<Shelter> GetAvailableShelters()
        {
            var allShelters = shelterRepository.GetAll().ToList();
            var availableShelters = new List<Shelter>();

            foreach (var shelter in allShelters)
            {
                // Count only pets in the shelter that have not been adopted
                int petCount = petRepository.GetAll()
                                  .Count(p => p.ShelterId == shelter.Id && !p.IsAdopted);

                // Only add shelters where the pet count is less than the capacity
                if (shelter.Capacity.HasValue && petCount < shelter.Capacity.Value)
                {
                    availableShelters.Add(shelter);
                }
            }

            return availableShelters;
        }
    }
}

using Domain.Domain_Models;
using Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Implementation
{
    public class AdoptionService : IAdoptionService
    {
        private readonly IRepository<Adoption_Application> adoptionRepository;
        private readonly IRepository<Pet> petRepository;

        public AdoptionService(IRepository<Adoption_Application> adoptionRepository, IRepository<Pet> petRepository)
        {
            this.adoptionRepository = adoptionRepository;
            this.petRepository = petRepository;
        }

        
        public Adoption_Application CreateAdoptionApplication(Adoption_Application application)
        {
            // Mark the pet as adopted if it exists
            var pet = petRepository.Get(application.PetId);
            if (pet != null)
            {
                pet.IsAdopted = true;
                petRepository.Update(pet);
            }

            
            return adoptionRepository.Insert(application);
        }

     
        public Adoption_Application GetAdoptionApplicationById(Guid? id)
        {
            if (id == null)
                return null;
            return adoptionRepository.Get(id);
        }

        public List<Adoption_Application> GetAdoptionApplications()
        {
            var applications = adoptionRepository.GetAll().ToList();
            foreach (var app in applications)
            {
                if (app.Pet == null && app.PetId.HasValue)
                {
                    app.Pet = petRepository.Get(app.PetId);
                }
            }
            return applications;
        }



        /* public List<Adoption_Application> GetAdoptionApplications() =>
         adoptionRepository.GetAll().ToList();*/


        public Adoption_Application UpdateAdoptionApplication(Adoption_Application application)
        {
            return adoptionRepository.Update(application);
        }

        
        public Adoption_Application DeleteAdoptionApplication(Guid id)
        {
            var application = adoptionRepository.Get(id);
            if (application != null)
            {
                return adoptionRepository.Delete(application);
            }
            return null;
        }

     
        public bool AdoptionApplicationExists(Guid id)
        {
            return adoptionRepository.GetAll().Any(e => e.Id == id);
        }
    }
}

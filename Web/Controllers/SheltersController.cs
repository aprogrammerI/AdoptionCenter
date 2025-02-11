using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Domain.Domain_Models;
using Domain.Domain_Models.DTO;
using Service.Interface;
using Repository.Interface;
using Service.Implementation;

namespace Web.Controllers
{
    public class SheltersController : Controller
    {
        private readonly IShelterService shelterService;
        private readonly IPetService petService;

        public SheltersController(IShelterService shelterService, IPetService petService)
        {
            this.shelterService = shelterService;
            this.petService = petService;
        }



        // GET: Shelters
        public IActionResult Index()
        {
            var shelters = shelterService.GetShelters();
            return View(shelters);
        }

        // GET: Shelters/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var shelter = shelterService.GetShelterById(id);
            if (shelter == null)
                return NotFound();

            var pets = petService.GetPets()
                .Where(p => p.ShelterId == shelter.Id && !p.IsAdopted)
                        .ToList();
            // Retrieve pets in this shelter that are not adopted.
            /*var pets = petRepository.GetAll()
                        .Where(p => p.ShelterId == shelter.Id && !p.IsAdopted)
                        .ToList();*/

            var dto = new ShelterDetailsDTO
            {
                Shelter = shelter,
                Pets = pets
            };

            return View(dto);
        }

        // GET: Shelters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shelters/Create
        // Bind the desired properties. Adjust the property list as needed.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ShelterId,Name,City,Capacity,Id")] Shelter shelter)
        {
            if (ModelState.IsValid)
            {
                shelter.Id = Guid.NewGuid();
                shelterService.CreateNewShelter(shelter);
                return RedirectToAction(nameof(Index));
            }
            return View(shelter);
        }

        // GET: Shelters/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var shelter = shelterService.GetShelterById(id);
            if (shelter == null)
                return NotFound();

            return View(shelter);
        }

        // POST: Shelters/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ShelterId,Name,City,Capacity,Id")] Shelter shelter)
        {
            if (id != shelter.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    shelterService.UpdateShelter(shelter);
                }
                catch (Exception)
                {
                    if (!ShelterExists(shelter.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(shelter);
        }

        // GET: Shelters/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var shelter = shelterService.GetShelterById(id);
            if (shelter == null)
                return NotFound();

            return View(shelter);
        }

        // POST: Shelters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            //shelterService.DeleteShelter(id);
            //return RedirectToAction(nameof(Index));

            var shelter = shelterService.GetShelterById(id);
            if (shelter != null)
            {
                // Get all pets in this shelter that are not adopted
                var petsInShelter = petService.GetPets()
                    .Where(p => p.ShelterId == id && !p.IsAdopted)
                    .ToList();

                // Remove them from availability
                foreach (var pet in petsInShelter)
                {
                    petService.DeletePet(pet.Id);
                }

                // Delete the shelter
                shelterService.DeleteShelter(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ShelterExists(Guid id)
        {
            var shelters = shelterService.GetShelters();
            return shelters.Any(e => e.Id == id);
        }
    }
}

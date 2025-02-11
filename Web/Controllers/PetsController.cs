using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.Domain_Models;
using Repository;
using Service.Interface;
using Domain.Domain_Models.DTO;
using Humanizer;

namespace Web.Controllers
{
    public class PetsController : Controller
    {
        private readonly IPetService petService;
        private readonly IShelterService shelterService;

        public PetsController(IPetService petService, IShelterService shelterService)
        {
            this.petService = petService;
            this.shelterService = shelterService;
        }

        // GET: Pets
        public IActionResult Index()
        {
            var pets = petService.GetPets().Where(p => !p.IsAdopted).ToList();
            return View(pets);
        }

        // GET: Pets/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // GET: Pets/Create
        public IActionResult Create()
        {
            var dto = new CreatePetDTO
            {
                Pet = new Pet(), // Create a base Pet
                Shelters = shelterService.GetAvailableShelters()
            };
            return View(dto);
        }

        // POST: Pets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePetDTO dto)
        {
            if (ModelState.IsValid)
            {
                
                dto.Pet.Shelter = shelterService.GetShelterById(dto.Pet.ShelterId);

                
                petService.CreateNewPet(dto.Pet);

                return RedirectToAction("Index"); 
            }

            dto.Shelters = shelterService.GetAvailableShelters();
            return View(dto);
        }

       

        // GET: Pets/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }
            return View(pet);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Breed,Age,Sex,Description,IsVacinated,imageUrl,Id")] Pet pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    petService.UpdatePet(pet);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetExists(pet.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pet);
        }

        // GET: Pets/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pet = petService.GetPetById(id);
            if (pet == null)
            {
                return NotFound();
            }

            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var pet = petService.GetPetById(id);
            if (pet != null)
            {
                petService.DeletePet(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool PetExists(Guid id)
        {
            return petService.GetPets().Any(e => e.Id == id);
        }
    }
}

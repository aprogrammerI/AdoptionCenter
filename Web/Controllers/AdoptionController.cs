using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Domain.Domain_Models;
using Domain.Domain_Models.DTO;
using Service.Interface;  // Contains IAdoptionService and IPetService
using Microsoft.EntityFrameworkCore;  // for DbUpdateConcurrencyException if needed

namespace Web.Controllers
{
    public class AdoptionController : Controller
    {
        private readonly IAdoptionService adoptionService;
        private readonly IPetService petService;

        public AdoptionController(IAdoptionService adoptionService, IPetService petService)
        {
            this.adoptionService = adoptionService;
            this.petService = petService;
        }

        // GET: Adoption
        public IActionResult Index()
        {
            var applications = adoptionService.GetAdoptionApplications().ToList();
            return View(applications);
        }

        // GET: Adoption/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var application = adoptionService.GetAdoptionApplicationById(id);
            if (application == null)
                return NotFound();

            return View(application);
        }

        // GET: Adoption/Create
        public IActionResult Create()
        {
            var dto = new AdoptionDTO
            {
                AdoptionApplication = new Adoption_Application(),
                // Only include pets that are not adopted
                AvailablePets = petService.GetPets().Where(p => !p.IsAdopted).ToList(),
            };
            return View(dto);
        }

        // POST: Adoption/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdoptionDTO dto)
        {
            if (!ModelState.IsValid)
            {
                // Log any model state errors if needed
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                // Re-populate with only available (not adopted) pets
                dto.AvailablePets = petService.GetPets().Where(p => !p.IsAdopted).ToList();
                return View(dto);
            }

            dto.AdoptionApplication.Id = Guid.NewGuid();
            adoptionService.CreateAdoptionApplication(dto.AdoptionApplication);
            return RedirectToAction(nameof(Index));
        }

        // GET: Adoption/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var application = adoptionService.GetAdoptionApplicationById(id);
            if (application == null)
                return NotFound();

            var dto = new AdoptionDTO
            {
                AdoptionApplication = application,
                AvailablePets = petService.GetPets().ToList(),
            };
            return View(dto);
        }

        // POST: Adoption/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, AdoptionDTO dto)
        {
            if (id != dto.AdoptionApplication.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    adoptionService.UpdateAdoptionApplication(dto.AdoptionApplication);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!adoptionService.AdoptionApplicationExists(dto.AdoptionApplication.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            dto.AvailablePets = petService.GetPets().ToList();
            return View(dto);
        }

        // GET: Adoption/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var application = adoptionService.GetAdoptionApplicationById(id);
            if (application == null)
                return NotFound();

            return View(application);
        }

        // POST: Adoption/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            adoptionService.DeleteAdoptionApplication(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

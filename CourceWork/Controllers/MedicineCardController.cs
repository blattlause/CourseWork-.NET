using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourceWork.Controllers
{
    [Authorize]
    public class MedicineCardController : Controller
    {
        private readonly IMedicineCardService _medicineCardService;
        private readonly IPetService _petService;

        public MedicineCardController(IMedicineCardService medicineCardService, IPetService petService)
        {
            _medicineCardService = medicineCardService;
            _petService = petService;
        }

        // GET: MedicineCard
        public IActionResult Index()
        {
            var medicineCardsDTO = _medicineCardService.GetAll();
            var medicineCardsViewModel = medicineCardsDTO.Select(dto => new MedicineCardViewModel
            {
                Id = dto.Id,
                IdPet = dto.IdPet,
                Pet = new PetViewModel
                {
                    Id = dto.IdPet,
                    Name = dto.Pet.Name,
                }
            }).ToList();
            return View(medicineCardsViewModel);
        }

        // GET: MedicineCard/Create
        public IActionResult Create()
        {
            var petsDTO = _petService.GetAll();

            var petOptions = string.Join(",", petsDTO.Select(pet => $"{pet.Id} - {pet.Name}"));

            ViewData["PetOptions"] = petOptions;

            return View();
        }


        // POST: MedicineCard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedicineCardViewModel model)
        {
            var medicineCardDTO = new MedicineCardDTO
            {
                IdPet = model.IdPet
            };

            _medicineCardService.Add(medicineCardDTO);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var medicineCardDTO = _medicineCardService.GetById(id.Value);
            if (medicineCardDTO is null)
            {
                return NotFound();
            }

            var petsDTO = _petService.GetAll();

            ViewData["PetOptions"] = new SelectList(_petService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Name
            }), "Value", "Text");

            var medicineCardViewModel = new MedicineCardViewModel
            {
                Id = medicineCardDTO.Id,
                IdPet = medicineCardDTO.IdPet,
                Pet = new PetViewModel
                {
                    Id = medicineCardDTO.IdPet,
                }
            };

            return View(medicineCardViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,IdPet,Pet")] MedicineCardViewModel medicineCard)
        {
            if (id != medicineCard.Id)
            {
                return NotFound();
            }

            var medicineCardDTO = new MedicineCardDTO
            {
                Id = medicineCard.Id,
                IdPet = medicineCard.IdPet
            };

            _medicineCardService.Update(medicineCardDTO);

            return RedirectToAction(nameof(Index));
        }


        // GET: MedicineCard/Delete/
        public IActionResult Delete(int id)
        {
            var medicineCardDTO = _medicineCardService.GetById(id);
            if (medicineCardDTO == null)
            {
                return NotFound();
            }

            var petDTO = _petService.GetById(medicineCardDTO.IdPet);

            var medicineCardViewModel = new MedicineCardViewModel
            {
                Id = medicineCardDTO.Id,
                IdPet = medicineCardDTO.IdPet,
                Pet = new PetViewModel
                {
                    Id = petDTO.Id,
                    Name = petDTO.Name,
                    Age = petDTO.Age,
                    Heigth = petDTO.Heigth,
                    Weigth = petDTO.Weigth,
                    IdOwner = petDTO.IdOwner,
                    IdSpecies = petDTO.IdSpecies
                }
            };

            return View(medicineCardViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medicineCard = _medicineCardService.GetById(id);
            if (medicineCard is not null)
            {
                _medicineCardService.Remove(medicineCard);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

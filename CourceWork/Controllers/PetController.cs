using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourceWork.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        private readonly IOwnerService _ownerService;
        private readonly ISpeciesService _speciesService;

        public PetController(IPetService petService, IOwnerService ownerService, ISpeciesService speciesService)
        {
            _petService = petService;
            _ownerService = ownerService;
            _speciesService = speciesService;
        }

        // GET: Pet
        public IActionResult Index()
        {
            var petsDTO = _petService.GetAll();
            var petsViewModel = petsDTO.Select(dto => new PetViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age,
                Heigth = dto.Heigth,
                IdOwner = dto.IdOwner,
                IdSpecies = dto.IdSpecies,
                Weigth = dto.Weigth,
                Owner = new OwnerViewModel
                {
                    Id = dto.IdOwner,
                    Name = dto.Owner.Name,
                },
                Species = new SpeciesViewModel
                {
                    Id = dto.IdOwner,
                    Title = dto.Species.Title,
                }
            }).ToList();
            return View(petsViewModel);
        }

        // GET: Pet/Create
        public IActionResult Create()
        {
            var ownersDTO = _ownerService.GetAll();

            var ownerOptions = string.Join(",", ownersDTO.Select(owner => $"{owner.Id} - {owner.Name}"));

            ViewData["OwnerOptions"] = ownerOptions;


            var speciesDTO = _speciesService.GetAll();

            var speciesOptions = string.Join(",", speciesDTO.Select(species => $"{species.Id} - {species.Title}"));

            ViewData["SpeciesOptions"] = speciesOptions;

            return View();
        }


        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PetViewModel model)
        {
            var petDTO = new PetDTO
            {
                Name = model.Name,
                Age = model.Age,
                Heigth = model.Heigth,
                Weigth = model.Weigth,
                IdOwner = model.IdOwner,
                IdSpecies = model.IdSpecies
            };

            _petService.Add(petDTO);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var petDTO = _petService.GetById(id.Value);
            if (petDTO is null)
            {
                return NotFound();
            }

            var ownersDTO = _ownerService.GetAll();
            var speciesDTO = _speciesService.GetAll();

            ViewData["OwnersOptions"] = new SelectList(_ownerService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Name
            }), "Value", "Text");

            ViewData["SpeciesOptions"] = new SelectList(_speciesService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Title
            }), "Value", "Text");

            var petViewModel = new PetViewModel
            {
                Id = petDTO.Id,
                Age = petDTO.Age,
                Heigth = petDTO.Heigth,
                Name = petDTO.Name,
                Weigth = petDTO.Weigth,
                IdOwner = petDTO.IdOwner,
                IdSpecies = petDTO.IdSpecies,
                Owner = new OwnerViewModel
                {
                    Id = petDTO.IdOwner,
                },
                Species = new SpeciesViewModel
                {
                    Id = petDTO.IdSpecies,
                }
            };

            return View(petViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Age,Heigth,Weigth,IdOwner,IdSpecies,Species,Owner")] PetViewModel pet)
        {
            if (id != pet.Id)
            {
                return NotFound();
            }

            var petDTO = new PetDTO
            {
                Id = pet.Id,
                Name = pet.Name,
                Age = pet.Age,
                Heigth = pet.Heigth,
                Weigth = pet.Weigth,
                IdOwner = pet.IdOwner,
                IdSpecies = pet.IdSpecies,
            };

            _petService.Update(petDTO);

            return RedirectToAction(nameof(Index));
        }


        // GET: Pet/Delete/
        public IActionResult Delete(int id)
        {
            var petDTO = _petService.GetById(id);
            if (petDTO == null)
            {
                return NotFound();
            }

            var ownerDTO = _ownerService.GetById(petDTO.IdOwner);
            var speciesDTO = _speciesService.GetById(petDTO.IdSpecies);

            var petViewModel = new PetViewModel
            {
                Id = petDTO.Id,
                Age = petDTO.Age, 
                Heigth = petDTO.Heigth,
                Weigth = petDTO.Weigth, 
                IdSpecies = petDTO.IdSpecies,
                IdOwner = petDTO.IdOwner,
                Owner = new OwnerViewModel
                {
                    Id = ownerDTO.Id,
                    Name = ownerDTO.Name,
                    Adress = ownerDTO.Adress,
                    IdUser = ownerDTO.IdUser,
                },
                Species = new SpeciesViewModel
                {
                    Id = speciesDTO.Id,
                    Title = speciesDTO.Title,
                }
            };

            return View(petViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var pet = _petService.GetById(id);
            if (pet is not null)
            {
                _petService.Remove(pet);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

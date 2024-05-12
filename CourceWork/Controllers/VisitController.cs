using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourceWork.Controllers
{
    public class VisitController : Controller
    {
        private readonly IVisitService _visitService;
        private readonly IPetService _petService;
        private readonly IVetService _vetService;

        public VisitController(IVisitService visitService, IPetService petService, IVetService vetService)
        {
            _visitService = visitService;
            _petService = petService;
            _vetService = vetService;
        }

        // GET: Visit
        public IActionResult Index()
        {
            var visitsDTO = _visitService.GetAll();
            var visitsViewModel = visitsDTO.Select(dto => new VisitViewModel
            {
                Id = dto.Id,
                IdPet = dto.IdPet,
                IdVet = dto.IdVet,
                Pet = new PetViewModel
                {
                    Id = dto.IdPet,
                    Name = dto.Pet.Name,
                },
                Vet = new VetViewModel
                {
                    Id = dto.IdVet,
                    Name = dto.Vet.Name,
                }
            }).ToList();
            return View(visitsViewModel);
        }

        // GET: Visit/Create
        public IActionResult Create()
        {
            var petsDTO = _petService.GetAll();

            var petOptions = string.Join(",", petsDTO.Select(pet => $"{pet.Id} - {pet.Name}"));

            ViewData["PetOptions"] = petOptions;


            var vetsDTO = _vetService.GetAll();

            var vetOptions = string.Join(",", vetsDTO.Select(vet => $"{vet.Id} - {vet.Name}"));

            ViewData["VetOptions"] = vetOptions;

            return View();
        }


        // POST: Visit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VisitViewModel model)
        {
            var visitDTO = new VisitDTO
            {
                IdPet = model.IdPet,
                IdVet = model.IdVet,
            };

            _visitService.Add(visitDTO);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var visitDTO = _visitService.GetById(id.Value);
            if (visitDTO is null)
            {
                return NotFound();
            }

            var petsDTO = _petService.GetAll();

            ViewData["PetOptions"] = new SelectList(_petService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Name
            }), "Value", "Text");

            ViewData["VetOptions"] = new SelectList(_vetService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Name
            }), "Value", "Text");

            var visitViewModel = new VisitViewModel
            {
                Id = visitDTO.Id,
                IdPet = visitDTO.IdPet,
                IdVet = visitDTO.IdVet,
                Pet = new PetViewModel
                {
                    Id = visitDTO.IdPet,
                },
                Vet = new VetViewModel
                {
                    Id = visitDTO.IdVet,
                }
            };

            return View(visitViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, IdPet, IdVet, Pet, Vet")] VisitViewModel visit)
        {
            if (id != visit.Id)
            {
                return NotFound();
            }

            var visitDTO = new VisitDTO
            {
                Id = visit.Id,
                IdPet = visit.IdPet,
                IdVet = visit.IdVet
            };

            _visitService.Update(visitDTO);

            return RedirectToAction(nameof(Index));
        }


        // GET: Visit/Delete/
        public IActionResult Delete(int id)
        {
            var visitDTO = _visitService.GetById(id);
            if (visitDTO == null)
            {
                return NotFound();
            }

            var petDTO = _petService.GetById(visitDTO.IdPet);
            var vetDTO = _vetService.GetById(visitDTO.IdVet);

            var visitViewModel = new VisitViewModel
            {
                Id = visitDTO.Id,
                IdPet = visitDTO.IdPet,
                IdVet = visitDTO.IdVet,
                Pet = new PetViewModel
                {
                    Id = petDTO.Id,
                    Name = petDTO.Name,
                    Age = petDTO.Age,
                    Heigth = petDTO.Heigth,
                    Weigth = petDTO.Weigth,
                    IdOwner = petDTO.IdOwner,
                    IdSpecies = petDTO.IdSpecies
                },
                Vet = new VetViewModel
                {
                    Id = vetDTO.Id,
                    Name = vetDTO.Name,
                    Sallary = vetDTO.Sallary,
                    IdUser = vetDTO.IdUser,
                }
            };

            return View(visitViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var visit = _visitService.GetById(id);
            if (visit is not null)
            {
                _visitService.Remove(visit);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

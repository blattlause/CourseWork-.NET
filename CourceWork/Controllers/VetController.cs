using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourceWork.Controllers
{
    [Authorize]
    public class VetController : Controller
    {
        private readonly IVetService _vetService;

        public VetController(IVetService vetService)
        {
            _vetService = vetService;
        }

        // GET: Vet
        public IActionResult Index()
        {
            var vetesDTO = _vetService.GetAll();
            var vetesViewModel = vetesDTO.Select(dto => new VetViewModel { Id = dto.Id, Name = dto.Name, Sallary = dto.Sallary }).ToList();
            return View(vetesViewModel);
        }

        // GET: Vet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VetViewModel model)
        {
            if (ModelState.IsValid)
            {
                var vetDTO = new VetDTO
                {
                    Name = model.Name,
                    Sallary = model.Sallary,

                };

                _vetService.Add(vetDTO);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var vetDTO = _vetService.GetById(id.Value);
            if (vetDTO is null)
            {
                return NotFound();
            }

            var vetViewModel = new VetViewModel
            {
                Id = vetDTO.Id,
                Name = vetDTO.Name,
                Sallary = vetDTO.Sallary,
            };

            return View(vetViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name, Sallary")] VetViewModel vet)
        {
            if (id != vet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var vetDTO = new VetDTO
                {
                    Id = vet.Id,
                    Name = vet.Name,
                    Sallary = vet.Sallary,
                };
                _vetService.Update(vetDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(vet);
        }


        // GET: Vet/Delete/
        public IActionResult Delete(int id)
        {
            var vetDTO = _vetService.GetById(id);
            if (vetDTO == null)
            {
                return NotFound();
            }

            var vetViewModel = new VetViewModel
            {
                Id = vetDTO.Id,
                Name = vetDTO.Name,
                Sallary = vetDTO.Sallary,
            };
            return View(vetViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var vet = _vetService.GetById(id);
            if (vet is not null)
            {
                _vetService.Remove(vet);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

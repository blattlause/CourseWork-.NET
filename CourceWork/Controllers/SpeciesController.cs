using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourceWork.Controllers
{
    [Authorize]
    public class SpeciesController : Controller
    {
        private readonly ISpeciesService _speciesService;

        public SpeciesController(ISpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        // GET: Species
        public IActionResult Index()
        {
            var speciesesDTO = _speciesService.GetAll();
            var speciesesViewModel = speciesesDTO.Select(dto => new SpeciesViewModel { Id = dto.Id, Title = dto.Title }).ToList();
            return View(speciesesViewModel);
        }

        // GET: Species/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Species/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SpeciesViewModel model)
        {
            if (ModelState.IsValid)
            {
                var speciesDTO = new SpeciesDTO
                {
                    Title = model.Title
                };

                _speciesService.Add(speciesDTO);

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

            var speciesDTO = _speciesService.GetById(id.Value);
            if (speciesDTO is null)
            {
                return NotFound();
            }

            var speciesViewModel = new SpeciesViewModel
            {
                Id = speciesDTO.Id,
                Title = speciesDTO.Title,
            };

            return View(speciesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title")] SpeciesViewModel species)
        {
            if (id != species.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var speciesDTO = new SpeciesDTO
                {
                    Id = species.Id,
                    Title = species.Title
                };
                _speciesService.Update(speciesDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(species);
        }


        // GET: Species/Delete/
        public IActionResult Delete(int id)
        {
            var speciesDTO = _speciesService.GetById(id);
            if (speciesDTO == null)
            {
                return NotFound();
            }

            var speciesViewModel = new SpeciesViewModel
            {
                Id = speciesDTO.Id,
                Title = speciesDTO.Title,
            };
            return View(speciesViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var species = _speciesService.GetById(id);
            if (species is not null)
            {
                _speciesService.Remove(species);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

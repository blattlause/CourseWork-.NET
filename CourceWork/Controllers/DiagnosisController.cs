using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourceWork.Controllers
{
    [Authorize]
    public class DiagnosisController : Controller
    {
        private readonly IDiagnosisService _claimService;

        public DiagnosisController(IDiagnosisService claimService)
        {
            _claimService = claimService;
        }

        // GET: Diagnosis
        public IActionResult Index()
        {
            var claimesDTO = _claimService.GetAll();
            var claimesViewModel = claimesDTO.Select(dto => new DiagnosisViewModel { Id = dto.Id, Title = dto.Title }).ToList();
            return View(claimesViewModel);
        }

        // GET: Diagnosis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Diagnosis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DiagnosisViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claimDTO = new DiagnosisDTO
                {
                    Title = model.Title,
                    
                };

                _claimService.Add(claimDTO);

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

            var claimDTO = _claimService.GetById(id.Value);
            if (claimDTO is null)
            {
                return NotFound();
            }

            var claimViewModel = new DiagnosisViewModel
            {
                Id = claimDTO.Id,
                Title = claimDTO.Title,
                
            };

            return View(claimViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title")] DiagnosisViewModel claim)
        {
            if (id != claim.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var claimDTO = new DiagnosisDTO
                {
                    Id = claim.Id,
                    Title = claim.Title,
                    
                };
                _claimService.Update(claimDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(claim);
        }


        // GET: Diagnosis/Delete/
        public IActionResult Delete(int id)
        {
            var claimDTO = _claimService.GetById(id);
            if (claimDTO == null)
            {
                return NotFound();
            }

            var claimViewModel = new DiagnosisViewModel
            {
                Id = claimDTO.Id,
                Title = claimDTO.Title,
                
            };
            return View(claimViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var claim = _claimService.GetById(id);
            if (claim is not null)
            {
                _claimService.Remove(claim);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourceWork.Controllers
{
    [Authorize]
    public class MedicineController : Controller
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        // GET: Medicine
        public IActionResult Index()
        {
            var medicineesDTO = _medicineService.GetAll();
            var medicineesViewModel = medicineesDTO.Select(dto => new MedicineViewModel { Id = dto.Id, Title = dto.Title, Description = dto.Description, Price = dto.Price }).ToList();
            return View(medicineesViewModel);
        }

        // GET: Medicine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Medicine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedicineViewModel model)
        {
            if (ModelState.IsValid)
            {
                var medicineDTO = new MedicineDTO
                {
                    Title = model.Title,
                    Description = model.Description,
                    Price = model.Price
                };

                _medicineService.Add(medicineDTO);

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

            var medicineDTO = _medicineService.GetById(id.Value);
            if (medicineDTO is null)
            {
                return NotFound();
            }

            var medicineViewModel = new MedicineViewModel
            {
                Id = medicineDTO.Id,
                Title = medicineDTO.Title,
                Description = medicineDTO.Description,
                Price = medicineDTO.Price
            };

            return View(medicineViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title, Description, Price")] MedicineViewModel medicine)
        {
            if (id != medicine.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var medicineDTO = new MedicineDTO
                {
                    Id = medicine.Id,
                    Title = medicine.Title,
                    Description = medicine.Description,
                    Price = medicine.Price
                };
                _medicineService.Update(medicineDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(medicine);
        }


        // GET: Medicine/Delete/
        public IActionResult Delete(int id)
        {
            var medicineDTO = _medicineService.GetById(id);
            if (medicineDTO == null)
            {
                return NotFound();
            }

            var medicineViewModel = new MedicineViewModel
            {
                Id = medicineDTO.Id,
                Title = medicineDTO.Title,
                Description = medicineDTO.Description,
                Price = medicineDTO.Price
            };
            return View(medicineViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var medicine = _medicineService.GetById(id);
            if (medicine is not null)
            {
                _medicineService.Remove(medicine);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
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

        private void PrepareViewModel(MedicineCardViewModel model)
        {
            var medicineCardDTO = _medicineCardService.GetById(model.IdPet);
            model.IdPet = medicineCardDTO.Id;
        }

        // GET: MedicineCard
        public IActionResult Index()
        {
            var medicineCardsDTO = _medicineCardService.GetAll();
            var medicineCardsViewModel = medicineCardsDTO.Select(dto => new MedicineCardViewModel { Id = dto.Id, IdPet = dto.IdPet }).ToList();
            return View(medicineCardsViewModel);
        }

        // GET: MedicineCard/Create
        public IActionResult Create()
        {
            // Получаем список всех питомцев
            var petsDTO = _petService.GetAll();

            // Создаем список существующих питомцев в виде id - name
            var petOptions = string.Join(",", petsDTO.Select(pet => $"{pet.Id} - {pet.Name}"));

            // Передаем строку в представление
            ViewData["PetOptions"] = petOptions;

            return View();
        }


        // POST: MedicineCard/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MedicineCardViewModel model)
        {
            if (ModelState.IsValid)
            {
                var medicineCardDTO = new MedicineCardDTO
                {
                    IdPet = model.Pet.Id // Используем Id питомца из модели PetViewModel
                };

                _medicineCardService.Add(medicineCardDTO);

                return RedirectToAction(nameof(Index));
            }

            // Если модель недействительна, необходимо снова заполнить список питомцев
            var petsDTO = _petService.GetAll();
            var petViewModels = petsDTO.Select(dto => new PetViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age,
                Heigth = dto.Heigth,
                Weigth = dto.Weigth,
                IdOwner = dto.IdOwner,
                IdSpecies = dto.IdSpecies
            }).ToList();
            ViewData["PetOptions"] = new SelectList(petViewModels, "Id", "Name", model.IdPet);

            return View(model);
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

            // Получаем список всех питомцев
            var petsDTO = _petService.GetAll();

            // Создаем список питомцев в формате id - name для использования в выпадающем списке
            var petOptions = petsDTO.Select(pet => new SelectListItem
            {
                Value = pet.Id.ToString(),
                Text = $"{pet.Id} - {pet.Name}"
            }).ToList();

            // Устанавливаем список питомцев в ViewData
            ViewData["PetOptions"] = petOptions;

            // Создаем модель представления для редактирования медицинской карты
            var medicineCardViewModel = new MedicineCardViewModel
            {
                Id = medicineCardDTO.Id,
                IdPet = medicineCardDTO.IdPet,
                Pet = new PetViewModel
                {
                    Id = medicineCardDTO.IdPet,
                    // Оставляем остальные свойства питомца неизменными
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

            if (ModelState.IsValid)
            {
                // Подготавливаем DTO на основе модели представления
                var medicineCardDTO = new MedicineCardDTO
                {
                    Id = medicineCard.Id,
                    IdPet = medicineCard.IdPet
                };

                // Обновляем медицинскую карту
                _medicineCardService.Update(medicineCardDTO);

                // Перенаправляем на страницу индекса
                return RedirectToAction(nameof(Index));
            }

            // Если модель недействительна, необходимо снова заполнить список питомцев
            ViewData["PetOptions"] = new SelectList(_petService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Name
            }), "Value", "Text", medicineCard.IdPet);

            // Возвращаем представление с моделью
            return View(medicineCard);
        }


        // GET: MedicineCard/Delete/
        public IActionResult Delete(int id)
        {
            var medicineCardDTO = _medicineCardService.GetById(id);
            if (medicineCardDTO == null)
            {
                return NotFound();
            }

            // Получаем информацию о питомце по идентификатору из MedicineCardDTO
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

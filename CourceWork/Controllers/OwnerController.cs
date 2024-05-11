using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourceWork.Controllers
{
    [Authorize]
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        // GET: Owner
        public IActionResult Index()
        {
            var owneresDTO = _ownerService.GetAll();
            var owneresViewModel = owneresDTO.Select(dto => new OwnerViewModel { Id = dto.Id, Name = dto.Name, Adress = dto.Adress, IdUser = dto.IdUser }).ToList();
            return View(owneresViewModel);
        }

        // GET: Owner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(OwnerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ownerDTO = new OwnerDTO
                {
                    Name = model.Name,
                    Adress = model.Adress,
                    IdUser = model.IdUser,
                };

                _ownerService.Add(ownerDTO);

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

            var ownerDTO = _ownerService.GetById(id.Value);
            if (ownerDTO is null)
            {
                return NotFound();
            }

            var ownerViewModel = new OwnerViewModel
            {
                Id = ownerDTO.Id,
                Name = ownerDTO.Name,
                Adress = ownerDTO.Adress,
                IdUser = ownerDTO.IdUser,
            };

            return View(ownerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name, Adress, IdUser")] OwnerViewModel owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var old_owner = _ownerService.GetById(owner.Id);
                var ownerDTO = new OwnerDTO
                {
                    Id = owner.Id,
                    Name = owner.Name,
                    Adress = owner.Adress,
                    IdUser = old_owner.IdUser,
                };
                _ownerService.Update(ownerDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(owner);
        }


        // GET: Owner/Delete/
        public IActionResult Delete(int id)
        {
            var ownerDTO = _ownerService.GetById(id);
            if (ownerDTO == null)
            {
                return NotFound();
            }

            var ownerViewModel = new OwnerViewModel
            {
                Id = ownerDTO.Id,
                Name = ownerDTO.Name,
                Adress = ownerDTO.Adress,
                IdUser = ownerDTO.IdUser,
            };
            return View(ownerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var owner = _ownerService.GetById(id);
            if (owner is not null)
            {
                _ownerService.Remove(owner);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

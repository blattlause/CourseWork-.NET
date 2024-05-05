using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourceWork.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServiceService _servicesService;

        public ServiceController(IServiceService servicesService)
        {
            _servicesService = servicesService;
        }

        // GET: Service
        public IActionResult Index()
        {
            var servicesesDTO = _servicesService.GetAll();
            var servicesesViewModel = servicesesDTO.Select(dto => new ServiceViewModel { Id = dto.Id, Title = dto.Title, Price = dto.Price }).ToList();
            return View(servicesesViewModel);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                var servicesDTO = new ServiceDTO
                {
                    Title = model.Title,
                    Price = model.Price,
                };

                _servicesService.Add(servicesDTO);

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

            var servicesDTO = _servicesService.GetById(id.Value);
            if (servicesDTO is null)
            {
                return NotFound();
            }

            var servicesViewModel = new ServiceViewModel
            {
                Id = servicesDTO.Id,
                Title = servicesDTO.Title,
                Price = servicesDTO.Price,
            };

            return View(servicesViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id, Title, Price")] ServiceViewModel services)
        {
            if (id != services.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var servicesDTO = new ServiceDTO
                {
                    Id = services.Id,
                    Title = services.Title,
                    Price = services.Price,
                };
                _servicesService.Update(servicesDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(services);
        }


        // GET: Service/Delete/
        public IActionResult Delete(int id)
        {
            var servicesDTO = _servicesService.GetById(id);
            if (servicesDTO == null)
            {
                return NotFound();
            }

            var servicesViewModel = new ServiceViewModel
            {
                Id = servicesDTO.Id,
                Title = servicesDTO.Title,
                Price = servicesDTO.Price,
            };
            return View(servicesViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var services = _servicesService.GetById(id);
            if (services is not null)
            {
                _servicesService.Remove(services);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

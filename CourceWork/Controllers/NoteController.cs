using BLL.DTO;
using BLL.Services.Interfaces;
using CourceWork.Models;
using DAL.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourceWork.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {

        private readonly INoteService _noteService;
        private readonly IMedicineCardService _medicineCardService;
        private readonly IDiagnosisService _diagnosisService;
        private readonly IClaimService _claimService;
        private readonly IVetService _vetService;
        private readonly IMedicineService _medicineService;
        private readonly IVisitService _visitService;

        public NoteController(INoteService noteService, IMedicineCardService medicineCardService, IDiagnosisService diagnosisService,
            IClaimService claimService, IVetService vetService, IMedicineService medicineService, IVisitService visitService)
        {
            _noteService = noteService;
            _claimService = claimService;
            _diagnosisService = diagnosisService;
            _visitService = visitService;
            _medicineCardService = medicineCardService;
            _vetService = vetService;
            _medicineService = medicineService;
        }

        // GET: Note
        public IActionResult Index()
        {
            var notesDTO = _noteService.GetAll();
            var notesViewModel = notesDTO.Select(dto => new NoteViewModel
            {
                Id = dto.Id,
                Date = dto.Date,
                IdClaim = dto.IdClaim,
                IdMedicine = dto.IdMedicine,
                IdDiagnosis = dto.IdDiagnosis,
                IdMedicineCard = dto.IdMedicineCard,
                IdVisit = dto.IdVisit,
                IdVet = dto.IdVet,
                Claim = new ClaimViewModel
                {
                    Id = dto.IdClaim,
                    Title = dto.Claim.Title
                },
                Medicine = new MedicineViewModel
                { 
                    Id = dto.IdMedicine,
                    Title = dto.Medicine.Title,
                    Description = dto.Medicine.Description,
                    Price = dto.Medicine.Price,
                },
                Diagnosis = new DiagnosisViewModel
                { 
                    Id = dto.IdDiagnosis,
                    Title = dto.Diagnosis.Title,
                },
                MedicineCard = new MedicineCardViewModel
                { 
                    Id = dto.MedicineCard.Id,
                    IdPet = dto.MedicineCard.Pet.Id,
                },
                Vet = new VetViewModel
                { 
                    Id = dto.IdVet,
                    Name = dto.Vet.Name,
                    Sallary = dto.Vet.Sallary,
                    IdUser = dto.Vet.IdUser,
                },
                Visit = new VisitViewModel 
                { 
                    Id = dto.IdVisit,
                    IdPet = dto.Visit.Pet.Id,
                    IdVet = dto.Visit.Vet.Id,
                }
            }).ToList();
            return View(notesViewModel);
        }

        // GET: Note/Create
        public IActionResult Create()
        {

            var claimsDTO = _claimService.GetAll();
            var diagnosisDTO = _diagnosisService.GetAll();
            var visitsDTO = _visitService.GetAll();
            var medicineCardsDTO = _medicineCardService.GetAll();
            var vetsDTO = _vetService.GetAll();
            var medicinesDTO = _medicineService.GetAll();

            ViewData["ClaimOptions"] = new SelectList(_claimService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Title
            }), "Value", "Text");

            ViewData["DiagnosisOptions"] = new SelectList(_diagnosisService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Title
            }), "Value", "Text");

            ViewData["VisitOptions"] = new SelectList(_visitService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Pet.Name
            }), "Value", "Text");

            ViewData["MedicineCardOptions"] = new SelectList(_medicineCardService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Pet.Name
            }), "Value", "Text");

            ViewData["VetOptions"] = new SelectList(_vetService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Name
            }), "Value", "Text");

            ViewData["MedicineOptions"] = new SelectList(_medicineService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Title
            }), "Value", "Text");

            return View();
        }

        // POST: Note/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NoteViewModel model)
        {
            var noteDTO = new NoteDTO
            {
                Date = model.Date,
                IdClaim = model.IdClaim,
                IdMedicine = model.IdMedicine,
                IdDiagnosis = model.IdDiagnosis,
                IdMedicineCard = model.IdMedicineCard,
                IdVisit = model.IdVisit,
                IdVet = model.IdVet,
            };

            _noteService.Add(noteDTO);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var noteDTO = _noteService.GetById(id.Value);
            if (noteDTO is null)
            {
                return NotFound();
            }

            var claimsDTO = _claimService.GetAll();
            var diagnosisDTO = _diagnosisService.GetAll();
            var visitsDTO = _visitService.GetAll();
            var medicineCardsDTO = _medicineCardService.GetAll();
            var vetsDTO = _vetService.GetAll();
            var medicinesDTO = _medicineService.GetAll();

            ViewData["ClaimOptions"] = new SelectList(_claimService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Title
            }), "Value", "Text");

            ViewData["DiagnosisOptions"] = new SelectList(_diagnosisService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Title
            }), "Value", "Text");

            ViewData["VisitOptions"] = new SelectList(_visitService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Pet.Name
            }), "Value", "Text");

            ViewData["MedicineCardOptions"] = new SelectList(_medicineCardService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Pet.Name
            }), "Value", "Text");

            ViewData["VetOptions"] = new SelectList(_vetService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Name
            }), "Value", "Text");

            ViewData["MedicineOptions"] = new SelectList(_medicineService.GetAll().Select(dto => new SelectListItem
            {
                Value = dto.Id.ToString(),
                Text = dto.Title
            }), "Value", "Text");

            var noteViewModel = new NoteViewModel
            {
                Id = noteDTO.Id,
                Date = noteDTO.Date,
                IdClaim = noteDTO.IdClaim,
                IdMedicine = noteDTO.IdMedicine,
                IdDiagnosis = noteDTO.IdDiagnosis,
                IdMedicineCard = noteDTO.IdMedicineCard,
                IdVisit = noteDTO.IdVisit,
                IdVet = noteDTO.IdVet,
                Claim = new ClaimViewModel
                {
                    Id = noteDTO.IdClaim,
                    Title = noteDTO.Claim.Title
                },
                Medicine = new MedicineViewModel
                {
                    Id = noteDTO.IdMedicine,
                    Title = noteDTO.Medicine.Title,
                    Description = noteDTO.Medicine.Description,
                    Price = noteDTO.Medicine.Price,
                },
                Diagnosis = new DiagnosisViewModel
                {
                    Id = noteDTO.IdDiagnosis,
                    Title = noteDTO.Diagnosis.Title,
                },
                MedicineCard = new MedicineCardViewModel
                {
                    Id = noteDTO.MedicineCard.Id,
                    IdPet = noteDTO.MedicineCard.Pet.Id,
                },
                Vet = new VetViewModel
                {
                    Id = noteDTO.IdVet,
                    Name = noteDTO.Vet.Name,
                    Sallary = noteDTO.Vet.Sallary,
                    IdUser = noteDTO.Vet.IdUser,
                },
                Visit = new VisitViewModel
                {
                    Id = noteDTO.IdVisit,
                    IdPet = noteDTO.Visit.Pet.Id,
                    IdVet = noteDTO.Visit.Vet.Id,
                }
            };

            return View(noteViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Date,IdClaim," +
            "IdMedicine,IdDiagnosis,IdMedicineCard," +
            "IdVisit,IdVet" +
            "Medicine,Diagnosis,MedicineCard," +
            "Claim, Visit, Vet")] NoteViewModel note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            var noteDTO = new NoteDTO
            {
                Id = note.Id,
                Date = note.Date,
                IdClaim = note.IdClaim,
                IdMedicine = note.IdMedicine,
                IdDiagnosis = note.IdDiagnosis,
                IdMedicineCard = note.IdMedicineCard,
                IdVisit = note.IdVisit,
                IdVet = note.IdVet,
            };

            _noteService.Update(noteDTO);

            return RedirectToAction(nameof(Index));
        }


        // GET: Note/Delete/
        public IActionResult Delete(int id)
        {
            var noteDTO = _noteService.GetById(id);
            if (noteDTO == null)
            {
                return NotFound();
            }

            var claimsDTO = _claimService.GetById(noteDTO.IdClaim);
            var diagnosisDTO = _diagnosisService.GetById(noteDTO.IdDiagnosis);
            var visitsDTO = _visitService.GetById(noteDTO.IdVisit);
            var medicineCardsDTO = _medicineCardService.GetById(noteDTO.IdMedicine);
            var vetsDTO = _vetService.GetById(noteDTO.IdVet);
            var medicinesDTO = _medicineService.GetById(noteDTO.IdMedicine);

            var noteViewModel = new NoteViewModel
            {
                Id = noteDTO.Id,
                Date = noteDTO.Date,
                Claim = new ClaimViewModel
                {
                    Id = noteDTO.IdClaim,
                    Title = noteDTO.Claim.Title
                },
                Medicine = new MedicineViewModel
                {
                    Id = noteDTO.IdMedicine,
                    Title = noteDTO.Medicine.Title,
                    Description = noteDTO.Medicine.Description,
                    Price = noteDTO.Medicine.Price,
                },
                Diagnosis = new DiagnosisViewModel
                {
                    Id = noteDTO.IdDiagnosis,
                    Title = noteDTO.Diagnosis.Title,
                },
                MedicineCard = new MedicineCardViewModel
                {
                    Id = noteDTO.MedicineCard.Id,
                    IdPet = noteDTO.MedicineCard.Pet.Id,
                },
                Vet = new VetViewModel
                {
                    Id = noteDTO.IdVet,
                    Name = noteDTO.Vet.Name,
                    Sallary = noteDTO.Vet.Sallary,
                    IdUser = noteDTO.Vet.IdUser,
                },
                Visit = new VisitViewModel
                {
                    Id = noteDTO.IdVisit,
                    IdPet = noteDTO.Visit.Pet.Id,
                    IdVet = noteDTO.Visit.Vet.Id,
                }
            };

            return View(noteViewModel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var note = _noteService.GetById(id);
            if (note is not null)
            {
                _noteService.Remove(note);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}

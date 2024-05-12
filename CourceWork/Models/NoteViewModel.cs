using DAL.Models;

namespace CourceWork.Models
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdDiagnosis { get; set; }
        public int IdClaim { get; set; }
        public int IdVet { get; set; }
        public int IdMedicine { get; set; }
        public int IdMedicineCard { get; set; }
        public int IdVisit { get; set; }
        public  MedicineCardViewModel MedicineCard { get; set; }
        public DiagnosisViewModel Diagnosis { get; set; }
        public ClaimViewModel Claim { get; set; }
        public VetViewModel Vet { get; set; }
        public MedicineViewModel Medicine { get; set; }
        public VisitViewModel Visit { get; set; }
    }
}

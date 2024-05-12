using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BLL.DTO
{
    public class NoteDTO: IDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int IdDiagnosis { get; set; }
        public int IdClaim { get; set; }
        public int IdVet { get; set; }
        public int IdMedicine { get; set; }
        public int IdMedicineCard { get; set; }
        public int IdVisit { get; set; }


        public  MedicineCardDTO MedicineCard { get; set; }
        public  DiagnosisDTO Diagnosis { get; set; }
        public ClaimDTO Claim { get; set; }
        public VetDTO Vet { get; set; }
        public MedicineDTO Medicine { get; set; }
        public VisitDTO Visit { get; set; }
    }
}

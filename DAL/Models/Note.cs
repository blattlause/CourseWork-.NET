using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Note
    {
        private int id;
        private DateTime date;
        private int idDiagnosis;
        private int idClaim;
        private int idVet;
        private int idMedicine;
        private int idMedicineCard;

        public Note(int id, DateTime date, int idDiagnosis, int idClaim, int idVet, int idMedicine, int idMedicineCard)
        {
            this.id = id;
            this.date = date;
            this.idDiagnosis = idDiagnosis;
            this.idClaim = idClaim;
            this.idVet = idVet;
            this.idMedicine = idMedicine;
            this.idMedicineCard = idMedicineCard;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public int IdDiagnosis { get => idDiagnosis; set => idDiagnosis = value; }
        public int IdClaim { get => idClaim; set => idClaim = value; }
        public int IdVet { get => idVet; set => idVet = value; }
        public int IdMedicine { get => idMedicine; set => idMedicine = value; }

        public int IdMedicineCard { get => idMedicineCard; set => idMedicineCard = value; }

        public virtual MedicineCard MedicineCard { get; set; }
        public virtual Diagnosis Diagnosis { get; set; }
        public virtual Claim Claim { get; set; }
        public virtual Vet Vet { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}

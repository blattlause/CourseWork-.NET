using DAL.Models;

namespace CourceWork.Models
{
    public class VisitViewModel
    {
        public int Id { get; set; }
        public int IdVet { get; set; }
        public int IdPet { get; set; }

        public PetViewModel Pet { get; set; }
        public VetViewModel Vet { get; set; }
        //public ICollection<ServiceVisitViewModel> ServiceVisities { get; set; }
        //public ICollection<NoteViewModel> Notes { get; set; }
    }
}

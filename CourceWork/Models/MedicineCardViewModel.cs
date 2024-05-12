using BLL.DTO;

namespace CourceWork.Models
{
    public class MedicineCardViewModel
    {
        public int Id { get; set; }
        public int IdPet { get; set; }
        public PetViewModel Pet { get; set; }
        public ICollection<NoteViewModel> Notes { get; set; }
    }
}

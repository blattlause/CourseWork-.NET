
using BLL.DTO;

namespace CourceWork.Models
{
    public class OwnerViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Adress { get; set; }
        public string? IdUser { get; set; }

        public  ICollection<PetViewModel> Pets { get; set; }
        //public  ICollection<ReceptionViewModel> Receptions { get; set; }
    }
}

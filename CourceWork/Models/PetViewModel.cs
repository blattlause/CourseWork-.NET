using System.ComponentModel.DataAnnotations;

namespace CourceWork.Models
{
    public class PetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int IdOwner { get; set; }
        public OwnerViewModel Owner { get; set; }
        public int IdSpecies { get; set; }
        public SpeciesViewModel Species { get; set; }
        public double Weigth { get; set; }
        public double Heigth { get; set; }
    }
}

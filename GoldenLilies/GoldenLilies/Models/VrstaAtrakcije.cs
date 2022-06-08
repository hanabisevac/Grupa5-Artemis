using System.ComponentModel.DataAnnotations;

namespace GoldenLilies.Models
{
    public class VrstaAtrakcije
    {
        [Key]
        private int ID { get; set; }
        private string naziv { get; set; }
        public VrstaAtrakcije() { }
    }
}

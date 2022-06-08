using System.ComponentModel.DataAnnotations;

namespace GoldenLilies.Models
{
    public class VrstaAtrakcije
    {
        [Key]
        public int ID { get; set; }
        public string naziv { get; set; }
        public VrstaAtrakcije() { }
    }
}

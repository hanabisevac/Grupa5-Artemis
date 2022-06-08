using System.ComponentModel.DataAnnotations;

namespace GoldenLilies.Models
{
    public class VrstaKorisnika
    {
        [Key]
        public int ID { get; set; }
        public string naziv { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GoldenLilies.Models
{
    public class VrstaKorisnika
    {
        [Key]
        private int ID { get; set; }
        private string naziv { get; set; }
    }
}

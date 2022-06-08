using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Posjete
    {
        [Key]
        private int ID { get; set; }
        [ForeignKey("Korisnik")]
        private int korisnikID { get; set; }
        [ForeignKey("Atrakcija")]
        private int atrakcijaID { get; set; }
        private Korisnik korisnik { get; set; }
        private Atrakcija atrakcija { get; set; }
        public Posjete() { }
    }
}

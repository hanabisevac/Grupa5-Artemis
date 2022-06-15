using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Prijavljeni
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Korisnik")]
        [Display(Name ="Korisnik")]
        public int korisnikID { get; set; }
        [ForeignKey("Tura")]
        [Display(Name ="Tura")]
        public int turaID { get; set; }

        public Tura tura { get; set; }
        public Korisnik korisnik { get; set; }
        public Prijavljeni() { }

    }
}

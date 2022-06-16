using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Fotografija
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Fotografija")]
        public string putanja { get; set; }
        [ForeignKey("Korisnik")]
        [DisplayName("Korisnik")]
        public int korisnikID { get; set; }
        [ForeignKey("Atrakcija")]
        [DisplayName("Atrakcija")]
        public int atrakcijaID { get; set; }
        public bool verifikovano { get; set; }

        public Korisnik korisnik { get; set; }
        public Atrakcija atrakcija { get; set; }

        public Fotografija() { }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        [ForeignKey("Lokacija")]
        public string adresaID { get; set; }
        public Lokacija lokacija { get; set; }
        public string telefon { get; set; }
        [ForeignKey("VrstaKorisnika")]
        public int aspNetUsersID { get; set; }
        public VrstaKorisnika vrstaKorisnika { get; set; }
        public Korisnik() { }
    }
}

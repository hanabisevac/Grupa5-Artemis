using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Korisnik
    {
        [Key]
        private int ID { get; set; }
        private string ime { get; set; }
        private string prezime { get; set; }
        private string email { get; set; }
        private string password { get; set; }
        [ForeignKey("Lokacija")]
        private string adresaID { get; set; }
        private Lokacija lokacija { get; set; }
        private string telefon { get; set; }
        [ForeignKey("VrstaKorisnika")]
        private int aspNetUsersID { get; set; }
        private VrstaKorisnika vrstaKorisnika { get; set; }
        public Korisnik() { }
    }
}

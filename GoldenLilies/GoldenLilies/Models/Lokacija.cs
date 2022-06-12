using System.ComponentModel.DataAnnotations;

namespace GoldenLilies.Models
{
    public class Lokacija
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Adresa")]
        public string naziv { get; set; }
        [Display(Name ="Grad")]
        public string grad { get; set; }
        [Display(Name ="Drzava")]
        public string drzava { get; set; }
        [Display(Name ="Informacije")]
        public string informacija { get; set; }
        public Lokacija() { }
    }
}

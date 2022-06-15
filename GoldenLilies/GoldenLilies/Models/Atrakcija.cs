using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    [DisplayName("Atrakcija")]
    public class Atrakcija
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Naziv atrakcije")]
        public string naziv { get; set; }
        [ForeignKey("Lokacija")]
        [Display(Name ="Lokacija")]
        public int lokacijaID { get; set; }

        [ForeignKey("VrstaAtrakcije")]
        [Display(Name = "Vrsta atrakcije")]
        public int vrstaAtrakcijeID { get; set; }
        
        [DisplayName("Osnovne informacije")]
        public string informacije { get; set; }

        [DisplayName("Radno vrijeme")]
        public DateTime radnoVrijeme { get; set; }

        [DisplayName("Lokacija")]
        public Lokacija lokacija { get; set; }

        [DisplayName("Vrsta atrakcije")]
        public VrstaAtrakcije vrstaAtrakcije { get; set; }

        public Atrakcija() { }

    }
}

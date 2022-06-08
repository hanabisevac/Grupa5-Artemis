using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Atrakcija
    {
        [Key]
        private int ID { get; set; }    
        private string naziv { get; set; }
        [ForeignKey("Lokacija")]
        private int lokacijaID { get; set; }

        [ForeignKey("VrstaAtrakcije")]
        private int vrstaAtrakcijeID { get; set; }
        private string informacije { get; set; }
        private DateTime radnoVrijeme { get; set; }
        private Lokacija lokacija { get; set; }
        private VrstaAtrakcije vrstaAtrakcije { get; set; }

        public Atrakcija() { }

    }
}

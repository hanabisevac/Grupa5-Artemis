using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Atrakcija
    {
        [Key]
        public int ID { get; set; }    
        public string naziv { get; set; }
        [ForeignKey("Lokacija")]
        public int lokacijaID { get; set; }

        [ForeignKey("VrstaAtrakcije")]
        public int vrstaAtrakcijeID { get; set; }
        public string informacije { get; set; }
        public DateTime radnoVrijeme { get; set; }
        public Lokacija lokacija { get; set; }
        public VrstaAtrakcije vrstaAtrakcije { get; set; }

        public Atrakcija() { }

    }
}

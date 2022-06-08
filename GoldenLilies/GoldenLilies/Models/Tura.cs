using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Tura
    {
        [Key]
        private int ID { get; set; }
        [ForeignKey("Korisnik")]
        private int vodicID { get; set; }
        private DateTime vrijeme { get; set; }
        private string informacije { get; set; }
        private Korisnik korisnik { get; set; }
        public Tura() { }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    [DisplayName("Tura")]
    public class Tura
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Korisnik")]
        public int vodicID { get; set; }
        public DateTime vrijeme { get; set; }
        [DisplayName("Tura")]
        public string informacije { get; set; }
        public Korisnik korisnik { get; set; }
        public Tura() { }

    }
}

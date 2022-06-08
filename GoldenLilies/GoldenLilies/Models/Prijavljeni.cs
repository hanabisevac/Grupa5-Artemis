using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class Prijavljeni
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Atrakcija")]
        public int atrakcijaID { get; set; }
        [ForeignKey("Tura")]
        public int turaID { get; set; }
        public Atrakcija atrakcija { get; set; }
        public Tura tura { get; set; }
        public Prijavljeni() { }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoldenLilies.Models
{
    public class AtrakcijeTure

    {
        [Key]
        private int ID { get; set; }
        [ForeignKey("Atrakcija")]
        private int atrakcijaID { get; set; }
        [ForeignKey("Tura")]
        private int turaID { get; set; }
        private Atrakcija atrakcija { get; set; }
        private Tura tura { get; set; }

        public AtrakcijeTure() { }
    }
}

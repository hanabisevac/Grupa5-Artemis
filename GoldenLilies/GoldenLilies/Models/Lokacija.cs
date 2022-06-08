using System.ComponentModel.DataAnnotations;

namespace GoldenLilies.Models
{
    public class Lokacija
    {
        [Key]
        private int ID { get; set; }
        private string naziv { get; set; }
        private string grad { get; set; }
        private string drzava { get; set; }
        private string informacija { get; set; }
        public Lokacija() { }
    }
}

using System.ComponentModel.DataAnnotations;

namespace GoldenLilies.Models
{
    public class Lokacija
    {
        [Key]
        public int ID { get; set; }
        public string naziv { get; set; }
        public string grad { get; set; }
        public string drzava { get; set; }
        public string informacija { get; set; }
        public Lokacija() { }
    }
}

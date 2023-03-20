using System.ComponentModel.DataAnnotations.Schema;

namespace PROJET_C.Models
{
    public class Pay
    {
        public int Id { get; set; }
        public string nom { get; set; }


        public ICollection<Population> Populations { get; set; }

        [ForeignKey("Continent")]

        public int ContinentId { get; set; }

    }
}

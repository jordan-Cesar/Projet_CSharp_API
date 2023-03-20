using System.ComponentModel.DataAnnotations.Schema;

namespace PROJET_C.Models
{
    public class Population
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public int nombre { get; set; }

        [ForeignKey("Pay")]
        public int PayId { get; set; }

    }
}

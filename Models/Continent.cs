namespace PROJET_C.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string nom { get; set; }

        public ICollection<Pay> Pays { get; set; }
    }
}

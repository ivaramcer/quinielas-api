namespace SourCooBaseProject.Models.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; } // Código ISO 3166-1 alpha-2 o alpha-3

        public ICollection<State> States { get; set; }
    }
}

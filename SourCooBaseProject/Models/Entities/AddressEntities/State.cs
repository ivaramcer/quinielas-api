namespace SourCooBaseProject.Models.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISOCode { get; set; } // Código ISO 3166-2

        public int CountryId { get; set; }
        public Country Country { get; set; }

        public List<City> Cities { get; set; }
    }
}

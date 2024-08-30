namespace QuinielasApi.Models.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }
    }
}

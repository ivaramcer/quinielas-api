namespace QuinielasApi.Utils.NFL.DTO
{
    public class GetTeamsDTO
    {
        public int? Id { get; set; } 
        public string? Name { get; set; } 
        public string? Code { get; set; } 
        public string? City { get; set; } 
        public string? Coach { get; set; }
        public string? Owner { get; set; } 
        public string? Stadium { get; set; } 
        public int? Established { get; set; } 
        public string? Logo { get; set; } 

        public CountryTeamsDTO? Country { get; set; }
    }

    public class CountryTeamsDTO
    {
        public string? Name { get; set; } // Matches "name"
        public string? Code { get; set; } // Matches "code"
        public string? Flag { get; set; } // Matches "flag"
    }
}

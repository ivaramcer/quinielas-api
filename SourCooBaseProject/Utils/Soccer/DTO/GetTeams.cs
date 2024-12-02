namespace QuinielasApi.Utils.NFL.SoccerDto
{
    public class GetTeamsSoccerDto
    {
        public TeamSoccerNew? Team { get; set; }

        // New 'Venue' object integration
        public VenueSoccerDto? Venue { get; set; }

    }

    public class TeamSoccerNew
    {
        public int? Id { get; set; } 
        public string? Name { get; set; } 
        public string? Code { get; set; } 
        public string? City { get; set; } 
        public int? Established { get; set; } 
        public bool? National { get; set; } // Reflects the "national" field in the JSON
        public string? Logo { get; set; } 
        // Removed 'Country' if not necessary, as the 'Country' field is available as a string
        public string? Country { get; set; } // Instead of a complex object, use string for Country
    }
    public class VenueSoccerDto
    {
        public int? Id { get; set; } 
        public string? Name { get; set; } 
        public string? Address { get; set; } 
        public string? City { get; set; } 
        public int? Capacity { get; set; } 
        public string? Surface { get; set; } 
        public string? Image { get; set; }
    }

}

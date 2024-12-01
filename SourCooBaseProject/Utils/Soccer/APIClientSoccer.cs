using Newtonsoft.Json;
using QuinielasApi.Utils.NFL.DTO;
using QuinielasApi.Utils.NFL.SoccerDto;

namespace QuinielasApi.Utils.Soccer
{
    public static class APIClientSoccer
    {
        public static int currentYear = DateTime.Now.Year;
        public static int league = 1;
        

        public static async Task<List<GetGamesDTO>?> GetGames(int leagueId)
        {
            List<GetGamesDTO>? games = new List<GetGamesDTO>();
            string endpoint = $"games?league={leagueId}&season={currentYear}";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(300);
                    string apiUrl = "https://v3.football.api-sports.io" +
                                    $"/{endpoint}";

                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "6aa6001bbbmsh34b868d8d330feep10fde8jsn17d51bbd6f05");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {

                        string responseBody = await response.Content.ReadAsStringAsync();
                        ApiResponseSoccer<GetGamesDTO> apiResponse = JsonConvert.DeserializeObject<ApiResponseSoccer<GetGamesDTO>>(responseBody);

                        games = apiResponse!.Response;



                    }
                    else
                    {
                        throw new ApiServiceException("The external system is not working");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return games;
        }
        public static async Task<List<GetTeamsSoccerDto>?> GetTeams()
        {
            List<GetTeamsSoccerDto>? teams = new List<GetTeamsSoccerDto>();
            string endpoint = $"teams?league={league}&season={currentYear}";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(300);
                    string apiUrl = "https://v3.football.api-sports.io" +
                                    $"/{endpoint}";

                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "6aa6001bbbmsh34b868d8d330feep10fde8jsn17d51bbd6f05");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        ApiResponseSoccer<GetTeamsSoccerDto> apiResponse = JsonConvert.DeserializeObject<ApiResponseSoccer<GetTeamsSoccerDto>>(responseBody);

                        teams = apiResponse!.Response;

                    }
                    else
                    {
                        throw new ApiServiceException("The external system is not working");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return teams;
        }

        public static async Task<List<GetCountriesDTO>?> GetCountries()
        {
            List<GetCountriesDTO>? countries = new List<GetCountriesDTO>();
            string endpoint = "countries";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(300);
                    string apiUrl = "https://v3.football.api-sports.io" +
                                    $"/{endpoint}";

                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "88a41c229f0606d7c268a4db6244b052");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "v3.football.api-sports.io");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        ApiResponseSoccerThirdVersion<GetCountriesDTO> apiResponse = JsonConvert.DeserializeObject<ApiResponseSoccerThirdVersion<GetCountriesDTO>>(responseBody);

                        countries = apiResponse!.Response;

                    }
                    else
                    {
                        throw new ApiServiceException("The external system is not working");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return countries;
        }

        public static async Task<List<LeagueInfoSoccerDto>?> GetLeagues(string country)
        {
            List<LeagueInfoSoccerDto>? teams = new List<LeagueInfoSoccerDto>();
            string endpoint = $"leagues?season={currentYear}&country={country}&current=true";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(300);
                    string apiUrl = "https://api-football-v1.p.rapidapi.com/v3" +
                                    $"/{endpoint}";

                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "6aa6001bbbmsh34b868d8d330feep10fde8jsn17d51bbd6f05");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "api-football-v1.p.rapidapi.com");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        ApiResponseSoccer<LeagueInfoSoccerDto> apiResponse = JsonConvert.DeserializeObject<ApiResponseSoccer<LeagueInfoSoccerDto>>(responseBody);

                        teams = apiResponse!.Response;

                    }
                    else
                    {
                        throw new ApiServiceException("The external system is not working");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return teams;
        }

        public class ApiServiceException : Exception
        {
            public ApiServiceException(string message) : base(message)
            {
            }
        }

        public class ApiResponseSoccer<T>
        {
            public string Get { get; set; } = default!;
    
            // Change Parameters to a dictionary to match the expected JSON structure
            public object Parameters { get; set; } = new object();

            // Use 'object' for Errors to allow any type of data
            public object Errors { get; set; } = new object();
            public int Results { get; set; }
            public Paging Paging { get; set; } = default!;
            public List<T> Response { get; set; } = new List<T>();
        }
        
        public class ApiResponseSoccerThirdVersion<T>
        {
            public string Get { get; set; } = default!;
            public object Parameters { get; set; } = new object();

            // Use 'object' for Errors to allow any type of data
            public object Errors { get; set; } = new object();
            public int Results { get; set; }
            public Paging Paging { get; set; } = default!;
            public List<T> Response { get; set; } = new List<T>();  // Ensure Response is a list of T (in your case, GetCountriesDTO)
        }



        public class Paging
        {
            public int Total { get; set; }
            public int Current { get; set; }
        }
    }
}

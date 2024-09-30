using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using QuinielasApi.Utils.NFL.DTO;

namespace QuinielasApi.Utils.NFL
{
    public static class APIClientNFL
    {
        public static int currentYear = DateTime.Now.Year;

        public static async Task<string> GetSeasons()
        {
            string responseFromNagico = "";
            string endpoint = $"teams?season={currentYear}";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(300);
                    string apiUrl = "https://v1.american-football.api-sports.io" +
                                    $"/{endpoint}";

                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "88a41c229f0606d7c268a4db6244b052");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "v1.american-football.api-sports.io");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        Dictionary<int, int>? yearMap = JsonConvert.DeserializeObject<Dictionary<int, int>>(responseBody);

                        foreach (var item in yearMap!)
                        {
                            Console.WriteLine($"ID: {item.Key}, Year: {item.Value}");
                        }
                    }
                    else
                    {
                        throw new ApiServiceException("The system from Nagico is not working");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return responseFromNagico;
        }


        public static async Task<string> GetLeagues()
        {
            string responseFromNagico = "";
            string endpoint = $"teams?league=0&season={currentYear}";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(300);
                    string apiUrl = "https://v1.american-football.api-sports.io" +
                                    $"/{endpoint}";

                    client.DefaultRequestHeaders.Add("x-rapidapi-key", "88a41c229f0606d7c268a4db6244b052");
                    client.DefaultRequestHeaders.Add("x-rapidapi-host", "v1.american-football.api-sports.io");

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        var leagues = JsonConvert.DeserializeObject<List<LeagueDTO>>(responseBody);
                    }
                    else
                    {
                        throw new ApiServiceException("The system from Nagico is not working");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return responseFromNagico;
        }


        public class ApiServiceException : Exception
        {
            public ApiServiceException(string message) : base(message)
            {
            }
        }

    }
}

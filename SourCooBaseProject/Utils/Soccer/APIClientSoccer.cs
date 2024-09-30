using Newtonsoft.Json;

namespace QuinielasApi.Utils.Soccer
{
    public static class APIClientSoccer
    {
        public static async Task<string> GetCertificateNumber()
        {
            string? responseFromNagico = "";
            string endpoint = "";
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
                        responseFromNagico = JsonConvert.DeserializeObject<string>(responseBody);
                    }
                    else
                    {
                        throw new NagicoServiceException("The system from Nagico is not working");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return responseFromNagico!;
        }


        public class NagicoServiceException : Exception
        {
            public NagicoServiceException(string message) : base(message)
            {
            }
        }

    }
}

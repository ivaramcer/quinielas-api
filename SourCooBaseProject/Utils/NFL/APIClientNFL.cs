﻿using Microsoft.DotNet.MSIdentity.Shared;
using Newtonsoft.Json;
using QuinielasApi.Models.Entities;
using QuinielasApi.Utils.NFL.DTO;

namespace QuinielasApi.Utils.NFL
{
    public static class APIClientNFL
    {
        public static int currentYear = DateTime.Now.Year;
        public static int league = 1;

        public static async Task<string> GetSeasons()
        {
            string responseFromAPI= "";
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
                        throw new ApiServiceException("The external system is not working");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return responseFromAPI;
        }



        public static async Task<List<GetGamesDTO>?> GetGames(int leagueId)
        {
            List<GetGamesDTO>? games = new List<GetGamesDTO>();
            string endpoint = $"games?league={leagueId}&season={currentYear}";
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
                        ApiResponse<GetGamesDTO> apiResponse = JsonConvert.DeserializeObject<ApiResponse<GetGamesDTO>>(responseBody);

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
        public static async Task<List<GetTeamsDTO>?> GetTeams()
        {
            string endpoint = $"teams?league={league}&season={currentYear}";
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
                    List<GetTeamsDTO>? teams = new List<GetTeamsDTO>();

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        ApiResponse<GetTeamsDTO> apiResponse = JsonConvert.DeserializeObject<ApiResponse<GetTeamsDTO>>(responseBody);

                        teams = apiResponse!.Response;

                    }
                    else
                    {
                        throw new ApiServiceException("The external system is not working");
                    }
                    
                    return teams;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

        }

        public static async Task<List<LeagueInfoDto>?> GetLeagues()
        {
            List<LeagueInfoDto>? teams = new List<LeagueInfoDto>();
            string endpoint = $"leagues?season={currentYear}";
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
                        ApiResponse<LeagueInfoDto> apiResponse = JsonConvert.DeserializeObject<ApiResponse<LeagueInfoDto>>(responseBody);

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


        public class ApiResponse<T>
        {
            public string Get { get; set; } = default!;
            public Dictionary<string, string> Parameters { get; set; } = default!;
            public List<string> Errors { get; set; } = default!;
            public int Results { get; set; }
            public List<T> Response { get; set; } = default!;
        }

    }
}

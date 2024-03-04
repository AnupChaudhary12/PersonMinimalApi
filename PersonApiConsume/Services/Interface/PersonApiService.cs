using DataAccess.DTOs;
using DataAccess.Interfaces;
using Microsoft.Extensions.Options;
using PersonApiConsume.Models;
using PersonApiConsume.Services.Implementation;
using PersonMinimalApi.ApiCode.Interfaces;
using System.Text.Json;

namespace PersonApiConsume.Services.Interface
{
    public class PersonApiService : IPersonApiService
    {
        private readonly HttpClient _httpClient;
        private readonly PersonApiOptions _personApiOptions;

        public PersonApiService(HttpClient httpClient,IOptions<PersonApiOptions> options)
        {
            _httpClient = httpClient;
            _personApiOptions = options.Value;
        }

        public async Task<List<PersonGetDTO>> GetPersons()
        {
            string url = _personApiOptions.BaseUrl;
            var result = new List<PersonGetDTO>();
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Response Content: " + stringResponse);
                try
                {
                    result = JsonSerializer.Deserialize<List<PersonGetDTO>>(stringResponse);
                }
                catch (JsonException ex)
                {
                    throw new JsonException("Error deserializing response content.", ex);
                }

            }
            else
            {
                Console.WriteLine("HTTP Status Code: " + response.StatusCode);
                throw new HttpRequestException(response.ReasonPhrase);
            }
            return result;
        }
    }
}



using DataStructuresPractice.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;

namespace DataStructuresPractice.Services
{
    public class IntegrationsService
    {        
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<RandomUserResponse> GetUsers()
        {
            using var httpClient = new HttpClient();
            var response = await _httpClient.GetAsync("https://randomuser.me/api/?results=500&nat=br,us,dk,ua");

            if (response.IsSuccessStatusCode)
            {                
                var responseJson = await response.Content.ReadAsStringAsync();                
                var responseContent = JsonConvert.DeserializeObject<RandomUserResponse>(responseJson);

                if (responseContent is null)
                    return new();

                return responseContent;
            }

            return new();
        }
    }
}

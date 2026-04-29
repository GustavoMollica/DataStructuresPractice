

using DataStructuresPractice.Models;
using DataStructuresPractice.Responses;
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

        public async Task<CartResponse> GetCarts()
        {
            var response = await _httpClient.GetAsync("https://dummyjson.com/carts");

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseContent = JsonConvert.DeserializeObject<CartResponse>(responseJson);

                if(responseContent is null)
                    return new();

                return responseContent;
            }
            return new();
        }
    }
}

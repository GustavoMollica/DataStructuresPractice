

using DataStructuresPractice.Models;
using Newtonsoft.Json;
using System.Dynamic;

namespace DataStructuresPractice.Services
{
    public class IntegrationsService
    {        
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<User>> GetAllUsers()
        {
            using var httpClient = new HttpClient();
            var response = await _httpClient.GetAsync("https://randomuser.me/api/?results=500&nat=br,us,dk,ua");

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();                
                var responseContent = JsonConvert.DeserializeObject<RandomUserResponse>(responseJson);

                if (responseContent is null)
                    return new List<User>();

                return GenerateDataVolume(responseContent);
            }

            return new List<User>();
        }

        private List<User> GenerateDataVolume(RandomUserResponse randomUserResponse)
        {
            //apenas para simular uma quantidade de dados em um cenario real            
            var users = new List<User>();

            for (var i = 0; i < 200; i++) 
            {
                users.AddRange(randomUserResponse.Results);
            }

            return users;
        }
    }
}

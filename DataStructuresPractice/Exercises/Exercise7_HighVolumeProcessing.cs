using DataStructuresPractice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPractice.Exercises
{
    public class Exercise7_HighVolumeProcessing
    {
        public async Task Execute()
        {
            var integrationService = new IntegrationsService();
            var allUsers = await integrationService.GetAllUsers();

            var userService = new UserService();

            var userCache = userService.CacheUsers(allUsers);
            var usersUnique = userCache.Values.ToList();

            var usersByNat = userService.GetUserByNat(usersUnique);

            Console.WriteLine($"Quantidade total de usuarios que acessou o sistema nesse mes:{allUsers.Count}\n" +
                $"Quantidade de usuarios unicos que acessaram o sistema esse mes:{usersUnique.Count}\n" +
                $"Tempo de execução do sistema:\n" +
                $"Quantidade dos usuarios unicos por pais:");

            foreach (var user in usersByNat)
            {
                Console.WriteLine($"{user.Key}:{user.Value.Count}");
            }
        }
    }
}

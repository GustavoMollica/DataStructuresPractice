using DataStructuresPractice.Services;
using DataStructuresPractice.Utils;
using System.Diagnostics;

namespace DataStructuresPractice.Exercises
{
    public class Exercise7_HighVolumeProcessing
    {
        public async Task Execute()
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();
            var integrationService = new IntegrationsService();
            var users = await integrationService.GetUsers();

            var userService = new UserService();
            var allUsers = DataGenerator.GenerateDataVolume(users.Results, 200);

            var userCache = userService.CacheUsers(allUsers);
            var usersUnique = userCache.Values.ToList();

            var usersByNat = userService.GetUserByNat(usersUnique);
            stopwatch.Stop();

            Console.WriteLine($"Quantidade total de usuarios que acessou o sistema nesse mes:{allUsers.Count}\n" +
                $"Quantidade de usuarios sem repetição que acessaram o sistema esse mes:{usersUnique.Count}\n" +
                $"Tempo de execução do sistema:{stopwatch.ElapsedMilliseconds} milissegundo\n" +
                $"Quantidade de usuarios por pais:");

            foreach (var user in usersByNat)
            {
                Console.WriteLine($"{user.Key}:{user.Value.Count}");
            }
        }
    }
}
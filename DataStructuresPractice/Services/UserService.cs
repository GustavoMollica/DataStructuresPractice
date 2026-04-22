using DataStructuresPractice.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPractice.Services
{
    public class UserService
    {        
        public Dictionary<string, User> CacheUsers(List<User> users)
        {
            var cacheUsers = new Dictionary<string, User>();

            foreach (var user in users)
            {
                cacheUsers.TryAdd(user.Email, user);
            }

            return cacheUsers;
        }

        public Dictionary<string, List<User>> GetUserByNat(List<User> listUsers)
        {
            var usersByNat = new Dictionary<string, List<User>>();

            foreach (var user in listUsers)
            {
                if (!usersByNat.TryGetValue(user.Nat, out var list))
                {
                    list = new List<User>();
                    usersByNat[user.Nat] = list;
                }

                list.Add(user);
            }

            return usersByNat;
        }
    }
}

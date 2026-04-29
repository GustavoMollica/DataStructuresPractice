using DataStructuresPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresPractice.Utils
{
    public static class DataGenerator
    {
        public static List<T> GenerateDataVolume<T>(List<T> data, int multiplier)
        {
            //apenas para simular uma quantidade de dados em um cenario real e duplicidade           
            var datas = new List<T>();

            for (var i = 0; i < multiplier; i++)
            {
                datas.AddRange(data);
            }

            return datas;
        }
    }
}

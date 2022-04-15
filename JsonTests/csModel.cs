using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonTests
{
    class csModel
    {
    }

    public class Fruit
    {
        public Dictionary<string,int> Data { get; set; }


        public Fruit()
        {
            Data = new Dictionary<string, int>();
        }

        public void Init()
        {
            for (int i = 0; i < 3; i++)
            {
                Data.Add($"Type_{i+1}", i + 1);
            }
        }

 
    }
}

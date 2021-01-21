using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zarazusune
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 2;
            int b = 1;
            string result = (a + b < 4) ? "Below" : "Over";
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Banker banker = new Banker();
            banker.getData();
            while (true)
            {
                banker.GetResource();
                banker.showData();
            }
        }
    }
}

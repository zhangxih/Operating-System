using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _3._0
{
    class Storage
    {
        public int status = 0;

        public int numberOfByte;

        public int numberOfBit;

        public Storage(int nobyte, int nobit)
        {
            numberOfByte = nobyte;
            numberOfBit = nobit;
        }

        public static string Show(List<Storage> storages)
        {
            string show = "";
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    show = show + storages[8 * i + j].status + "   ";
                }
                show = show + "\r\n";
            }
            return show;
        }
    }
}

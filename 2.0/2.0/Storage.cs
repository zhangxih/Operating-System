using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._0
{
    class Storage
    {
        private int number;
        private int address;
        private int length;
        public bool allocated=false;
        public int Number
        {
            get
            {
                return number;
            }
        }
        public int Address
        {
            get
            {
                return address;
            }
        }
        public int Length
        {
            get
            {
                return length;
            }
        }
        public Storage(int n,int a,int l,bool allocated)
        {
            number = n;
            address = a;
            length = l;
            this.allocated = allocated;
        }
        public static List<Storage> storages(bool [] space)
        {
            List<Storage> sto = new List<Storage>();
            int number = 1;
            int i = 0;
            int begin;
            while (i < space.Length)
            {
                while (i < space.Length)
                {
                    if (!space[i])
                        break;
                    i++;
                }
                begin = i;
                while (i < space.Length)
                {
                    if (space[i])
                        break;
                    i++;
                }
                if (i != begin)
                {
                    sto.Add(new Storage(number, begin, i - begin, false));
                    number++;
                }
            }
            return sto;
        }

        public static int request(int length, List<Storage> storages)
        {
            int address=12345;
            foreach(Storage sto in storages)
            {
                if (sto.Length >= length)
                {
                    address = sto.Address;
                    break;
                }
            }
            return address;
        }
    }
}

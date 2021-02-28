using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1._0
{
    class PCB
    {
        public PCB nextpcb;
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private int requiredtime;
        public int RequiredTime
        {
            get
            {
                return requiredtime;
            }
            set
            {
                requiredtime = value;
            }
        }
        private int runtime;
        public int RunTime
        {
            get
            {
                return runtime;
            }
            set
            {
                runtime = value;
            }
        }
        public char status='R';

        public PCB(string n)
        {
            name = n;
        }

        public bool Run()
        {
            if (runtime + 1000 >= requiredtime)
            {
                runtime = requiredtime;
                status = 'E';
                return true;
            }
            else
            {
                runtime += 1000;
                return false;
            }
        }
    }
}

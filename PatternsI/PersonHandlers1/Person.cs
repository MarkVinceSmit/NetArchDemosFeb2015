using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHandlers1
{
    public class Person : IPerson
    {
        public string Firstname
        {
            get { return "Marvin"; }

        }
    }
}

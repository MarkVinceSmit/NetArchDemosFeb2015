using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonHandlers1
{
    public class PersonFactory : IPersonFactory
    {
        public IPerson CreatePerson()
        {
            return new Person();
        }
    }
}

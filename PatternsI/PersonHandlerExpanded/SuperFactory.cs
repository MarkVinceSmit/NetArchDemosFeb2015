using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace PersonHandlerExpanded
{
    public class SuperFactory : IPersonFactory
    {
        public IPerson CreatePerson()
        {
            return new NewPersonSuperClassCauseIAmGodPrograamwerSinceIAm6AndComeFromChina();
        }
    }
}

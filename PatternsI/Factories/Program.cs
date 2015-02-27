using System;
using System.Configuration;
using System.Runtime.InteropServices;
using Common;
using System.Reflection;

namespace Factories
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Assembly asm = Assembly.Load(ConfigurationManager.AppSettings["asm"]);
            IPersonFactory pFact = (IPersonFactory)asm.CreateInstance(ConfigurationManager.AppSettings["type"]) as IPersonFactory;
            IPerson p = pFact.CreatePerson();

            Console.WriteLine( "{0} is happy", p.Firstname);
        }
    }

}
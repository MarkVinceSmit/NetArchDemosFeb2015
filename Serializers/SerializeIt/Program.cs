using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
//using System.Xml.Schema;
//using System.Xml.Serialization;

namespace SerializeIt
{
    class Program
    {
        private static void Main(string[] args)
        {

            //XmlSerializer xSer = new XmlSerializer(typeof (Person));
            SoapFormatter ser = new SoapFormatter();


            using (FileStream fs = new FileStream(@"c:\temp\person.soap", FileMode.Create, FileAccess.Write))
            {
                ser.Serialize(fs, new Person());
            }
        }
    }

    [Serializable]
    public class Person
    {
        public int dummy = 1; 

        public string FirstName
        {
            get {  
                return "Marvin"; 
            }
             set { }
        }

        private string secret = "123345";

        public void HelloWorld()
        {
            Console.WriteLine("Hello world");
        }

    }
}

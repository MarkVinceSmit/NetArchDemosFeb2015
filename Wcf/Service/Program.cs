using Interfacing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var host = new ServiceHost(typeof(Calc)))
            {
                // Adding the '?wsdl' behavior to our host. (Although we expose it without using ?wsdl!)
                ServiceMetadataBehavior smdBeh = new ServiceMetadataBehavior()
                {
                    HttpGetEnabled = true,
                    HttpGetUrl = new Uri("http://localhost:9001")
                };

                host.Description.Behaviors.Add(smdBeh);

                host.AddServiceEndpoint(typeof (ICalculator), new NetTcpBinding(), "net.tcp://localhost:9000/calc");

                host.Open();

                Console.WriteLine( "Running, press enter to exit" );
                Console.ReadLine(  );
            }

        }
    }

    public class Calc : ICalculator
    {
        public void Add(int a, int b)
        {
            ICalculatorResult resultChannel = OperationContext.Current.GetCallbackChannel<ICalculatorResult>();
            resultChannel.ProvideResult(a + b);
        }

        public void Sub(int a, int b)
        {
            int result =  a - b;
        }

        public void Mul(int a, int b)
        {
            int result = a * b;
        }

        public void Div(int a, int b)
        {
            int result = a / b;
        }
    }

}

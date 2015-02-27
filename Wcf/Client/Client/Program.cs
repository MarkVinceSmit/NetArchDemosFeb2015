using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Interfacing;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            InstanceContext ic = new InstanceContext(new ResultHandler());
            
            DuplexChannelFactory<ICalculator> chanFact = new DuplexChannelFactory<ICalculator>(ic, new NetTcpBinding(), "net.tcp://localhost:9000/calc");
            ICalculator calc = chanFact.CreateChannel();
            calc.Add(2, 2);

            Console.WriteLine(  "Waiting for response, press key to exit");
            Console.ReadLine(  );
        }
    }

    public class ResultHandler : ICalculatorResult
    {
        public void ProvideResult(int resultValue)
        {
            Console.WriteLine(resultValue);
        }
    }
}

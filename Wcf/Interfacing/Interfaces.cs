using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Interfacing
{
    [ServiceContract(CallbackContract = typeof(ICalculatorResult))]
    public interface ICalculator
    {
        [OperationContract(IsOneWay = true)]
        void Add(int a, int b);
        [OperationContract(IsOneWay = true)]
        void Sub(int a, int b);
        [OperationContract(IsOneWay = true)]
        void Mul(int a, int b);
        [OperationContract(IsOneWay = true)]
        void Div(int a, int b);
    }


    [ServiceContract]
    public interface ICalculatorResult
    {
        [OperationContract(IsOneWay = true)]
        void ProvideResult(int resultValue);
    }
}

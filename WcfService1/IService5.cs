using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{

    public interface IService5CallBack
    {
        [OperationContract(IsOneWay= true)]
        void OnCallBack(string inputString);
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService5" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IService5CallBack))]
    public interface IService5
    {
        [OperationContract]
        void DoWork(string inputString);
    }
}

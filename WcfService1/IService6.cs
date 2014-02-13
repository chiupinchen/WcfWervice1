using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    //transaction test
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService6" in both code and config file together.
    [ServiceContract]
    public interface IService6
    {
        [OperationContract]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        int DoWork();
    }
}

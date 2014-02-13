using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Transactions;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service6" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service6.svc or Service6.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service6 : IService6
    {
        private int a = 5;

        //http://stackoverflow.com/questions/10338711/wcf-instancecontextmode-persession
        //whenever TransactionScopeRequired=true, the instance context mode would be switch back to be PerCall
        [OperationBehavior(TransactionScopeRequired=true)]
        public int DoWork()
        {
            Transaction currentTx = Transaction.Current;

            a = a + 1;
           
            return a;
        }
    }
}

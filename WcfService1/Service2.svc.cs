using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    
    [ServiceBehavior(InstanceContextMode  = InstanceContextMode.PerSession)]
    public class Service2 : IService2
    {

        private int a = 5;
        public void DoWork()
        {
            
         


        }

        public string GetA()
        {
            string sessionID = OperationContext.Current.SessionId;

            a = a + 1;

            return sessionID + a.ToString();
        }
    }
}

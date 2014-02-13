using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service3" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service3.svc or Service3.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode= InstanceContextMode.Single)]
    public class Service3 : IService3
    {
        private int a = 5;

        public int ShareSingletonResource1()
        {
            a = a + 1;
            return a;
        }

        public int ShareSingletonResource2()
        {
            a = a + 2;
            return a;
        }
    }
}

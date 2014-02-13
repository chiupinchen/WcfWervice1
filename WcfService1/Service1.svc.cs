using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace WcfService1
{

    public class MyException 
    {
        public string Reason { get; set; }

        public Person Person { get; set; }
    }

    [DataContract]
    [KnownType(typeof(JuniorHighStudent))]
    public class Person
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }
    }

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private string a = "a";
        public string GetData1(int value)
        {
            a = a + a;
            return value.ToString() + a;
        }
        public string GetData(int value)
        {
            throw new Exception("plain exception");
            throw new FaultException("falut exception directly");

            MyException excep1 = new MyException() { Reason = "123", Person = new Person() { Age = 4, Name = "Name" } };
            throw new FaultException<MyException>(excep1, "12345");

            InvalidCastException excep =  new InvalidCastException("abcde");
            throw new FaultException<InvalidCastException>(excep, "InvalidCastException");
            
            
            DivideByZeroException exception = new DivideByZeroException("abc");
            throw new FaultException<DivideByZeroException>(exception, new FaultReason("my reason"));

            
            return string.Format("You entered: {0}", value);
        }


       

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public string GetLongData()
        {
            Thread.Sleep(5000);
            return "LongData";
        }
    }
}

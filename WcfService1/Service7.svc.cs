using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service7" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service7.svc or Service7.svc.cs at the Solution Explorer and start debugging.
    public class Service7 : IService7
    {
        public void DoWork()
        {
        }

        public Student GetStudent()
        {
            return new Student() { Name = "abc", Age = 20 };
        }


       


        public Person GetJuniorHighStudent(Person juniorHighStudent)
        {
            return new JuniorHighStudent();
        }
    }
}

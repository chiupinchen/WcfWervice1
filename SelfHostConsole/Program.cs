using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WcfService1;

namespace SelfHostConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            

          
                //Uri baseAddress = new Uri("http://localhost:9010/Service7");

                using (ServiceHost host = new ServiceHost(typeof(WcfService1.Service7)))
                {
                   
                    host.Open();

                    //Console.WriteLine("The service is ready at: {0}", baseAddress);
                    Console.WriteLine("Press <Enter> to stop the service");
                    Console.ReadKey();
                    host.Close();

                }


                

          

            
        }
    }
}

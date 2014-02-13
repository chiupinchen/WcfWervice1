using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using WebClient.ServiceReference1;
using WebClient.TCPService5;
using WebClient.TCPService6;
using WebClient.TcpService7;

namespace WebClient.Controllers
{

    class CallbackClass : IService5Callback
    {

        public void OnCallBack(string inputString)
        {
            inputString = inputString + DateTime.Now.Second.ToString();

            
        }
    }
    enum EventType
    {
        Event1 = 1,
        Event2 = 2,
        Event3 = 4,
        AllEvents = Event1 | Event2 | Event3
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Thread.Sleep(5000);
            return View();


            using (Service7Client tcpClient = new Service7Client())
            {

                //tcpClient.DoWork();
                tcpClient.GetStudent();
                
              

                WebClient.TcpService7.Person person = tcpClient.GetJuniorHighStudent(new WebClient.TcpService7.Person());

            }

            //ConcreteDecoratorB d2 = new ConcreteDecoratorB(new ConcreteDecoratorA(new ConcreteComponent()));

            //d2.Operation();

            //return View();


            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    Service6Client tcpClient = new Service6Client();
                    tcpClient.DoWork();
                    
                    ts.Complete();
                }
                catch (Exception ex)
                {
                    ts.Dispose();
                }
            }

            //using (Service6Client tcpClient = new Service6Client())
            //{

            //    tcpClient.DoWork();

                
            //}


            EventType p = EventType.AllEvents;

                Service5Client tcpClient5 = new Service5Client(new InstanceContext(new CallbackClass()));
            
                tcpClient5.DoWork("abc");


                //ThreadStart invoke = delegate { tcpClient5.DoWork("abc"); };
                //Thread thread = new Thread(invoke);
                //thread.Start();

                return View();

            using (Service1Client httpClient = new Service1Client())
            {

                string a = httpClient.GetData1(1);

                string b = httpClient.GetData1(1);
            }

            using (Service1Client httpClient = new Service1Client())
            {
                var sessionId = httpClient.InnerChannel.SessionId;
                string a = httpClient.GetData1(1);

                string b = httpClient.GetData1(1);
            }


            using (TCPService1.Service2Client tcpClient = new TCPService1.Service2Client())
            {

                string a = tcpClient.GetA();

                string b = tcpClient.GetA();
            }

            using (TCPService1.Service2Client tcpClient = new TCPService1.Service2Client())
            {

                string a = tcpClient.GetA();

                string b = tcpClient.GetA();
            }


            //Service1Client client = new Service1Client();
            ////string abcdefgh = client.GetData(123);
            //try
            //{
            //    string abcdefg = client.GetData(123);
            //}
            //catch (Exception eeeee)
            //{
            //    //var ttt = (FaultException<MyException>)eeeee;
                
            //    //MyException myexception = ttt.Detail;
               
            //    //throw;
            //}
            //var uuu = client.GetData(456);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
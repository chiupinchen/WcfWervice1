using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpeFeatures
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Person p1 = new Person();
            p1.methid2();

            //dynamic p2 = new Person();
            //p2.method3();

            object objExample = 10;
            objExample = "abc";
            
            dynamic dynamicExample = 10;
            dynamicExample = dynamicExample + 5;

            dynamicExample = "abc";

            
            
           


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }


        class Person 
        {
            public void method1(){}
            public void methid2(){}
        }
    }
}

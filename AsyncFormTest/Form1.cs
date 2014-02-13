using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncFormTest
{

    class Foo1
    { }
    
  
    public partial class Form1 : Form
    {
        
        class Foo
        {
            public Foo(string s)
            {
                Console.WriteLine("Foo constructor: {0}", s);
               
            }
            public void Bar() { }
        }
        class Base
        {
            readonly Foo baseFoo = new Foo("Base initializer");
            public Base(string a)
            {
                var aaa = a;
                Console.WriteLine("Base constructor");
            }
        }
        class Derived : Base
        {
            readonly Foo derivedFoo = new Foo("Derived initializer");
            public Derived(string a):base(a)
            {
                var aaa = a;
                Console.WriteLine("Derived constructor");
            }
        }
        public Form1()
        {
            new Derived("a");
            var foo1 = Activator.CreateInstance(typeof(Foo), "a");
            var foo2 = Activator.CreateInstance("AsyncFormTest", "AsyncFormTest.Foo1");
            InitializeComponent();
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            int theLength = await AccessTheWebAsync();
            label1.Text = theLength.ToString();
        }


        async Task<int> AccessTheWebAsync()
        {
            // You need to add a reference to System.Net.Http to declare client.
            HttpClient client = new HttpClient();

            // GetStringAsync returns a Task<string>. That means that when you await the 
            // task you'll get a string (urlContents).
            Task<string> getStringTask = client.GetStringAsync("http://localhost/WebClient/");

            // You can do work here that doesn't rely on the string from GetStringAsync.
            DoIndependentWork();

            // The await operator suspends AccessTheWebAsync. 
            //  - AccessTheWebAsync can't continue until getStringTask is complete. 
            //  - Meanwhile, control returns to the caller of AccessTheWebAsync. 
            //  - Control resumes here when getStringTask is complete.  
            //  - The await operator then retrieves the string result from getStringTask. 
            string urlContents = await getStringTask;

            // The return statement specifies an integer result. 
            // Any methods that are awaiting AccessTheWebAsync retrieve the length value. 
            return urlContents.Length;
        }

        void DoIndependentWork()
        {
            label1.Text += "working....";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            new ObserverPattern();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new ChainOfResponsibilityPattern();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new MediatorPattern();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new VisitorPattern();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new StatePattern();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new CommandPattern();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new DecoratorPattern();            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new CompositePattern();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new FlyWeightPattern();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new ProxyPattern();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new BuildPattern();
        }
    }

}

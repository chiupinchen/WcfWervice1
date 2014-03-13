using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncFormTest.DelegateAndAnonymousMethod
{
    class SampleControl : Component
    {
        // : 
        // Define other control methods and properties. 
        // : 

        // Define the delegate collection. 
        protected EventHandlerList listEventDelegates = new EventHandlerList();

        // Define a unique key for each event. 
        static readonly object mouseDownEventKey = new object();
        static readonly object mouseUpEventKey = new object();

        // Define the MouseDown event property. 
        public event MouseEventHandler MouseDown
        {
            // Add the input delegate to the collection.
            add
            {
                listEventDelegates.AddHandler(mouseDownEventKey, value);
            }
            // Remove the input delegate from the collection.
            remove
            {
                listEventDelegates.RemoveHandler(mouseDownEventKey, value);
            }
        }

        // Raise the event with the delegate specified by mouseDownEventKey 
        private void OnMouseDown(MouseEventArgs e)
        {
            MouseEventHandler mouseEventDelegate =
                (MouseEventHandler)listEventDelegates[mouseDownEventKey];
            mouseEventDelegate(this, e);
        }

        // Define the MouseUp event property. 
        public event MouseEventHandler MouseUp
        {
            // Add the input delegate to the collection.
            add
            {
                listEventDelegates.AddHandler(mouseUpEventKey, value);
            }
            // Remove the input delegate from the collection.
            remove
            {
                listEventDelegates.RemoveHandler(mouseUpEventKey, value);
            }
        }

        // Raise the event with the delegate specified by mouseUpEventKey 
        private void OnMouseUp(MouseEventArgs e)
        {
            MouseEventHandler mouseEventDelegate =
                (MouseEventHandler)listEventDelegates[mouseUpEventKey];
            mouseEventDelegate(this, e);
        }
    }


    class Class1
    {
        event Action<string> p;
       


        public void method1()
        {
            p += (a1 => { a1.ToString(); });
            p += (a2 => { a2.IndexOf("a"); });

            if (p != null)
            {
                p.Invoke("abc");
            }
            //Action<string> printReverse = delegate(string text)
            //{
            //    char[] chars = text.ToCharArray();
            //    Array.Reverse(chars);
            //    Console.WriteLine(new string(chars));
            //};

            Action<string> a = MyMethod1;

            Action<string> b = delegate(string b1)
            {
                b1.ToString();
            };

            Func<string> b2 = delegate
            {
                return "123";
            };

            Action<string> c = (s) => { s.ToString(); };
        }


        public void MyMethod1(string a)
        {
            a.ToString();
        }
    }
}

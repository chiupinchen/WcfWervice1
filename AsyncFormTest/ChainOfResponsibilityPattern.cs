using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class ChainOfResponsibilityPattern
    {
        public ChainOfResponsibilityPattern()
        {
            Handler handler = new Handler1(new Handler2(null));
            handler.Handle();
        }
    }

    public abstract class Handler
    {
        private Handler nextHandler;
        public Handler(Handler nextHandler)
        { 
            this.nextHandler = nextHandler;
        }

        public void DoNext()
        {
            
            if (this.nextHandler!=null)
            {
                this.nextHandler.Handle();
            }
        }
        abstract public void Handle();
    }

    public class Handler1 : Handler 
    { 
        public Handler1(Handler nextHandler)
            :base(nextHandler){}


        public override void Handle()
        {
            //do my work();
            DoNext();
        }
    }

    public class Handler2 : Handler
    {
        public Handler2(Handler nextHandler)
            : base(nextHandler) { }
        public override void Handle()
        {
            //do my work2();
            DoNext();
        }
    }
}

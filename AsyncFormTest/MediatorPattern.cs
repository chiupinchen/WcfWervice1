using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class MediatorPattern
    {
        public MediatorPattern()
        {
            Mediator mediator = new Mediator1();

            CoWorker1 coworker1 = new CoWorker1(mediator);
            CoWorker2 coworker2 = new CoWorker2(mediator);

            mediator.AddCoWorker(coworker1);

            mediator.AddCoWorker(coworker2);

            coworker1.DoWork();

            coworker2.DoWork();

        }
    }

    public abstract class Mediator
    { 
        public abstract void doWork(CoWorker coworker, string message);

        protected List<CoWorker> list = new List<CoWorker>();
        public void AddCoWorker(CoWorker coworker){
            list.Add(coworker);
        }

        
    }

    public class Mediator1 : Mediator
    {
        
        public Mediator1()
        { 
        
        }

        public override void doWork(CoWorker coworker, string message)
        {
            foreach (var currentCoworker in list.Where(l=>l!=coworker))
            {
                currentCoworker.notify();
            }
        }
    }

    public abstract class CoWorker
    {
        protected Mediator mediator;
        public CoWorker(Mediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void notify();
    }

    public class CoWorker1 : CoWorker
    {
        public CoWorker1(Mediator mediator) : base(mediator) { }

        public void DoWork()
        {
            base.mediator.doWork(this, "gogogog");
        }

        public override void notify()
        {
            //"dowork2 1"
        }
    }

    public class CoWorker2 : CoWorker
    {
        public CoWorker2(Mediator mediator) : base(mediator) { }

        public void DoWork()
        {
            base.mediator.doWork(this, "yayaya");
        }

        public override void notify()
        {
            //"dowork2 2"
        }
    }


}

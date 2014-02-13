using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class ObserverPattern
    {
        public ObserverPattern()
        { 
            Subject subject = new Subject();
            subject.Subscribe(new Subscriber1());
            subject.Subscribe(new Subscriber2());

            subject.DoWork();
        }
    }

    public class Subscriber1 : IObserver<int>
    {

        public void OnCompleted()
        {
            
        }

        public void OnError(Exception error)
        {
            
        }

        public void OnNext(int value)
        {
            
        }
    }

    public class Subscriber2 : IObserver<int>
    {

        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {

        }

        public void OnNext(int value)
        {

        }
    }

    public class Subject : IObservable<int>
    {

        private List<IObserver<int>> list;

        public Subject()
        {
            list = new List<IObserver<int>>();
        }

        public void DoWork()
        {
            foreach (var observer in list)
            { 
                doMyWork();
                observer.OnNext(5);
            }
        }

        private void doMyWork()
        {}

        public IDisposable Subscribe(IObserver<int> observer)
        {
            list.Add(observer);

            return new Unsubscriber();
        }


        private class Unsubscriber : IDisposable
        {

            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}

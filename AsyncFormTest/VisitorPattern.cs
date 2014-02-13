using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class VisitorPattern
    {
        public VisitorPattern()
        {
            Member member = new Member();
            Service service = new Service();
            service.DoService(member);
        }
    }


    interface Visitable
    {
        void Accept(Visitor visitor);
    }

    interface Visitor
    {
        void Visit(Member member);
        void Visit(Vip vip);
    }

    class VisitorImplementation : Visitor
    {

        public void Visit(Member member)
        {
            member.doMember();
        }

        public void Visit(Vip vip)
        {
            vip.doVip();
        }
    }

    abstract class Customer : Visitable
    {
        public void doCustomer()
        {

        }

        public abstract void Accept(Visitor visitor);
       
    }

    class Member : Customer 
    {
        public void doMember() { }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Vip : Customer
    {
        public void doVip() { }

        public override void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class Service
    {

        public void DoService(Customer customer)
        {
            customer.doCustomer();
            ((Visitable)customer).Accept(new VisitorImplementation());

        }
    }
}

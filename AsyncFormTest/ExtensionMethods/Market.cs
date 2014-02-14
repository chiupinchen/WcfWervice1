using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest.ExtensionMethods
{

    public static class MyExtensionMethod
    {
        public static int GetTotalPrice(this Market market)
        {
            return market.Fruits.Sum(f => f.Price);
        }

        public static int GetTotalPrice(this Market market, int inflactionFactor)
        {
            return market.Fruits.Sum(f => f.Price) * inflactionFactor;
        }

        public static int GetTotalPriceUsingInterface(this ICalculatable calculatable)
        {
            return calculatable.Fruits.Sum(f => f.Price);
        }
    }

    public class Fruit
    {
        public string Name;
        public int Price;
    }

    public interface ICalculatable
    {
        List<Fruit> Fruits { get; set; }
    }
    public class Market : ICalculatable
    {
        private List<Fruit> fruits;

        public Market()
        { 
        
        }

        public void Add(Fruit fruit)
        {
            fruits.Add(fruit);
        }


        public List<Fruit> Fruits
        {
            get
            {
                return fruits;
            }
            set
            {
                fruits = value;
            }
        }
    }

    public class ExtensionMethods
    {
        public ExtensionMethods()
        {
            Market market = new Market();
            market.Add(new Fruit(){ Name = "Apple", Price = 5});
            market.Add(new Fruit() { Name = "Orange", Price = 6 });

            var totalPrice = market.GetTotalPrice();
            var totalPrice2 = market.GetTotalPrice(5);
            var totalPrice3 = market.GetTotalPriceUsingInterface();
            var totalPrice4 = ((ICalculatable)market).GetTotalPriceUsingInterface();

        }
    }
}

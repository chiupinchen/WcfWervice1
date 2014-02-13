using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class DecoratorPattern
    {
        public DecoratorPattern()
        {
            Meal meal = new Bean(new Coslaw(new Hamburger()));
            int a = meal.GetPrice();
        }
    }


    public interface Meal
    {
       
        int GetPrice();
    }

    public class Hamburger : Meal
    {
        
        public int GetPrice()
        {
            return 5;
        }
    }
    public class Fry : Meal
    {

        public int GetPrice()
        {
            return 3;
        }
    }

    public abstract class SideDish:Meal
    {
        protected Meal meal;
        public SideDish(Meal meal)
        {
            this.meal = meal;
        }
        public abstract int GetPrice();
      
    }

    public class Coslaw : SideDish
    {
        public Coslaw(Meal meal) : base(meal) { }
        public override int GetPrice()
        {
            return base.meal.GetPrice() + 1;
        }           
    }

    public class Bean : SideDish
    {
        public Bean(Meal meal) : base(meal) { }
        public override int GetPrice()
        {
            return base.meal.GetPrice() + 2;
        }
    }
}

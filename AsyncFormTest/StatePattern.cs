using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class StatePattern
    {
        public StatePattern()
        {
            TrafficLight trafficLight = new TrafficLight();

            while (true)
            {
                trafficLight.Change();
            }
        }
    }


    public interface State
    {
        void Change(TrafficLight light);
    }

    public abstract class Light : State
    {

        public abstract void Change(TrafficLight light);
       
    }

    public class Red : Light
    {

        public override void Change(TrafficLight light)
        {
            //lighting
            light.setState(new Green());
        }
    }

    public class Green : Light
    {

        public override void Change(TrafficLight light)
        {
            //lighting
            light.setState(new Yellow());
        }
    }

    public class Yellow : Light
    {

        public override void Change(TrafficLight light)
        {
            //lighting
            light.setState(new Red());
        }
    }

    public class TrafficLight
    {
        State state = new Red();
        public void setState(State state)
        {
            this.state = state;
        }

        public void Change()
        { 
            this.state.Change(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class FlyWeightPattern
    {
        public FlyWeightPattern()
        {
            ResourceFactory factory = new ResourceFactory();
            var res1 = factory.GetResource("a");
            var res2 = factory.GetResource("b");
            var res3 = factory.GetResource("a");
        }
    }

    public class Resource
    {
        public string Name;
    }
    public class ResourceFactory
    {
        private List<Resource> list = new List<Resource>();

        public ResourceFactory()
        { 
        
        }

        public Resource GetResource(string name)
        {
            var resource = list.FirstOrDefault(s=>s.Name==name);

            if (resource==null)
            {
                resource = new Resource(){ Name = name};
                list.Add(resource);
                
            }
            
            return resource;
        }

    }
}

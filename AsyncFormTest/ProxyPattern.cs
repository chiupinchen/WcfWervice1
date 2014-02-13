using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class ProxyPattern
    {
        public ProxyPattern()
        {
            //don't really instantiate image objects yet
            Graphic graphic1 = new Proxy("doc1");
            Graphic graphic2 = new Proxy("doc2");

            //lazy initialization
            graphic1.Draw();
            graphic2.Draw();

            
            graphic1.Draw();
        }
    }

    public abstract class Graphic
    { 
        public abstract void Draw();
        
    }

    public class Image : Graphic
    {

        private readonly string fileName;

        public Image(string fileName)
        { 
            this.fileName = fileName;
        }

        public override void Draw()
        { 
            //do work
        }
    }

    public class Proxy : Graphic 
    {
        private Image image;
        private string fileName;

        public Proxy(string fileName)
        { 
            this.fileName = fileName;
        }

        public override void Draw()
        {
            if (image == null)
            {
                image = new Image(fileName);
            }
            image.Draw();
        }
    }
}

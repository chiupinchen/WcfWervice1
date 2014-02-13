using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class CommandPattern
    {
        public CommandPattern()
        {
            ImageService imageService = new ImageService();
            imageService.AddCommand(new CommandConcrete1());
            imageService.AddCommand(new CommandConcrete2());
            imageService.Draw();
        }
    }

    public interface Drawing 
    {
        void Drawing1();
        void Drawing2();
        void Drawing3();
    }

    public class DrawingImpl : Drawing
    {

        public void Drawing1()
        {
            
        }

        public void Drawing2()
        {
            
        }

        public void Drawing3()
        {
            
        }
    }

    public interface Command
    { 
        void Execute(Drawing drawing);
    }

    public class CommandConcrete1 : Command {

        public void Execute(Drawing drawing)
        {
            drawing.Drawing1();
            drawing.Drawing3();
        }
    }

    public class CommandConcrete2 : Command
    {
        public void Execute(Drawing drawing)
        {
            drawing.Drawing2();
            drawing.Drawing3();
        }
    }

    public class ImageService
    {
        List<Command> list = new List<Command>();
        public ImageService()
        { 
        
        }

        public void AddCommand(Command command)
        {
            list.Add(command);
        }

        public void Draw()
        {
            foreach (var c in list)
            {
                c.Execute(new DrawingImpl());
            }
        }
    }
}

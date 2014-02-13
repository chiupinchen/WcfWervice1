using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncFormTest
{
    public class CompositePattern
    {
        public CompositePattern()
        {
            PlayList playList1 = new PlayList();
            playList1.Add(new Frame("1a"));
            playList1.Add(new Frame("1b"));

            PlayList playList2 = new PlayList();
            playList2.Add(new Frame("2a"));
            playList2.Add(new Frame("2b"));

            PlayList playListTotal = new PlayList();
            playListTotal.Add(playList1);
            playListTotal.Add(playList2);

            playListTotal.Play();
        }
    }

    public interface Playable
    {
        void Play();
    }

    public class Frame : Playable 
    {

        private readonly string frameName;

        public Frame(string frameName)
        { 
            this.frameName = frameName;
        }

        public void Play()
        {
            var t = this.frameName;
            //play frame
        }
    }

    public class PlayList : Playable
    {
        List<Playable> list = new List<Playable>();
        public void Add(Playable playable)
        {
            list.Add(playable);
        }

        public void Play()
        {
            foreach (var p in list)
            {
                p.Play();
            }
        }
    }
}

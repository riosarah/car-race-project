using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class Track
    {
        private List<Section> _trackList;
        private bool _looped = false;

        public Track(List<Section> trackList) : this(trackList, false)
        {
        }
        public Track(List<Section> trackList, bool looped)
        {
            this._trackList = trackList;
            LinkSections();
            _looped = looped;
        }
        public Track((int, int)[] sectionList) : this(sectionList, false) { }
        public Track((int, int)[] sectionInfos, bool looped)
        {
            _trackList = new List<Section>();
            foreach ((int x, int y) in sectionInfos)
            {
                _trackList.Add(new Section(x, y));
            }
            _looped = looped;
            LinkSections();
        }

        public Section? StartSection { get => _trackList[0]; }
        public Section? LastSection
        {
            get
            {
                Section last = _trackList[_trackList.Count() - 1];
                return last;
            }
        }

        public int CountSections
        {
            get
            {
                return _trackList.Count();
            }
        }

        public int Length { get 
            {
                int sum = 0;
                if (_trackList[0] != null)
                {
                    foreach (Section i in _trackList)
                    {
                        sum += i.Length;
                    }
                }
                return sum;
            }
        }

        public int MaxSpeed { get 
            {
                int maxSpeed = 0;
                foreach(Section i in _trackList)
                {
                    if(i.MaxSpeed > maxSpeed)
                    {
                        maxSpeed = i.MaxSpeed;
                    }
                }
                return maxSpeed;
            } }

        public void LinkSections()
        {
            if (_trackList[0] != null)
            {
                Section old = _trackList[0];
                Section last = _trackList[_trackList.Count() - 1];
                foreach (Section a in _trackList)
                {
                    if (a != _trackList[0])
                    {
                        a.AddBeforeMe(old);
                    }
                    old = a;
                    if (a == last && _looped)
                    {
                        a.AddAfterMe(_trackList[0]);
                    }
                }
            }
        }
    }
}

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
        #region constructors
        public Track(List<Section> trackList) : this(trackList, false)
        {
        }
        public Track(List<Section> trackList, bool looped)
        {
            if (!SectionValuesAreValid(trackList)) 
            {
                throw new ArgumentException();
            }
            this._trackList = trackList;
            LinkSections();
            _looped = looped;
        }
        public Track((int, int)[] sectionList) : this(sectionList, false) { }
        public Track((int, int)[] sectionInfos, bool looped)
        {
            List<Section>tempTrackList = new List<Section>();
            foreach ((int x, int y) in sectionInfos)
            {
                tempTrackList.Add(new Section(x, y));
            }
            if (!SectionValuesAreValid(tempTrackList))
            {
                throw new ArgumentException();
            }
            _trackList = tempTrackList;
            _looped = looped;
            LinkSections();
        }

        private bool SectionValuesAreValid(List<Section> trackList)
        {
            bool valid = true;
            if (trackList[0] != null)
            {
                foreach (Section a in trackList)
                {
                    if (a.MaxSpeed <= 0 || a.Length <= 0)
                    {
                        valid = false;
                    }
                }
            }
            else
            {
                valid = false;
            }
            return valid;
        }
        #endregion constructors
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

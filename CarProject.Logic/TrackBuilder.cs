using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject.Logic
{
    public class TrackBuilder
    {
        private (int, int)[] sectionInfos;

        public TrackBuilder((int, int)[] sectionInfos) : this(sectionInfos, false)
        {           
        }

        public TrackBuilder((int, int)[] sectionInfos, bool looped)
        {
            this.sectionInfos = sectionInfos;
            Track = new Track(sectionInfos, looped);
        }

        public Track Track { get; set; }
        public object Looped { get; }
    }
}

using CarProject.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarProject.UnitTests
{
    [TestClass]
    public class TrackBuilderTest
    {
        [TestMethod]
        public void ItShouldBuildAConnectedTrack_GivenSectionInformation()
        {
            (int,int)[] sectionInfos = {(10,10),(20,20),(30,30)};
            TrackBuilder builder = new TrackBuilder(sectionInfos);
            Section expectedStartSection = new Section(10, 10);
            Assert.AreEqual(expectedStartSection.Length, builder.Track.StartSection.Length);
            Assert.AreEqual(expectedStartSection.MaxSpeed, builder.Track.StartSection.MaxSpeed);
        }
        [TestMethod]
        public void ItShouldBuildALoopedTrack_GivenLoopedCondition()
        {
            bool looped = true;
            (int, int)[] sectionInfos = { (10, 10), (20, 20), (30, 30) };
            TrackBuilder loopedTrack = new TrackBuilder(sectionInfos, looped);
            Assert.AreEqual(loopedTrack.Track.StartSection, loopedTrack.Track.LastSection.NextSection);
        }
    }
}

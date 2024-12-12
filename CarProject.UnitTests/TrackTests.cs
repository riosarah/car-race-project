using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarProject.Logic;

namespace CarProject.UnitTests
{
    [TestClass]
    public class TrackTests
    {
        [TestMethod]
        public void ItShouldCreateATrack_GivenAnyNumbersOfSections()
        {
            List<Section> trackList = new();
            Section startSection = new Section(50, 300);
            Section section = new Section(70, 500);
            Section lastSection = new Section(60, 200);
            trackList.Add(startSection);
            trackList.Add(section);
            trackList.Add(lastSection);

            Track track = new Track(trackList);

            Assert.AreEqual(startSection, track.StartSection);
        }
        [TestMethod]
        public void ItShouldReturnNumberOfSections_GivenATrack()
        {
            (int, int)[]sections = { (10, 10), (20, 20), (30, 30) };
            Track track = new Track(sections);
            int length = track.CountSections;
            Assert.AreEqual(3, length);
        }
        [TestMethod]
        public void ItShouldReturnTotalLength_GivenMultipleSections()
        {
            (int, int)[] sections = { (10, 10), (20, 20), (30, 30) };
            Track track = new Track(sections);
            int length = track.GetTotalLength();
            Assert.AreEqual(60, length);
        }
        [TestMethod]
        public void ItShouldReturnMaxSpeedOfAllSections_GivenATrack()
        {
            (int, int)[] sections = { (10, 10), (20, 20), (30, 30) };
            Track track = new Track(sections);
            int speed = track.MaxSpeed;
            Assert.AreEqual(30, speed);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldThrowAnException_GivenInvalidTrackSection()
        {
            List<Section> sectionList = new List<Section>();
            Section newSection = new Section(0,0);
            sectionList.Add(newSection);
            sectionList.Add(newSection);
            sectionList.Add(newSection);
            Track track = new Track(sectionList);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldThrowException_GivenAnEmptyList()
        {
            List<Section> emptyList = new List<Section>();
            Track invalidTrack = new Track(emptyList);
        }
        [TestMethod]
        public void ItShouldReturnAStringWithSectionInfos_GivenATrackAndToStringIsCalled()
        {
            (int, int)[] sections = { (10, 10), (20, 20), (30, 30) };
            Track track = new Track(sections);
            string result = track.ToString();
            string expected = "Track sections: (10,10), (20,20), (30,30).";
            Assert.AreEqual(expected, result);
        }

    }
}

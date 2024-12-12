using CarProject.Logic;

namespace CarProject.UnitTests
{
    [TestClass]
    public class SectionTest
    {
        [TestMethod]
        public void ItShouldHaveALengthAndAMaxSpeed_GivenObjectCreated()
        {
            // ARRANGE - Setzen der Testdaten für MaxSpeed und Länge
            var someSpeed = 60;
            var someLength = 400;

            // ACT - Erstellen eines neuen Section-Objekts mit den Testdaten
            Section section = new Section(someSpeed, someLength);

            // ASSERT - Überprüfen, ob MaxSpeed und Länge korrekt gesetzt wurden
            Assert.AreEqual(someSpeed, section.MaxSpeed); // Erwartung: MaxSpeed ist 60.
            Assert.AreEqual(someLength, section.Length); // Erwartung: Länge ist 400.
        }
        [TestMethod]
        public void ItShouldConnectASectionAfterTheCurrentSection_GivenAddAfterMeIsCalled()
        {
            Section section = new Section(60, 400);
            Section nextSection = new Section(60, 400);
            section.AddAfterMe(nextSection);

            Assert.AreEqual(nextSection, section.NextSection);
            Assert.AreEqual(section, nextSection.PreviousSection);
        }
        [TestMethod]
        public void ItShouldConnectASectionBeforeTheCurrentSection_GivenAddBeforeMeIsCalled()
        {
            Section section = new Section(60, 400);
            Section previousSection = new Section(60, 400);
            section.AddBeforeMe(previousSection);

            Assert.AreEqual(previousSection, section.PreviousSection);
        }
        [TestMethod]
        public void ItShouldInsertASectionBetweenTwoSections_GivenTwoConnectedSectionsAndAddAfterMeIsCalled()
        {
            Section sectionOne = new Section(60, 400);
            Section sectionTwo = new Section(60, 500);
            Section insertSection = new Section(50, 300);

            sectionOne.AddAfterMe(sectionTwo);
            sectionOne.AddAfterMe(insertSection);

            Assert.AreEqual(sectionTwo, sectionOne.NextSection!.NextSection);
        }

        [TestMethod]
        public void ItShouldInsertASectionBetweenTwoSections_GivenTwoConnectedSectionsAndAddbeforeMeIsCalled()
        {
            Section sectionOne = new Section(60, 400);
            Section sectionTwo = new Section(60, 500);
            Section insertSection = new Section(50, 300);

            sectionOne.AddAfterMe(sectionTwo);
            sectionTwo.AddBeforeMe(insertSection);

            Assert.AreEqual(sectionTwo, sectionOne.NextSection!.NextSection);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ItShouldThrowAnException_GivenInvalidParameters()
        {
            Section sectionOne = new Section(-10, 10);
        }
    }
}
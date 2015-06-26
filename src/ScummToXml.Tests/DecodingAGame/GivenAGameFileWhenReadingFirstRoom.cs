using NUnit.Framework;
using ScummToXml.Domain;
using ScummToXml.Readers;

namespace ScummToXml.Tests.DecodingAGame
{
    [TestFixture]
    public class GivenAGameFileWhenReadingFirstRoom
    {
        private RoomBlock _room;
        private const string TestFile = "../../../../mi2/MONKEY2.001";

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var file = new FileReader().Read(TestFile);
            _room = file.LflfBlocks[0].Room;
        }

        [Test]
        public void RmhdIsCorrect()
        {
            Assert.That(_room.RoomHeader, Is.Not.Null);
            Assert.That(_room.RoomHeader.Height, Is.EqualTo(200));
            Assert.That(_room.RoomHeader.Width, Is.EqualTo(320));
            Assert.That(_room.RoomHeader.NumObjects, Is.EqualTo(0));
        }

        [Test]
        public void BoxDataIsCorrect()
        {
            Assert.That(_room.BoxData, Is.Not.Null);
            Assert.That(_room.BoxData.BoxList.Count, Is.EqualTo(2));
            Assert.That(_room.BoxData.BoxList[0].Flags, Is.EqualTo(0));
            Assert.That(_room.BoxData.BoxList[0].Mask, Is.EqualTo(0));
        }

        [Test]
        public void BoxMatrixIsCorrect()
        {
            Assert.That(_room.BoxMatrix, Is.Not.Null);
            Assert.That(_room.BoxMatrix.AllPossibleBlockPaths.Count, Is.EqualTo(2));
        }
    }
}

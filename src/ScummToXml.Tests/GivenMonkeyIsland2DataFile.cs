using NUnit.Framework;
using ScummToXml.Domain;
using ScummToXml.Readers;

namespace ScummToXml.Tests
{
    [TestFixture]
    public class GivenMonkeyIsland2DataFile
    {
        private ScummFile _file;
        private const string TestFile = "../../../../mi2/MONKEY2.001";

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            _file = new FileReader().Read(TestFile);
        }

        [Test]
        public void WhenReadingRootChunkReadsLecfHeaderAnd9080321BytesContent()
        {
            Assert.That(_file.Header.HeaderName, Is.EqualTo("LECF"));
            Assert.That(_file.Header.ContentLength, Is.EqualTo(9080321));
        }

        [Test]
        public void WhenReadingRootChunksReads1LoffBlockAnd110LflfBlocks()
        {
            Assert.That(_file.LoffBlock, Is.Not.Null);
            Assert.That(_file.LflfBlocks.Count, Is.EqualTo(110));
        }

        [Test]
        public void WhenReadingLoffBlockHasCorrectRoomCountAndOffsets()
        {
            var loffBlock = _file.LoffBlock;
            Assert.That(loffBlock.NumRooms, Is.EqualTo(110));
            Assert.That(loffBlock.RoomOffsets.Count, Is.EqualTo(110));

            // File header + LoffHeader + LoffContent + LflfHeader
            uint expectedOffset = 8 + 8 + _file.LoffBlock.Header.ContentLength + 8;
            for (int i = 0; i < _file.LflfBlocks.Count; i++)
            {
                Assert.That(loffBlock.RoomOffsets[i].RoomId, Is.EqualTo(i+1));
                Assert.That(loffBlock.RoomOffsets[i].Offset, Is.EqualTo(expectedOffset));
                expectedOffset += _file.LflfBlocks[i].Header.ContentLength + 8;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ScummToXml.Domain;
using ScummToXml.Readers;

namespace ScummToXml.Tests
{
    [TestFixture]
    public class GivenMonkeyIsland2DataFileWhenReadingObjectScripts
    {
        private RoomBlock _room;
        private IList<ObcdBlock> _objectScripts;
        private const string TestFile = "../../../../mi2/MONKEY2.001";

        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            var file = new FileReader().Read(TestFile);
            _objectScripts = file.LflfBlocks.SelectMany(x => x.Room.ObjectScripts).ToList();
        }

        [Test]
        public void RmhdIsCorrect()
        {
            foreach (var script in _objectScripts)
            {
                Console.WriteLine(script == null ? "null" : script.Name + " - " + script.Verb.VerbEntries.Count + " verbs");
            }
        }
    }
}

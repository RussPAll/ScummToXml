using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class VerbReader
    {
        public VerbBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            //var bytes = reader.ReadBytes(100).Select(x => (char) x);
            List<VerbBlock.VerbEntry> verbEntries = new List<VerbBlock.VerbEntry>();
            while (true)
            {
                var verb = reader.ReadByte();
                if (verb == 0)
                    break;
                verbEntries.Add(new VerbBlock.VerbEntry
                {
                    Verb = verb,
                    Offset = reader.ReadUInt16()
                });
            }


            uint endIndex = header.ContentLength;
            foreach (var verb in verbEntries.OrderByDescending(x => x.Offset))
            {
                verb.Length = endIndex - (verb.Offset - 8);
                verb.Content = reader.ReadBytes((int)verb.Length);
                endIndex = (uint)(verb.Offset - 8);
            }

            var result = new VerbBlock
            {
                Header = header,
                VerbEntries = verbEntries
            };
            return result;
        }
    }
}
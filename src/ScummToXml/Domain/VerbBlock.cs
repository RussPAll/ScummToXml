using System.Collections.Generic;

namespace ScummToXml.Domain
{
    public class VerbBlock : ScummBlock
    {
        public class VerbEntry
        {
            public byte Verb { get; set; }
            public ushort Offset { get; set; }
            public long Length { get; set; }
            public byte[] Content { get; set; }
        }

        public List<VerbEntry> VerbEntries { get; set; }
    }
}
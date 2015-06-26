using System.Collections.Generic;

namespace ScummToXml.Domain
{
    public class BoxdBlock : ScummBlock
    {
        public byte[] Content { get; set; }
        public List<Box> BoxList { get; set; }

        public class Box
        {
            public ushort UpperLeftX { get; set; }
            public ushort UpperLeftY { get; set; }
            public ushort UpperRightX { get; set; }
            public ushort UpperRightY { get; set; }
            public ushort LowerRightX { get; set; }
            public ushort LowerRightY { get; set; }
            public ushort LowerLeftX { get; set; }
            public ushort LowerLeftY { get; set; }
            public byte Mask { get; set; }
            public byte Flags { get; set; }
            public uint Scale { get; set; }
        }
    }
}
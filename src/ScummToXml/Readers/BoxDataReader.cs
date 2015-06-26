using System;
using System.Collections.Generic;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class BoxDataReader
    {
        public BoxdBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {

            var numBlocks = reader.ReadUInt16();
            var boxList = new List<BoxdBlock.Box>();
            for (int i = 0; i < numBlocks; i++)
            {
                var box = new BoxdBlock.Box()
                {
                    UpperLeftX = reader.ReadUInt16(),
                    UpperLeftY = reader.ReadUInt16(),
                    UpperRightX = reader.ReadUInt16(),
                    UpperRightY = reader.ReadUInt16(),
                    LowerRightX = reader.ReadUInt16(),
                    LowerRightY = reader.ReadUInt16(),
                    LowerLeftX = reader.ReadUInt16(),
                    LowerLeftY = reader.ReadUInt16(),
                    Mask = reader.ReadByte(),
                    Flags = reader.ReadByte(),
                    Scale = reader.ReadUInt16()
                };
                boxList.Add(box);
            }

            var result = new BoxdBlock
            {
                Header = header,
                BoxList = boxList
            };
            return result;
        }
    }
}

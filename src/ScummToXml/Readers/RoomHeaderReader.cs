using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class RoomHeaderReader
    {
        public RmhdBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new RmhdBlock
            {
                Header = header,
                Width = reader.ReadUInt16(),
                Height = reader.ReadUInt16(),
                NumObjects = reader.ReadUInt16(),
            };
        }
    }
}
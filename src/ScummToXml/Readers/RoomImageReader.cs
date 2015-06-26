using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class RoomImageReader
    {
        public RmimBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new RmimBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
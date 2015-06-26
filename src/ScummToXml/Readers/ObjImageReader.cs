using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class ObjImageReader
    {
        public ObimBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new ObimBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
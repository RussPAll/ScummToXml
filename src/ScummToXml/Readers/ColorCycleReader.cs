using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class ColorCycleReader
    {
        public CyclBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new CyclBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
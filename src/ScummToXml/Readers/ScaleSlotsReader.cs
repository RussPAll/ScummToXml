using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class ScaleSlotsReader
    {
        public ScalBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new ScalBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
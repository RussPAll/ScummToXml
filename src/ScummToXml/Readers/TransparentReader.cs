using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class TransparentReader
    {
        public TrnsBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new TrnsBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
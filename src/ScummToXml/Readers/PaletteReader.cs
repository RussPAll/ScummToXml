using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class PaletteReader
    {
        public PalsBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new PalsBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
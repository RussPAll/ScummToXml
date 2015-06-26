using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class ClutReader
    {
        public ClutBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new ClutBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class LocalScriptReader
    {
        public LscrBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new LscrBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
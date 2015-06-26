using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class ExitScriptReader
    {
        public ExcdBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new ExcdBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
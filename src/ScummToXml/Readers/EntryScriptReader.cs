using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class EntryScriptReader
    {
        public EncdBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new EncdBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
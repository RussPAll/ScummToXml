using System.IO;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class CharsetReader
    {
        public CharsetBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new CharsetBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
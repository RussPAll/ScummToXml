using System.IO;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class CostumeReader
    {
        public CostumeBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new CostumeBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
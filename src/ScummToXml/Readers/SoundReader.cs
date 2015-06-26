using System.IO;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class SoundReader
    {
        public SoundBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new SoundBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
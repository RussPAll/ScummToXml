using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class EgaPaletteReader
    {
        public EpalBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new EpalBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
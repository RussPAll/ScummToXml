using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class NumScriptsReader
    {
        public NlscBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new NlscBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
using System.IO;
using System.Text;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class ScriptReader
    {
        public ScriptBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            return new ScriptBlock
            {
                Header = header,
                Content = reader.ReadBytes((int)header.ContentLength)
            };
        }
    }
}
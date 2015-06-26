using System.IO;
using ScummToXml.Domain;

namespace ScummToXml.Writers
{
    public class FileWriter
    {
        public void Write(string fileName, ScummFile file)
        {
            using (var outStream = new FileStream(fileName, FileMode.CreateNew))
            {
                using (var writer = new ScummBinaryWriter(outStream, 0x69))
                {
                    
                }
            }
        }

        private void Write(ScummBinaryWriter writer, ScummFile file)
        {
        }
    }

    internal class ScummBinaryWriter : BinaryWriter
    {
        private byte _xorKey;

        public ScummBinaryWriter(Stream output, byte xorKey) : base(output)
        {
            _xorKey = xorKey;
        }

    }
}
using System.Collections.Generic;
using System.IO;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class FileReader
    {
        public ScummFile Read(string fileName)
        {
            using (var inputStream = new FileStream(fileName, FileMode.Open))
            {
                using (var reader = new ScummBinaryReader(inputStream, 0x69))
                {
                    return Read(reader);
                }
            }
        }

        private ScummFile Read(ScummBinaryReader reader)
        {
            var result = new ScummFile
            {
                Header = reader.ReadBlockHeader(),
                LoffBlock = (LoffBlock)new LoffReader().Read(reader),
                LflfBlocks = ReadLflfRecords(reader)
            };

            return result;
        }

        private static List<LflfBlock> ReadLflfRecords(ScummBinaryReader reader)
        {
            var list = new List<LflfBlock>();
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                list.Add(new LflfReader().Read(reader));
            }
            return list;
        }
    }
}
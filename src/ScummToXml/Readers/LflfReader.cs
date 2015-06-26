using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class LflfReader
    {
        private class UnexpectedBlockException : Exception
        {
            public UnexpectedBlockException(string blockName)
                : base(string.Format("Unexpected block " + blockName))
            { }
        }

        private class DuplicateBlockException : Exception
        {
            public DuplicateBlockException(string blockName)
                : base(string.Format("Duplicate block " + blockName))
            { }
        }

        public LflfBlock Read(ScummBinaryReader reader)
        {
            var result = new LflfBlock
            {
                Header = reader.ReadBlockHeader()
            };

            long endIndex = reader.BaseStream.Position + result.Header.ContentLength;
            while (reader.BaseStream.Position < endIndex)
            {
                var childHeader = reader.ReadBlockHeader();
                switch (childHeader.HeaderName)
                {
                    case "ROOM":
                        if (result.Room != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.Room = new RoomReader().Read(childHeader, reader);
                        break;
                    case "SCRP":
                        result.Scripts.Add(new ScriptReader().Read(childHeader, reader));
                        break;
                    case "SOUN":
                        result.Sounds.Add(new SoundReader().Read(childHeader, reader));
                        break;
                    case "COST":
                        result.Costumes.Add(new CostumeReader().Read(childHeader, reader));
                        break;
                    case "CHAR":
                        result.Charsets.Add(new CharsetReader().Read(childHeader, reader));
                        break;
                    default:
                        throw new UnexpectedBlockException(childHeader.HeaderName);
                }
            }
            return result;
        }
    }
}
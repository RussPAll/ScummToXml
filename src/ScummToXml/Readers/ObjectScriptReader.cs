using System;
using System.IO;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class ObjectScriptReader
    {
        private class UnexpectedObjectScriptBlockException : Exception
        {
            public UnexpectedObjectScriptBlockException(string blockName)
                : base(string.Format("Unexpected block " + blockName + " in Object Script (Obcd) block"))
            { }
        }

        private class DuplicateBlockException : Exception
        {
            public DuplicateBlockException(string blockName)
                : base(string.Format("Duplicate block " + blockName))
            { }
        }

        public ObcdBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            var result = new ObcdBlock
            {
                Header = header
            };

            long endIndex = reader.BaseStream.Position + result.Header.ContentLength;
            while (reader.BaseStream.Position < endIndex)
            {
                var childHeader = reader.ReadBlockHeader();
                switch (childHeader.HeaderName)
                {
                    case "CDHD":
                        //if (result.Room != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        reader.BaseStream.Seek(childHeader.ContentLength, SeekOrigin.Current);
                        break;
                    case "VERB":
                        if (result.Verb != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.Verb = new VerbReader().Read(childHeader, reader);
                        break;
                    case "OBNA":
                        if (result.Name != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        var bytes = reader.ReadBytes((int)childHeader.ContentLength);
                        result.Name = System.Text.Encoding.ASCII.GetString(bytes);
                        result.Name = result.Name.TrimEnd('\0');
                        break;
                    default:
                        throw new UnexpectedObjectScriptBlockException(childHeader.HeaderName);
                }
            }
            return result;
        }
    }
}
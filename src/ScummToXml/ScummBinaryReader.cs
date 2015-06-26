using System;
using System.IO;
using System.Text;
using ScummToXml.Domain;

namespace ScummToXml
{
    public class ScummBinaryReader : BinaryReader
    {
        private readonly byte _xorKey;

        public ScummBinaryReader(Stream input, byte xorKey) : base(input)
        {
            _xorKey = xorKey;
        }

        public ScummBlockHeader ReadBlockHeader()
        {
            var result = new ScummBlockHeader
            {
                HeaderName = ReadHeaderName(),
                ContentLength = ReadContentLength()
            };
            return result;
        }

        private string ReadHeaderName()
        {
            var header = ReadBytes(4);
            return Encoding.ASCII.GetString(header);
        }

        private uint ReadContentLength()
        {
            return ReadUInt32BE() - 8;
        }


        public override byte[] ReadBytes(int count)
        {
            var bytes = base.ReadBytes(count);
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = (byte)((uint)bytes[i] ^ _xorKey);
            return bytes;
        }

        public override byte ReadByte()
        {
            return (byte)(base.ReadByte() ^ _xorKey);
        }

        public override ushort ReadUInt16()
        {
            var bytes = ReadBytes(sizeof(UInt16));
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
        }

        public override uint ReadUInt32()
        {
            var bytes = ReadBytes(sizeof(UInt32));
            if (BitConverter.IsLittleEndian == false)
                Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        public UInt32 ReadUInt32BE()
        {
            var bytes = ReadBytes(sizeof(UInt32));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}
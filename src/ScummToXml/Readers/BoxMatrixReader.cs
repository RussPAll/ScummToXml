using System;
using System.Collections.Generic;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class BoxMatrixReader
    {
        public BoxmBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            var pathList = new List<List<byte>>();

            long endIndex = reader.BaseStream.Position + header.ContentLength;

            List<byte> path = null;
            while (reader.BaseStream.Position < endIndex)
            {
                if (path == null)
                    path = new List<byte>();
                var curByte = reader.ReadByte();
                if (curByte != 0xff)
                {
                    path.Add(curByte);
                }
                else
                {
                    pathList.Add(path);
                    path = null;
                }
            }

            return new BoxmBlock
            {
                Header = header,
                AllPossibleBlockPaths = pathList
            };
        }
    }
}
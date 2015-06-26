using System.Collections.Generic;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class LoffReader
    {
        public ScummBlock Read(ScummBinaryReader reader)
        {
            var header = reader.ReadBlockHeader();
            var numRooms = reader.ReadByte();
            return new LoffBlock
            {
                Header = header,
                NumRooms = numRooms,
                RoomOffsets = ReadRoomOffsets(reader, numRooms)
            };
        }

        private static List<LoffBlock.RoomOffset> ReadRoomOffsets(ScummBinaryReader reader, byte numRooms)
        {
            var result = new List<LoffBlock.RoomOffset>();
            for (int i = 0; i < numRooms; i++)
            {
                var offset = new LoffBlock.RoomOffset
                {
                    RoomId = reader.ReadByte(),
                    Offset = reader.ReadUInt32()
                };
                result.Add(offset);
            }
            return result;
        }
    }
}
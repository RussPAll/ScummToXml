using System.Collections.Generic;

namespace ScummToXml.Domain
{
    public class LoffBlock : ScummBlock
    {
        public class RoomOffset
        {
            public byte RoomId { get; set; }
            public uint Offset { get; set; }
        }

        //public int NoRooms { get; set; }
        public List<RoomOffset> RoomOffsets { get; set; } 
        public byte NumRooms { get; set; }
    }
}
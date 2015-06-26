namespace ScummToXml.Domain
{
    public class RmhdBlock : ScummBlock
    {
        public byte[] Content { get; set; }
        public ushort Width { get; set; }
        public ushort Height { get; set; }
        public ushort NumObjects { get; set; }
    }
}
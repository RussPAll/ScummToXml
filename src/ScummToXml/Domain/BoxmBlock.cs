using System.Collections.Generic;

namespace ScummToXml.Domain
{
    public class BoxmBlock : ScummBlock
    {
        public List<List<byte>> AllPossibleBlockPaths { get; set; }
    }
}
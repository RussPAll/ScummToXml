using System.Collections.Generic;

namespace ScummToXml.Domain
{
    public class ScummFile : ScummBlock
    {
        public ScummFile()
        {
            LflfBlocks = new List<LflfBlock>();
        }

        public LoffBlock LoffBlock { get; set; }
        public IList<LflfBlock> LflfBlocks { get; set; }
    }
}
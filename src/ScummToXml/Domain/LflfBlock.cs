using System.Collections.Generic;

namespace ScummToXml.Domain
{
    public class LflfBlock : ScummBlock
    {
        public LflfBlock()
        {
            Costumes = new List<CostumeBlock>();
            Scripts = new List<ScriptBlock>();
            Sounds = new List<SoundBlock>();
            Charsets = new List<CharsetBlock>();
        }

        public RoomBlock Room { get; set; }
        public List<ScriptBlock> Scripts { get; set; }
        public List<SoundBlock> Sounds { get; set; }
        public List<CostumeBlock> Costumes { get; set; }
        public List<CharsetBlock> Charsets { get; set; }
    }
}
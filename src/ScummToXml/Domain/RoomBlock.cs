using System.Collections.Generic;

namespace ScummToXml.Domain
{
    public class RoomBlock : ScummBlock
    {
        public RoomBlock()
        {
            ObjImages = new List<ObimBlock>();
            ObjectScripts = new List<ObcdBlock>();
            LocalScripts = new List<LscrBlock>();
        }

        public RmhdBlock RoomHeader { get; set; }
        public CyclBlock ColorCycle { get; set; }
        public TrnsBlock Transparent { get; set; }
        public PalsBlock Palette { get; set; }
        public RmimBlock RoomImage { get; set; }
        public List<ObcdBlock> ObjectScripts { get; set; }
        public ExcdBlock ExitScript { get; set; }
        public EncdBlock EntryScript { get; set; }
        public NlscBlock NumScripts { get; set; }
        public List<LscrBlock> LocalScripts { get; set; }
        public BoxdBlock BoxData { get; set; }
        public BoxmBlock BoxMatrix { get; set; }
        public ScalBlock ScaleSlots { get; set; }
        public EpalBlock EgaPalette { get; set; }
        public ClutBlock Clut { get; set; }
        public List<ObimBlock> ObjImages { get; set; }
    }
}

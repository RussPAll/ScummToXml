using System;
using ScummToXml.Domain;

namespace ScummToXml.Readers
{
    public class RoomReader
    {
        private class UnexpectedRoomBlockException : Exception
        {
            public UnexpectedRoomBlockException(string blockName)
                : base(string.Format("Unexpected block " + blockName + " in Room block"))
            { }
        }

        private class DuplicateBlockException : Exception
        {
            public DuplicateBlockException(string blockName)
                : base(string.Format("Duplicate block " + blockName))
            { }
        }

        public RoomBlock Read(ScummBlockHeader header, ScummBinaryReader reader)
        {
            var result = new RoomBlock
            {
                Header = header
            };

            long endIndex = reader.BaseStream.Position + result.Header.ContentLength;
            while (reader.BaseStream.Position < endIndex)
            {
                var childHeader = reader.ReadBlockHeader();
                switch (childHeader.HeaderName)
                {
                    case "RMHD":
                        if (result.RoomHeader != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.RoomHeader = new RoomHeaderReader().Read(childHeader, reader);
                        break;
                    case "EPAL":
                        if (result.EgaPalette != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.EgaPalette = new EgaPaletteReader().Read(childHeader, reader);
                        break;
                    case "CLUT":
                        if (result.Clut != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.Clut = new ClutReader().Read(childHeader, reader);
                        break;
                    case "CYCL":
                        if (result.ColorCycle != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.ColorCycle = new ColorCycleReader().Read(childHeader, reader);
                        break;
                    case "TRNS":
                        if (result.Transparent != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.Transparent = new TransparentReader().Read(childHeader, reader);
                        break;
                    case "PALS":
                        if (result.Palette != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.Palette = new PaletteReader().Read(childHeader, reader);
                        break;
                    case "RMIM":
                        if (result.RoomImage != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.RoomImage = new RoomImageReader().Read(childHeader, reader);
                        break;
                    case "OBIM":
                        result.ObjImages.Add(new ObjImageReader().Read(childHeader, reader));
                        break;
                    case "OBCD":
                        result.ObjectScripts.Add(new ObjectScriptReader().Read(childHeader, reader));
                        break;
                    case "EXCD":
                        if (result.ExitScript != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.ExitScript = new ExitScriptReader().Read(childHeader, reader);
                        break;
                    case "ENCD":
                        if (result.EntryScript != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.EntryScript = new EntryScriptReader().Read(childHeader, reader);
                        break;
                    case "NLSC":
                        if (result.NumScripts != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.NumScripts = new NumScriptsReader().Read(childHeader, reader);
                        break;
                    case "LSCR":
                        result.LocalScripts.Add(new LocalScriptReader().Read(childHeader, reader));
                        break;
                    case "BOXD":
                        if (result.BoxData != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.BoxData = new BoxDataReader().Read(childHeader, reader);
                        break;
                    case "BOXM":
                        if (result.BoxMatrix != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.BoxMatrix = new BoxMatrixReader().Read(childHeader, reader);
                        break;
                    case "SCAL":
                        if (result.ScaleSlots != null) throw new DuplicateBlockException(childHeader.HeaderName);
                        result.ScaleSlots = new ScaleSlotsReader().Read(childHeader, reader);
                        break;
                    default:
                        throw new UnexpectedRoomBlockException(childHeader.HeaderName);
                }
            }
            return result;
        }
    }
}
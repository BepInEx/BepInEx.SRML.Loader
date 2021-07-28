using MonomiPark.SlimeRancher.Persist;
using System.IO;

namespace SRML.SR.Options
{
    internal class ModOptionsV01 : PersistedDataSet
    {
        public BindingsV05 bindings = new BindingsV05();

        public override string Identifier => "SRMLOP";

        public override uint Version => 1;

        public override void LoadData(BinaryReader reader)
        {
            bindings.Load(reader.BaseStream);
        }

        public override void WriteData(BinaryWriter writer)
        {
            bindings.Write(writer.BaseStream);
        }

    }
}

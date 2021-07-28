using MonomiPark.SlimeRancher.Persist;
using SRML.SR.SaveSystem.Data.Partial;
using SRML.Utils;
using System.IO;
using System.Linq;

namespace SRML.SR.SaveSystem.Data.Gadget
{
    internal class PartialGordoData : VersionedPartialData<GordoV01>
    {
        public PartialCollection<Identifiable.Id> fashions = new PartialCollection<Identifiable.Id>(ModdedIDRegistry.IsModdedID, SerializerPair.GetEnumSerializerPair<Identifiable.Id>());

        public override int LatestVersion => 0;

        public override void Pull(GordoV01 data)
        {
            fashions.Pull(data.fashions);
        }

        public override void Push(GordoV01 data)
        {
            while (fashions.InternalList.Contains(Identifiable.Id.NONE)) fashions.InternalList.Remove(Identifiable.Id.NONE);
            fashions.Push(data.fashions);
        }

        public override void ReadData(BinaryReader reader)
        {
            fashions.Read(reader);
        }

        public override void WriteData(BinaryWriter writer)
        {
            fashions.Write(writer);
        }

        static PartialGordoData()
        {
            EnumTranslator.RegisterEnumFixer<PartialGordoData>((translator, mode, data) =>
            {
                translator.FixEnumValues(mode, data.fashions);
            });

            CustomChecker.RegisterCustomChecker<GordoV01>((x) =>
            {
                if (x.fashions.Any(ModdedIDRegistry.IsModdedID)) return CustomChecker.CustomLevel.PARTIAL;
                return CustomChecker.CustomLevel.NONE;
            });
            PartialData.RegisterPartialData(() => new PartialGordoData());
        }
    }
}

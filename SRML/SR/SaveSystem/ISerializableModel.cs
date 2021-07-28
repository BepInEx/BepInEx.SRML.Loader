using System.IO;

namespace SRML.SR.SaveSystem
{
    public interface ISerializableModel
    {
        void WriteData(BinaryWriter writer);
        void LoadData(BinaryReader reader);
    }
}

using System.IO;

namespace SRML.SR.SaveSystem
{
    interface ISerializable
    {
        void Write(BinaryWriter writer);
        void Read(BinaryReader reader);
    }
}

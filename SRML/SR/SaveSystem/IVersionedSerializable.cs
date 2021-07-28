namespace SRML.SR.SaveSystem
{
    interface IVersionedSerializable : ISerializable
    {
        int LatestVersion { get; }
        int Version { get; }
    }
}

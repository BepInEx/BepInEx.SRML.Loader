namespace SRML.SR.Translation
{
    interface ITranslatable<T>
    {
        T Key { get; }
        string StringKey { get; }
    }
}

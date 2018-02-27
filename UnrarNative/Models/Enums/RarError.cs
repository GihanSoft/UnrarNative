namespace Gihan.UnrarNative.Models.Enums
{
    public enum RarError : uint
    {
        Success = 0,
        EndOfArchive = 10,
        InsufficientMemory = 11,
        BadData = 12,
        BadArchive = 13,
        UnknownFormat = 14,
        OpenError = 15,
        CreateError = 16,
        CloseError = 17,
        ReadError = 18,
        WriteError = 19,
        BufferTooSmall = 20,
        UnknownError = 21,
        MissingPassword = 22,
        RefrenceError = 23,
        BadPassword = 24
    }
}
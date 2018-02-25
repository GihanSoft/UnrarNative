namespace UnrarNative.Models.Enums
{
    public enum RarError : uint
    {
        Success = 0,
        EndOfArchive = 10,
        /// <summary>
        /// Not enough memory to initialize data structures
        /// </summary>
        InsufficientMemory = 11,
        BadData = 12,
        BadArchive = 13,
        /// <summary>
        /// Unknown encryption used for archive headers 
        /// </summary>
        UnknownFormat = 14,
        /// <summary>
        /// File open error
        /// </summary>
        OpenError = 15,
        CreateError = 16,
        CloseError = 17,
        ReadError = 18,
        WriteError = 19,
        /// <summary>
        /// Buffer is too small, comments are not read completely.
        /// </summary>
        BufferTooSmall = 20,
        UnknownError = 21,
        MissingPassword = 22,
        RefrenceError = 23,
        /// <summary>
        /// Entered password is invalid. This code is returned only for archives in RAR 5.0 format
        /// </summary>
        BadPassword = 24
    }
}

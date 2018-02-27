namespace Gihan.UnrarNative.Models.Enums
{
    public enum HashType : uint
    {
        /// <summary>
        /// no checksum or unknown hash function type
        /// </summary>
        None = 0,

        CRC32 = 1,

        /// <summary>
        /// BLAKE2sp
        /// </summary>
        BLACK2 = 2
    }
}
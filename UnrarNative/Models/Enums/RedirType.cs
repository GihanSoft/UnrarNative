namespace Gihan.UnrarNative.Models.Enums
{
    public enum RedirType : uint
    {
        /// <summary>
        /// No redirection, usual file.
        /// </summary>
        NoRedir = 0,

        /// <summary>
        /// Unix symbolic link
        /// </summary>
        UnixSymbolic = 1,

        /// <summary>
        /// Windows symbolic link
        /// </summary>
        WinSymbolic = 2,

        /// <summary>
        /// Windows junction
        /// </summary>
        WinJunction = 3,

        /// <summary>
        /// Hard link
        /// </summary>
        Hard = 4,

        /// <summary>
        /// File reference saved with -oi switch
        /// </summary>
        Ref = 5
    }
}
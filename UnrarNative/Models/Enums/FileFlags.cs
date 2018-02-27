using System;

namespace Gihan.UnrarNative.Models.Enums
{
    [Flags]
    public enum FileFlags : uint
    {
        /// <summary>
        /// File continued from previous volume
        /// </summary>
        SplitBefore = 0x01,

        /// <summary>
        /// File continued on next volume
        /// </summary>
        SplitAfter = 0x02,

        /// <summary>
        /// File encrypted with password
        /// </summary>
        Encrypted = 0x04,

        /// <summary>
        /// Previous files data is used (solid flag)
        /// </summary>
        Solid = 0x10,

        /// <summary>
        /// Directory entry
        /// </summary>
        Directory = 0x20
    }
}
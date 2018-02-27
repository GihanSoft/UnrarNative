using System;

namespace Gihan.UnrarNative.Models.Enums
{
    [Flags]
    public enum ArchiveFlags : uint
    {
        /// <summary>
        /// Volume attribute (archive volume)
        /// </summary>
        Volume = 0x1,

        /// <summary>
        /// Archive comment present
        /// </summary>
        CommentPresent = 0x2,

        /// <summary>
        /// Archive lock attribute
        /// </summary>
        Lock = 0x4,

        /// <summary>
        /// Solid attribute (solid archive)
        /// </summary>
        SolidArchive = 0x8,

        /// <summary>
        /// New volume naming scheme ('volname.partN.rar')
        /// </summary>
        NewNamingScheme = 0x10,

        /// <summary>
        /// Authenticity information present
        /// </summary>
        AuthenticityPresent = 0x20,

        /// <summary>
        /// Recovery record present
        /// </summary>
        RecoveryRecordPresent = 0x40,

        /// <summary>
        /// Block headers are encrypted
        /// </summary>
        EncryptedHeaders = 0x80,

        /// <summary>
        /// 0x0100  - First volume (set only by RAR 3.0 and later)
        /// </summary>
        FirstVolume = 0x100
    }
}
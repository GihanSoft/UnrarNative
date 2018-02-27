using System.Runtime.InteropServices;
using Gihan.UnrarNative.Models.Enums;

namespace Gihan.UnrarNative.Models
{
    /// <summary>
    /// This structure is used by RARReadHeaderEx function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RARHeaderDataEx
    {
        /// <summary>
        /// contains a zero terminated string of the current archive name.
        /// May be used to determine the current volume name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public readonly string ArcName;

        /// <summary>
        /// contains a zero terminated string of the current archive name in Unicode.
        /// May be used to determine the current volume name.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public readonly string ArcNameW;

        /// <summary>
        /// which contains a zero terminated string of the file name in OEM (DOS) encoding.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public readonly string FileName;

        /// <summary>
        /// which contains a zero terminated string of the file name in Unicode.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public readonly string FileNameW;

        /// <summary>
        /// file flags
        /// </summary>
        public readonly FileFlags Flags;

        /// <summary>
        /// Lower 32 bits of packed file size.
        /// If file is split between volumes,
        /// it contains the lower 32 bits of file part size.
        /// </summary>
        public readonly uint PackSize;

        /// <summary>
        /// Higher 32 bits of packed file size.
        /// If file is split between volumes,
        /// it contains the higher 32 bits of file part size.
        /// </summary>
        public readonly uint PackSizeHigh;

        /// <summary>
        /// Lower 32 bits of unpacked file size.
        /// </summary>
        public readonly uint UnpSize;

        /// <summary>
        /// Higher 32 bits of unpacked file size.
        /// </summary>
        public readonly uint UnpSizeHigh;

        /// <summary>
        /// Operating system used to create the archive.
        /// </summary>
        public readonly HostOS HostOS;

        /// <summary>
        /// contains unpacked file CRC32.
        /// In case of file parts split between volumes
        /// only the last part contains the correct CRC and
        /// it is accessible only in <see cref="OpenMode.ListIncsplit"/> listing mode.
        /// </summary>
        public readonly uint FileCRC;

        /// <summary>
        /// Contains the file modification date and time in standard MS DOS format.
        /// </summary>
        public readonly uint FileTime;

        /// <summary>
        /// RAR version needed to extract file. It is encoded as 10 * Major version + minor version.
        /// </summary>
        public readonly uint UnpVer;

        /// <summary>
        /// Packing method.
        /// </summary>
        public readonly PackingMethod Method;

        /// <summary>
        /// File attributes.
        /// </summary>
        public readonly uint FileAttr;

        /// <summary>
        /// Points to the buffer for file comment.
        /// <para>
        ///     File comment support is not implemented in current unrar.dll version.
        ///     Appropriate parameters are preserved only for compatibility with older versions.
        /// </para>
        /// <para>
        /// Set this field to NULL. use <see cref="RARHeaderDataEx.Initialize()"/>
        /// </para>
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string CmtBuf;

        /// <summary>
        /// Size of buffer for file comments.
        /// <para>
        /// File comment support is not implemented in current unrar.dll version.
        /// </para>
        /// <para>
        /// Set this field to 0. use <see cref="RARHeaderDataEx.Initialize()"/>
        /// </para>
        /// </summary>
        public uint CmtBufSize;

        /// <summary>
        /// Size of file comment read into buffer.
        /// <para>
        /// File comment support is not implemented in current unrar.dll version.
        /// Always equal to 0.
        /// </para>
        /// </summary>
        public readonly uint CmtSize;

        /// <summary>
        /// State of file comment.
        /// <para>
        /// File comment support is not implemented in current unrar.dll version.
        /// Always equal to 0.
        /// </para>
        /// </summary>
        public readonly uint CmtState;

        /// <summary>
        /// Size of file compression dictionary in kilobytes.
        /// </summary>
        public readonly uint DictSize;

        /// <summary>
        /// Type of hash function used to protect file data integrity.
        /// </summary>
        public readonly HashType HashType;

        /// <summary>
        /// If <see cref="RARHeaderDataEx.HashType"/> == <see cref="HashType.BLACK2"/>,
        /// this array contains 32 bytes of file data BLAKE2sp hash.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public readonly string Hash;

        /// <summary>
        /// Type of file system redirection.
        /// </summary>
        public readonly RedirType RedirType;

        /// <summary>
        /// Pointer to buffer to receive file system redirection target name,
        /// such as target of symbolic link or file reference.
        ///
        /// It is returned as stored in archive and
        /// its value might be not immediately applicable for further use.
        ///
        /// For example, you may need to remove \??\ or UNC\ prefixes for Windows junctions or
        /// prepend the extraction destination path.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string RedirName;

        /// <summary>
        /// Size of buffer specified in <see cref="RedirName"/>.
        /// Ignored if <see cref="RedirName"/> is null.
        /// </summary>
        public uint RedirNameSize;

        /// <summary>
        ///  Non-zero if <see cref="RedirType"/> is symbolic link and
        ///  <see cref="RedirName"/> points to directory.
        /// </summary>
        public readonly uint DirTarget;

        /// <summary>
        /// Low 32 bit values of file modification time
        /// in Windows FILETIME format in Coordinated Universal Time (UTC).
        /// If appropriate file time is not stored in archive, it's set to 0.
        /// </summary>
        public readonly uint MtimeLow;

        /// <summary>
        /// High 32 bit values of file modification time
        /// in Windows FILETIME format in Coordinated Universal Time (UTC).
        /// If appropriate file time is not stored in archive, it's set to 0.
        /// </summary>
        public readonly uint MtimeHigh;

        /// <summary>
        /// Low 32 bit values of file creation time
        /// in Windows FILETIME format in Coordinated Universal Time (UTC).
        /// If appropriate file time is not stored in archive, it's set to 0.
        /// </summary>
        public readonly uint CtimeLow;

        /// <summary>
        /// High 32 bit values of file creation time
        /// in Windows FILETIME format in Coordinated Universal Time (UTC).
        /// If appropriate file time is not stored in archive, it's set to 0.
        /// </summary>
        public readonly uint CtimeHigh;

        /// <summary>
        /// Low 32 bit values of file last access time
        /// in Windows FILETIME format in Coordinated Universal Time (UTC).
        /// If appropriate file time is not stored in archive, it's set to 0.
        /// </summary>
        public readonly uint AtimeLow;

        /// <summary>
        /// High 32 bit values of file last access time
        /// in Windows FILETIME format in Coordinated Universal Time (UTC).
        /// If appropriate file time is not stored in archive, it's set to 0.
        /// </summary>
        public readonly uint AtimeHigh;

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 988)]
        public uint[] Reserved;

        public void Initialize()
        {
            this.CmtBuf = null;
            this.CmtBufSize = 0;
        }
    }
}
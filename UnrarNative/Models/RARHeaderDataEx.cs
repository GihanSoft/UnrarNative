using System.Runtime.InteropServices;
using UnrarNative.Models.Enums;

namespace UnrarNative.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct RARHeaderDataEx
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string ArcName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string ArcNameW;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string FileName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
        public string FileNameW;
        public ArchiveFlags Flags;
        public uint PackSize;
        public uint PackSizeHigh;
        public uint UnpSize;
        public uint UnpSizeHigh;
        public HostOS HostOS;
        public uint FileCRC;
        public uint FileTime;
        public uint UnpVer;
        public PackingMethod Method;
        public uint FileAttr;
        [MarshalAs(UnmanagedType.LPStr)]
        public string CmtBuf;
        public uint CmtBufSize;
        public uint CmtSize;
        public uint CmtState;

        public uint DictSize;
        public uint HashType;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string Hash;
        public uint RedirType;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string RedirName;
        public uint RedirNameSize;
        public uint DirTarget;
        public uint MtimeLow;
        public uint MtimeHigh;
        public uint CtimeLow;
        public uint CtimeHigh;
        public uint AtimeLow;
        public uint AtimeHigh;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 988)]
        public uint[] Reserved;

        public void Initialize()
        {
            this.CmtBuf = new string((char)0, 65536);
            this.CmtBufSize = 65536;
        }
    }
}

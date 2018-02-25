using System.Runtime.InteropServices;
using UnrarNative.Models.Enums;

namespace UnrarNative.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RAROpenArchiveDataEx
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string ArcName;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ArcNameW;
        public OpenMode OpenMode;
        public RarError OpenResult;
        [MarshalAs(UnmanagedType.LPStr)]
        public string CmtBuf;
        public uint CmtBufSize;
        public uint CmtSize;
        public uint CmtState;
        public ArchiveFlags Flags;
        [MarshalAs(UnmanagedType.FunctionPtr)]
        public Unrar.UNRARCallback Callback;
        public long UserData;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public uint[] Reserved;

        public void Initializ()
        {
            this.CmtBuf = new string((char)0, 65536);
            this.CmtBufSize = 65536;
            this.Reserved = new uint[28];
        }
    }
}

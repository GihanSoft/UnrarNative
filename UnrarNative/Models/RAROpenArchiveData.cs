using System.Runtime.InteropServices;
using UnrarNative.Models.Enums;

namespace UnrarNative.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RAROpenArchiveData
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string ArcName;
        public OpenMode OpenMode;
        public RarError OpenResult;
        [MarshalAs(UnmanagedType.LPStr)]
        public string CmtBuf;
        public uint CmtBufSize;
        public uint CmtSize;
        public uint CmtState;

        public void Initialize()
        {
            this.CmtBuf = new string((char)0, 65536);
            this.CmtBufSize = 65536;
        }
    }
}
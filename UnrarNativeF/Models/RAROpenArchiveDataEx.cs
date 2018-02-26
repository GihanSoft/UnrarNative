using System.Runtime.InteropServices;
using UnrarNative.Models.Enums;

namespace UnrarNative.Models
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RAROpenArchiveDataEx
    {
        /// <summary>
        /// It should point to zero terminated string containing the archive name or 
        /// null if only Unicode name is specified. 
        /// </summary>
        [MarshalAs(UnmanagedType.LPStr)]
        public string ArcName;

        /// <summary>
        /// should point to zero terminated Unicode string containing the archive name or 
        /// null if Unicode name is not specified. 
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string ArcNameW;


        public OpenMode OpenMode;
        
        public readonly RarError OpenResult;
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

using System;
using System.Runtime.InteropServices;
using UnrarNative.Models;
using UnrarNative.Models.Enums;

namespace UnrarNative
{
    public class Unrar
    {
        public delegate int UNRARCallback(CallbackMessages msg, long UserData, IntPtr p1, long p2);
        public delegate IntPtr ChangeVolProc([MarshalAs(UnmanagedType.LPStr)] string ArcName, int Mode);
        public delegate IntPtr ProcessDataProc([MarshalAs(UnmanagedType.LPStr)] string addr, int Size);

        [DllImport("unrar.dll")]
        private static extern IntPtr RAROpenArchive(ref RAROpenArchiveData archiveData);

        [DllImport("unrar.dll")]
        public static extern IntPtr RAROpenArchiveEx(ref RAROpenArchiveDataEx archiveData);

        [DllImport("unrar.dll")]
        public static extern int RARCloseArchive(IntPtr hArcData);

        [DllImport("unrar.dll")]
        public static extern RarError RARReadHeader(IntPtr hArcData, ref RARHeaderData headerData);

        [DllImport("unrar.dll")]
        public static extern RarError RARReadHeaderEx(IntPtr hArcData, ref RARHeaderDataEx headerData);

        [DllImport("unrar.dll")]
        public static extern RarError RARProcessFile(IntPtr hArcData, Operation operation,
            [MarshalAs(UnmanagedType.LPStr)] string destPath,
            [MarshalAs(UnmanagedType.LPStr)] string destName);

        [DllImport("unrar.dll")]
        public static extern RarError RARProcessFileW(IntPtr hArcData, Operation operation,
            [MarshalAs(UnmanagedType.LPWStr)] string destPath,
            [MarshalAs(UnmanagedType.LPWStr)] string destName);

        [DllImport("unrar.dll")]
        public static extern void RARSetCallback(IntPtr hArcData, UNRARCallback callback, long userData);


        [DllImport("unrar.dll")]
        public static extern void RARSetChangeVolProc(IntPtr hArcData, ChangeVolProc ChangeVolProc);

        [DllImport("unrar.dll")]
        public static extern void RARSetProcessDataProc(IntPtr hArcData, ProcessDataProc ProcessDataProc);

        [DllImport("unrar.dll")]
        private static extern void RARSetPassword(IntPtr hArcData,
            [MarshalAs(UnmanagedType.LPStr)] string password);

        [DllImport("unrar.dll")]
        public static extern int RARGetDllVersion();
    }
}

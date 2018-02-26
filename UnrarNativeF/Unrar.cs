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

        /// <summary>
        /// Open RAR archive and allocate memory structures.
        /// <para>
        /// This function is obsolete. It does not support Unicode names and 
        /// does not allow to specify the callback function. 
        /// It is recommended to use <see cref="RAROpenArchiveEx(ref RAROpenArchiveDataEx)"/> instead.
        /// </para>
        /// </summary>
        /// <param name="archiveData">Points to <see cref="RAROpenArchiveData"/> structure. </param>
        /// <returns>Archive handle or NULL in case of error.</returns>
        [DllImport("unrar.dll")]
        public static extern IntPtr RAROpenArchive(ref RAROpenArchiveData archiveData);

        /// <summary>
        /// Open RAR archive and allocate memory structures. 
        /// Replaces the obsolete <see cref="RAROpenArchive(ref RAROpenArchiveData)"/> 
        /// providing more options and Unicode names support.
        /// </summary>
        /// <param name="archiveData">Points to <see cref="RAROpenArchiveDataEx"/> structure.</param>
        /// <returns>Archive handle or NULL in case of error.</returns>
        [DllImport("unrar.dll")]
        public static extern IntPtr RAROpenArchiveEx(ref RAROpenArchiveDataEx archiveData);

        /// <summary>
        /// Close RAR archive and release allocated memory. 
        /// It must be called when archive processing is finished, 
        /// even if the archive processing was stopped due to an error.
        /// </summary>
        /// <param name="hArcData">
        /// This parameter should contain the archive handle obtained from 
        /// <see cref="RAROpenArchive(ref RAROpenArchiveData)"/> or 
        /// <see cref="RAROpenArchiveEx(ref RAROpenArchiveDataEx)"/> function call.
        /// </param>
        /// <returns></returns>
        [DllImport("unrar.dll")]
        public static extern int RARCloseArchive(IntPtr hArcData);

        /// <summary>
        /// Read a file header from archive. 
        /// <para>
        /// This function is obsolete.It does not support Unicode names and 64 bit file sizes.
        /// It is recommended to use <see cref="RARReadHeaderEx(IntPtr, ref RARHeaderDataEx)"/> instead.
        /// </para>
        /// </summary>
        /// <param name="hArcData">
        /// This parameter should contain the archive handle obtained from 
        /// <see cref="RAROpenArchive(ref RAROpenArchiveData)"/> or 
        /// <see cref="RAROpenArchiveEx(ref RAROpenArchiveDataEx)"/> function call. 
        /// </param>
        /// <param name="headerData">Points to <see cref="RARHeaderData"/> structure.</param>
        /// <returns></returns>
        [DllImport("unrar.dll")]
        public static extern RarError RARReadHeader(IntPtr hArcData, ref RARHeaderData headerData);

        /// <summary>
        /// Read a file header from archive.
        /// </summary>
        /// <param name="hArcData">
        /// This parameter should contain the archive handle obtained from 
        /// <see cref="RAROpenArchive(ref RAROpenArchiveData)"/> or 
        /// <see cref="RAROpenArchiveEx(ref RAROpenArchiveDataEx)"/> function call. 
        /// </param>
        /// <param name="headerData">Points to <see cref="RARHeaderDataEx"/> structure.</param>
        /// <returns></returns>
        [DllImport("unrar.dll")]
        public static extern RarError RARReadHeaderEx(IntPtr hArcData, ref RARHeaderDataEx headerData);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hArcData"></param>
        /// <param name="operation"></param>
        /// <param name="destPath"></param>
        /// <param name="destName"></param>
        /// <returns></returns>
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
        public static extern void RARSetPassword(IntPtr hArcData,
            [MarshalAs(UnmanagedType.LPStr)] string password);

        [DllImport("unrar.dll")]
        public static extern int RARGetDllVersion();
    }
}

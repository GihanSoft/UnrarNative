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
        /// Performs the user defined action and moves the current position in the archive to the next file.
        /// <para>
        /// If archive is opened in <see cref="OpenMode.Extract"/> mode, 
        /// this function extracts or tests the current file and sets the archive position to the next file.
        /// </para>
        /// <para>
        /// If open mode is <see cref="OpenMode.List"/>, 
        /// then a call to this function will skip the current file and 
        /// set the archive position to the next file.
        /// </para>
        /// <para>
        /// It is recommended to use <see cref="RARProcessFileW(IntPtr, Operation, string, string)"/>
        /// insted of this function, 
        /// because <see cref="RARProcessFileW(IntPtr, Operation, string, string)"/> supports Unicode.
        /// </para>
        /// </summary>
        /// <param name="hArcData">
        /// This parameter should contain the archive handle obtained from 
        /// <see cref="RAROpenArchive(ref RAROpenArchiveData)"/> or 
        /// <see cref="RAROpenArchiveEx(ref RAROpenArchiveDataEx)"/> function call. 
        /// </param>
        /// <param name="operation"></param>
        /// <param name="destPath">
        /// This parameter should point to a zero terminated string, 
        /// containing the destination directory to place the extracted files to. 
        /// If DestPath is equal to NULL, it means extracting to the current directory. 
        /// This parameter has meaning only if DestName is NULL.
        /// <para>This parameter must be in OEM encoding.</para>
        /// </param>
        /// <param name="destName">
        /// This parameter should point to a zero terminated string, 
        /// containing the full path and name to assign to extracted file or 
        /// it can be NULL to use the default name. 
        /// If DestName is defined (not NULL), 
        /// it overrides both the original file name stored in the archive and 
        /// path specified in DestPath setting.
        /// <para>
        /// This parameter must be in OEM encoding.
        /// </para>
        /// </param>
        /// <returns></returns>
        [DllImport("unrar.dll")]
        public static extern RarError RARProcessFile(IntPtr hArcData, Operation operation,
            [MarshalAs(UnmanagedType.LPStr)] string destPath,
            [MarshalAs(UnmanagedType.LPStr)] string destName);

        /// <summary>
        /// Performs the user defined action and moves the current position in the archive to the next file.
        /// <para>
        /// If archive is opened in <see cref="OpenMode.Extract"/> mode, 
        /// this function extracts or tests the current file and sets the archive position to the next file.
        /// </para>
        /// <para>
        /// If open mode is <see cref="OpenMode.List"/>, 
        /// then a call to this function will skip the current file and 
        /// set the archive position to the next file.
        /// </para>
        /// </summary>
        /// <param name="hArcData">
        /// This parameter should contain the archive handle obtained from 
        /// <see cref="RAROpenArchive(ref RAROpenArchiveData)"/> or 
        /// <see cref="RAROpenArchiveEx(ref RAROpenArchiveDataEx)"/> function call. 
        /// </param>
        /// <param name="operation"></param>
        /// <param name="destPath">
        /// This parameter should point to a zero terminated Unicode string, 
        /// containing the destination directory to place the extracted files to. 
        /// If DestPath is equal to NULL, it means extracting to the current directory. 
        /// This parameter has meaning only if DestName is NULL.
        /// </param>
        /// <param name="destName">
        /// This parameter should point to a zero terminated Unicode string, 
        /// containing the full path and name to assign to extracted file or 
        /// it can be NULL to use the default name. 
        /// If DestName is defined (not NULL), 
        /// it overrides both the original file name stored in the archive and 
        /// path specified in DestPath setting.
        /// </param>
        /// <returns></returns>
        [DllImport("unrar.dll")]
        public static extern RarError RARProcessFileW(IntPtr hArcData, Operation operation,
            [MarshalAs(UnmanagedType.LPWStr)] string destPath,
            [MarshalAs(UnmanagedType.LPWStr)] string destName);

        /// <summary>
        /// Set a user defined <see cref="UNRARCallback"/> function to process UnRAR events.
        /// <para>
        /// <see cref="RARSetCallback(IntPtr, UNRARCallback, long)"/> is obsolete and 
        /// less preferable way to specify the callback function. 
        /// Recommended approach is to set <see cref="RAROpenArchiveDataEx.Callback"/> and 
        /// <see cref="RAROpenArchiveDataEx.UserData"/> when calling RAROpenArchiveEx. 
        /// If you use <see cref="RARSetCallback(IntPtr, UNRARCallback, long)"/>, 
        /// you will not be able to read the archive comment in archives with encrypted headers. 
        /// If you do not need the archive comment, you can continue to use 
        /// <see cref="RARSetCallback(IntPtr, UNRARCallback, long)"/>.
        /// </para>
        /// </summary>
        /// <param name="hArcData">
        /// This parameter should contain the archive handle obtained from 
        /// <see cref="RAROpenArchive(ref RAROpenArchiveData)"/> or 
        /// <see cref="RAROpenArchiveEx(ref RAROpenArchiveDataEx)"/> function call. 
        /// </param>
        /// <param name="callback">
        /// Address of user defined <see cref="UNRARCallback"/> to process UnRAR events.
        /// <para>
        /// Set it to NULL if you do not want to define the callback function. 
        /// Callback function is required to process multivolume and encrypted archives properly.
        /// </para>
        /// </param>
        /// <param name="userData">
        /// User defined value, which will be passed to <see cref="UNRARCallback"/>.
        /// </param>
        [DllImport("unrar.dll")]
        public static extern void RARSetCallback(IntPtr hArcData, UNRARCallback callback, long userData);

        /// <summary>
        /// Obsolete. Use the callback function instead.
        /// </summary>
        /// <param name="hArcData"></param>
        /// <param name="ChangeVolProc"></param>
        [DllImport("unrar.dll")]
        public static extern void RARSetChangeVolProc(IntPtr hArcData, ChangeVolProc ChangeVolProc);

        /// <summary>
        /// Obsolete. Use the callback function instead. 
        /// </summary>
        /// <param name="hArcData"></param>
        /// <param name="ProcessDataProc"></param>
        [DllImport("unrar.dll")]
        public static extern void RARSetProcessDataProc(IntPtr hArcData, ProcessDataProc ProcessDataProc);

        /// <summary>
        /// Set a password to decrypt files.
        /// <para>
        /// This function does not allow to process archives with encrypted headers. 
        /// It can be used only for archives with encrypted file data and unencrypted headers. 
        /// So the recommended way to set a password is <see cref="CallbackMessages.NeedPasswordW"/> 
        /// message in user defined callback function. 
        /// Unlike <see cref="RARSetPassword(IntPtr, string)"/>, 
        /// <see cref="CallbackMessages.NeedPasswordW"/> can be used for all types of encrypted RAR archives.
        /// </para>
        /// </summary>
        /// <param name="hArcData">
        /// This parameter should contain the archive handle obtained from 
        /// <see cref="RAROpenArchive(ref RAROpenArchiveData)"/> or 
        /// <see cref="RAROpenArchiveEx(ref RAROpenArchiveDataEx)"/> function call.
        /// </param>
        /// <param name="password">Zero terminated string containing a password.</param>
        [DllImport("unrar.dll")]
        public static extern void RARSetPassword(IntPtr hArcData,
            [MarshalAs(UnmanagedType.LPStr)] string password);

        /// <summary>
        /// Returns API version.
        /// </summary>
        /// <returns>
        /// Returns an integer value denoting UnRAR.dll API version, 
        /// which is also defined in unrar.h as RAR_DLL_VERSION. 
        /// API version number is incremented only in case of noticeable changes in UnRAR.dll API. 
        /// Do not confuse it with version of UnRAR.dll stored in DLL resources, w
        /// hich is incremented with every DLL rebuild.
        /// <para>
        /// If <see cref="RARGetDllVersion()"/> returns a value lower than UnRAR.dll, 
        /// which your application was designed for, 
        /// it may indicate that DLL version is too old and 
        /// it may fail to provide all necessary functions to your application.
        /// </para>
        /// <para>
        /// This function is missing in very old versions of UnRAR.dll, 
        /// so it is safer to use LoadLibrary and GetProcAddress to access it.
        /// </para>
        /// </returns>
        [DllImport("unrar.dll")]
        public static extern int RARGetDllVersion();
    }
}

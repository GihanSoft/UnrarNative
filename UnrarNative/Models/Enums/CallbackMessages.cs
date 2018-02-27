namespace Gihan.UnrarNative.Models.Enums
{
    public enum CallbackMessages : uint
    {
        /// <summary>
        /// Process volume change.
        /// </summary>
        VolumeChange = 0,

        /// <summary>
        /// Process unpacked data. It can be used to read a file from memory,
        /// while it is being extracted or tested.
        /// If you use this event while testing a file,
        /// then it makes possible to read file data without extracting file to disk.
        /// </summary>
        ProcessData = 1,

        /// <summary>
        /// DLL needs a password to process an archive.
        /// This message must be processed if you wish to be able to handle encrypted archives.
        /// </summary>
        NeedPassword = 2,

        /// <summary>
        /// Process volume change.
        /// </summary>
        ValumeChangeW = 3,

        /// <summary>
        /// DLL needs a password to process an archive.
        /// This message must be processed if you wish to be able to handle encrypted archives.
        /// </summary>
        NeedPasswordW = 4
    }
}
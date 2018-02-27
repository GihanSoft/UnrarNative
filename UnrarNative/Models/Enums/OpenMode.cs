namespace Gihan.UnrarNative.Models.Enums
{
    /// <summary>
    /// Mode in which archive is to be opened for processing.
    /// </summary>
    public enum OpenMode : uint
    {
        /// <summary>
        /// Open archive for listing contents only
        /// </summary>
        List = 0,

        /// <summary>
        /// Open archive for testing or extracting contents
        /// </summary>
        Extract = 1,

        /// <summary>
        /// Open archive for reading file headers only.
        /// If you open an archive in such mode, RARReadHeader[Ex] will return all file headers,
        /// including those with "file continued from previous volume" flag.
        /// In case of <see cref="OpenMode.List"/> such headers are automatically skipped.
        /// So if you process RAR volumes in <see cref="OpenMode.ListIncsplit"/> mode,
        /// you will get several file header records for same file if file is split between volumes.
        /// For such files only the last file header record will contain the correct file CRC and
        /// if you wish to get the correct packed size, you need to sum up packed sizes of all parts.
        /// </summary>
        ListIncsplit = 2
    }
}
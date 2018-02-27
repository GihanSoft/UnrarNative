namespace Gihan.UnrarNative.Models.Enums
{
    public enum Operation : int
    {
        /// <summary>
        /// Move to the next file in the archive.
        /// If archive is solid and <see cref="OpenMode.Extract"/> mode was set when the archive was opened,
        /// the current file is analyzed and operation is performed slower than a simple seek.
        /// </summary>
        Skip = 0,

        /// <summary>
        /// Test the current file and move to the next file in the archive.
        /// If the archive was opened in <see cref="OpenMode.List"/> mode,
        /// the operation is equal to <see cref="Operation.Skip"/>.
        /// </summary>
        Test = 1,

        /// <summary>
        /// Extract the current file and move to the next file in the archive.
        /// If the archive was opened with <see cref="OpenMode.ListIncsplit"/> mode,
        /// the operation is equal to <see cref="Operation.Skip"/>.
        /// </summary>
        Extract = 2
    }
}
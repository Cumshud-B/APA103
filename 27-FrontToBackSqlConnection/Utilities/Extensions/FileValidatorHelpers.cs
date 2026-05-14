using _27_FrontToBackSqlConnection.Utilities.Enums;

namespace _27_FrontToBackSqlConnection.Utilities.Extensions
{
    internal static class FileValidatorHelpers
    {

        public static async bool CheckFileSize(this IFormFile file, FileSize fileSize, int size)
        {
            switch (fileSize)
            {
                case FileSize.KB:
                    if (file.Length <= size * 1024)
                    {
                        return true;
                    }
                    break;
                case FileSize.MB:
                    if (file.Length <= size * 1024 * 1024)
                    {
                        return true;
                    }
                    break;
                case FileSize.GB:
                    if (file.Length <= size * 1024 * 1024 * 1024)
                    {
                        return true;
                    }
                    break;
            }
            return false;
        }
    }
}
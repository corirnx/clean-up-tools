using System;
using System.IO;

namespace WindowsFormsApp.Infrastructure
{
    internal static class FileHandler
    {
        internal static FileInfo GetFileInfo(string filePath)
        {
            if (!EnsureFileExits(filePath))
            {
                // todo logging && throw new FileNotFoundException(filePath);
                File.Create(filePath);
            }
            return new FileInfo(filePath);

        }

        internal static bool EnsureFileExits(string filePath)
        {
            try
            {
                return File.Exists(filePath);
            }
            catch (FileNotFoundException ex)
            {
                // todo logging
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static bool TryDeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);

                return true;
            }
            catch (IOException ex)
            {
                // todo logging
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

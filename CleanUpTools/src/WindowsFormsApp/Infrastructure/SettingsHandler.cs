using System;
using System.IO;

namespace WindowsFormsApp.Infrastructure
{
    internal class SettingsHandler
    {
        FileInfo settingsFile;

        public SettingsHandler()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clean-up-tools.config");

            if (!FileExits(filePath))
                return;

            settingsFile = new FileInfo(filePath);
        }

        bool FileExits(string filePath)
        {
            try
            {
                return File.Exists(filePath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

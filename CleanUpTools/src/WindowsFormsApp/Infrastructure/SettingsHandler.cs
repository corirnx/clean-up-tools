using System;
using System.Collections.Generic;
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
                throw new FileNotFoundException(filePath);

            settingsFile = new FileInfo(filePath);
        }

        internal CleanUpDirectory[] GetDirectories()
        {
            var lines = File.ReadAllLines(settingsFile.FullName);
            var list = new List<CleanUpDirectory>();
            for (int i = 0; i < lines.Length; i++)
            {
                var lineParts = lines[i].Split(';');

                var d = new CleanUpDirectory();

                // todo validate

                d.Directory = new DirectoryInfo(lineParts[0]);

                d.Extension = lineParts[1];

                if (d.Extension.StartsWith("."))
                    d.Extension = d.Extension.Substring(1);

                if (lineParts[2].StartsWith("f", StringComparison.InvariantCultureIgnoreCase))
                    d.Recursive = false;

                if (lineParts[2].StartsWith("t", StringComparison.InvariantCultureIgnoreCase))
                    d.Recursive = true;

                list.Add(d);
            }

            return list.ToArray();
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

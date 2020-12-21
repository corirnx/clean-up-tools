﻿using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp.Infrastructure
{
    internal class SettingsHandler
    {
        FileInfo _settingsFile;

        internal SettingsHandler()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clean-up-tools.config");

            if (!FileExits(filePath))
                throw new FileNotFoundException(filePath);

            _settingsFile = new FileInfo(filePath);
        }

        internal CleanUpDirectory[] GetDirectories()
        {
            var lines = File.ReadAllLines(_settingsFile.FullName);
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

        internal void SaveSettings(string content)
        {
            // validate
            try
            {
                File.WriteAllText(_settingsFile.FullName, content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Add(string directory, string extension, bool isRecursive)
        {
            var content = File.ReadAllText(_settingsFile.FullName);

            content += $"{directory};{extension};{isRecursive};{Environment.NewLine}";

            SaveSettings(content);
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

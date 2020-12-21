using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WindowsFormsApp.Infrastructure
{
    internal class SettingsHandler
    {
        readonly string _seperator;
        readonly FileInfo _settingsFile;

        internal SettingsHandler()
        {
            _seperator = "_;_";
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clean-up-tools.config");

            if (!FileExits(filePath))
                throw new FileNotFoundException(filePath);

            _settingsFile = new FileInfo(filePath);
        }

        internal void Save(string[] lines)
        {
            try
            {
                File.WriteAllText(_settingsFile.FullName, string.Join(_seperator, lines));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal void Add(string directory, string extension, bool isRecursive)
        {
            var lines = Get().ToList();
            lines.Add($"{directory};{extension};{isRecursive};{_seperator}");

            Save(lines.ToArray());
        }

        internal string[] Get()
        {
            var content = File.ReadAllText(_settingsFile.FullName);

            return content.Split(_seperator).Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
        }

        internal void Remove(int index)
        {
            var lines = Get();

            var newList = new List<string>();

            for (int i = 0; i < lines.Length; i++)
                if (i != index)
                    newList.Add(lines[i]);

            Save(newList.ToArray());
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

        bool DirectoryExits(string dirPath)
        {
            try
            {
                return Directory.Exists(dirPath);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using System;
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
            _settingsFile = FileHandler.GetFileInfo(filePath);
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
            if (!FileHandler.EnsureFileExits(_settingsFile.FullName))
                return new string[0];

            var content = File.ReadAllText(_settingsFile.FullName);

            return content.Split(_seperator).Where(t => !string.IsNullOrWhiteSpace(t)).ToArray();
        }

        internal void Remove(string text)
        {
            Save(Get().Where(d => !d.Equals(text, StringComparison.InvariantCultureIgnoreCase)).ToArray());
        }
    }
}

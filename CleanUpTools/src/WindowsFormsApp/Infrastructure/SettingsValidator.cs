using System;
using System.Linq;
using System.IO;

namespace WindowsFormsApp.Infrastructure
{
    internal static class SettingsValidator
    {
        internal static bool ValidateText(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return true;

            var lines = content.Split("\n");

            for (int i = 0; i < lines.Length; i++)
            {
                var valid = ValidateLine(lines[i]);

                if (!valid)
                    return false;
            }

            return true;
        }

        internal static bool ValidateLine(string line)
        {
            var parts = line.Split(';').Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

            if (parts.Length != 3)
                return false; // have to be 3

            if (!ValidateDirectory(parts[0]))
                return false;           
           
            var ext = parts[1];
            // no validation

            var rec = parts[2];
            if (rec.StartsWith("t", StringComparison.InvariantCultureIgnoreCase) || rec.StartsWith("f", StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }

        static bool ValidateDirectory(string text)
        {
            try
            {
                if (Directory.Exists(text))
                    return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
    }
}

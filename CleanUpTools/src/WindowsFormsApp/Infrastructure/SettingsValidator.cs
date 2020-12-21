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

        static bool ValidateLine(string line)
        {
            var parts = line.Split(';').Where(l => !string.IsNullOrWhiteSpace(l)).ToArray();

            if (parts.Length != 3)
                return false; // have to be 3

            try
            {
                if (!Directory.Exists(parts[0]))
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var ext = parts[1];
            // no validation

            var rec = parts[2];
            if (rec.StartsWith("t", StringComparison.InvariantCultureIgnoreCase) || rec.StartsWith("f", StringComparison.InvariantCultureIgnoreCase))
                return true;

            return false;
        }
    }
}

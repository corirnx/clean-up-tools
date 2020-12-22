using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WindowsFormsApp.Infrastructure
{
    internal class CleanUpHandler
    {
        List<string> _infoResultList;
        readonly Stopwatch stopWatch;

        internal CleanUpHandler()
        {
            stopWatch = new Stopwatch();
        }

        internal string[] TryDeleteFiles(string configLine)
        {
            // reset result list info
            _infoResultList = new List<string>();

            // dir;extension;recursive;
            var parts = configLine.Split(';');

            if (!TryDirExists(parts[0]))
                return _infoResultList.ToArray();

            HandleDirectoryInfo(new DirectoryInfo(parts[0]), parts[1], parts[2].StartsWith("t", StringComparison.InvariantCultureIgnoreCase));

            return _infoResultList.ToArray();
        }

        void HandleDirectoryInfo(DirectoryInfo currDir, string extension, bool isRecursive)
        {
            stopWatch.Restart();

            if (!TryDirExists(currDir.FullName))
                return;

            var cnt = TryDeleteFiles(currDir, extension);

            _infoResultList.Add($"{currDir.FullName}: {cnt} files deleted ({stopWatch.ElapsedMilliseconds}ms)");

            if (isRecursive)
                foreach (var dir in currDir.EnumerateDirectories())
                    HandleDirectoryInfo(dir, extension, isRecursive);
        }

        int TryDeleteFiles(DirectoryInfo dirInfo, string extension)
        {
            int cnt = 0;

            foreach (FileInfo fileInfo in dirInfo.EnumerateFiles($"*{extension}").ToArray())
            {
                if (!FileHandler.EnsureFileExits(fileInfo.FullName))
                    continue;

                if (FileHandler.TryDeleteFile(fileInfo.FullName))
                    cnt++;
            }

            return cnt;
        }

        bool TryDirExists(string dirPath)
        {
            try
            {
                return Directory.Exists(dirPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

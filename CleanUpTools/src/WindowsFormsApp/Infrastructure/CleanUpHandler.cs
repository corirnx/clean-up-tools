using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace WindowsFormsApp.Infrastructure
{
    internal class CleanUpHandler
    {
        DirectoryInfo currDirInfo;
        List<string> _infoResultList;
        Stopwatch stopWatch;

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

            if (!TryExits(parts[0]))
                return null;

            currDirInfo = new DirectoryInfo(parts[0]);

            foreach (var currDir in currDirInfo.EnumerateDirectories())
                HandleDirectoryInfo(currDir, parts[1], parts[2].StartsWith("f", StringComparison.InvariantCultureIgnoreCase));

            return _infoResultList.ToArray();
        }

        void HandleDirectoryInfo(DirectoryInfo currDir, string extension, bool isRecursive)
        {
            stopWatch.Restart();

            if (!TryExits(currDir.FullName))
                return;

            var cnt = TryDeleteFiles(currDir, extension);

            _infoResultList.Add($"{currDir.FullName}: {cnt} files deleted ({stopWatch.ElapsedMilliseconds}msc)");

            if (isRecursive)
                foreach (var dir in currDir.EnumerateDirectories())
                    HandleDirectoryInfo(dir, extension, isRecursive);
        }

        int TryDeleteFiles(DirectoryInfo dirInfo, string extension)
        {
            int cnt = 0;

            foreach (FileInfo fileInfo in dirInfo.EnumerateFiles($"*{extension}").ToArray())
            {
                try
                {
                    if (File.Exists(fileInfo.FullName))
                    {
                        //File.Delete(fileInfo.FullName);
                        cnt++;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return cnt;
        }

        bool TryExits(string dirPath)
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

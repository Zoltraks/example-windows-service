using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace WindowsServiceExample
{
    public class Common
    {
        public static string GetBasePath()
        {
            string path = GetBaseDirectory();
            path = IncludeTrailingDirectorySeparator(path);
            return path;
        }

        public static string GetBaseDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            return baseDirectory;
        }

        public static string IncludeTrailingDirectorySeparator(string path)
        {
            if (path == null)
                return null;
            path = path.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
            path += System.IO.Path.DirectorySeparatorChar;
            return path;
        }
    }
}

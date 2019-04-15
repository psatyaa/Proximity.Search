using Proximity.Search.Data.Interfaces;
using System;
using System.IO;

namespace Proximity.Search.Data
{
    public class FileReader : IFileReader
    {
        public string[] ReadFile(string FilePath)
        {
            return File.ReadAllText(FilePath).Split(' ');
        }
    }
}

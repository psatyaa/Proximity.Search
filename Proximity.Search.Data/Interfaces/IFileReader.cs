using System;
using System.Collections.Generic;
using System.Text;

namespace Proximity.Search.Data.Interfaces
{
   public interface IFileReader
    {
        string[] ReadFile(string FileName);
    }
}

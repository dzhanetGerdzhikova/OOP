using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.LogFile
{
   public  interface IFile
    {
        int Size { get; }
        void Write(string message);
    }
}

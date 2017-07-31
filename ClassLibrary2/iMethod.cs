using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryModule
{
    public interface iMethod
    {
        string MethodName { get; set; }
        string MethodReturnType { get; set; }

        Dictionary<string, iMethodParam> Params { get; set; }
    }
}
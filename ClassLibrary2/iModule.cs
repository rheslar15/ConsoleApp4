using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace ClassLibraryModule
{
    public interface iModule
    {
        string ModuleName { get; set; }
        void Process();
        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryModule
{
    public interface iModuleProperty
    {
        string PropertyName { get; set; }
        string PropertyType { get; set; }
        object ProprtyValue { get; set; }
    }
}
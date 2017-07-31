using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModule
{
    public class ModuleProperty : iModuleProperty
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public object ProprtyValue { get; set; }
    }
}

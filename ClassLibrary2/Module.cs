using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModule
{
    public class Module: iModule
    {
        private dynamic expando;
        public Module()
        {
            expando  = new ExpandoObject();
            ModuleName = string.Empty;
        }
        public string ModuleName { get; set; }
        

        public void Process()
        {
            
        }

        public dynamic GetExpando()
        {
            return this.expando;
        }

        
    }
}

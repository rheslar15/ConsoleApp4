using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModule
{
    public class AssemblyCreator
    {
        public AssemblyCreator()
        {
            dynamic expando = new ExpandoObject();
            expando.Name = "Brian";
            expando.Country = "USA";
        }

    }
}

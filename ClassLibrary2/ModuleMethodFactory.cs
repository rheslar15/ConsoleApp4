using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryModule
{
    public class ModuleMethodFactory
    {
        public iMethod Method
        {
            get;
            set;
           
        }

        public void CreateMethod(iModule module, string MethodName, List<iMethodParam> Params, string ReturnType)
        {
            
        }
        public void CreateMethod(iModule module, string MethodName, string ReturnType)
        {

        }
    }
}
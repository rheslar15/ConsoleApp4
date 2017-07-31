using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryModule
{
    public class ModuleMethodFactory
    {
        private static ModuleRepository ModuleRepository = null;

        public static void SetModuleRepository(ModuleRepository repro)
        {
            ModuleRepository = repro;
        }

        public iMethod Method
        {
            get;
            set;
           
        }


        public static void CreateAction(iModule module, Action Action, string methodname)
        {

            if (module != null)
            {
                if (ModuleRepository != null)
                {
                    if (!ModuleRepository.ContainsAction(module.ModuleName, methodname))
                    {
                        var t = (IDictionary<string, object>)(module as Module).GetExpando();

                        if (t != null)
                        {
                            dynamicHelper.AddAction(t, Action, methodname);
                        }

                    }
                }

            }
        }

        public static void CreateAction(iModule module, Action<int> Action, string methodname)
        {

            if (module != null)
            {
                if (ModuleRepository != null)
                {
                    if (!ModuleRepository.ContainsAction(module.ModuleName, methodname))
                    {
                        var t = (IDictionary<string, object>)(module as Module).GetExpando();

                        if (t != null)
                        {
                            dynamicHelper.AddAction(t, Action, methodname);
                        }

                    }
                }

            }

        }

        public static void CreateAction(iModule module, Action<string> Action, string methodname)
        {

            if (module != null)
            {
                if (ModuleRepository != null)
                {
                    if (!ModuleRepository.ContainsAction(module.ModuleName, methodname))
                    {
                        var t = (IDictionary<string, object>)(module as Module).GetExpando();

                        if (t != null)
                        {
                            dynamicHelper.AddAction(t, Action, methodname);
                        }

                    }
                }

            }

        }

        public static void CreateMethod(iModule module, Func<string> method, string methodname, string type)
        {
            if (module != null)
            {
                if (ModuleRepository != null)
                {
                    if (!ModuleRepository.ContainsMethod(module, methodname, type))
                    {
                        var t = (IDictionary<string, object>)(module as Module).GetExpando();

                        if (t != null)
                        {
                            dynamicHelper.AddMethod(t, method, methodname);
                        }
                    }
                }
            }
        }

        public static void CreateMethod(iModule module, Func<int> method, string methodname, string type)
        {
            if (module != null)
            {
                if (ModuleRepository != null)
                {
                    if (!ModuleRepository.ContainsMethod(module, methodname, type))
                    {
                        var t = (IDictionary<string, object>)(module as Module).GetExpando();

                        if (t != null)
                        {
                            dynamicHelper.AddMethod(t, method, methodname);
                        }
                    }
                }
            }
        }
    }
}
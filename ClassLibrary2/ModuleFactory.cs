using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryModule
{
    public static class ModuleFactory
    {
        public static void SetModuleRepository(ModuleRepository Repro)
        {
            if (Repro != null)
            {
                ModuleRepository = Repro;
            }
        }

        public static ModuleRepository GetModuleRepository()
        {
            if (ModuleRepository == null)
            {
                ModuleRepository = new ModuleRepository();
            }

            return ModuleRepository;
        }

        private static iModule Module = null;
       

        private static ModuleRepository ModuleRepository = null;

        public static void CreateModule(string ModuleName)
        {
            if (ModuleRepository != null)
            {
                Module = new Module() { ModuleName = ModuleName };

                if (!ModuleRepository.Modules.ContainsKey(ModuleName))
                {
                    ModuleRepository.Modules.Add(ModuleName, Module);
                }
            }
        }

        public static iModule GetModuleInst()
        {
            return Module;
        }

        
    }
}
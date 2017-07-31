using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryModule
{
    public static class ModulePropertyFactory
    {
        private static iModuleProperty Property = null;
        private static iModule module = null;
        private static ModuleRepository ModuleRepository = null;

        public static void SetModuleRespoitory(ModuleRepository Repository)
        {
            ModuleRepository = Repository;
        }
        public static void CreateProperty(string ModuleName, string PropertyName, string PropertyType, object PropertyValue)
        {
            if (ModuleRepository != null)
            {
                module = ModuleRepository.GetModuleByName(ModuleName);

                if (module != null)
                {
                    if (!ModuleRepository.ContainsProprty(ModuleName, PropertyName))
                    {
                        if (PropertyType == "string")
                        {
                           var expando =  (module as Module).GetExpando();

                            if (expando != null)
                            {

                                dynamicHelper.AddProperty(expando, PropertyName, PropertyValue);

                               
                            }
                        }
                    }
                //    Property = new ModuleProperty() { PropertyName = PropertyName, PropertyType = PropertyType, ProprtyValue = PropertyValue };

                //    if (!module.Properties.ContainsKey(PropertyName))
                //    {
                //        module.Properties.Add(PropertyName, Property);
                //    }
                }
            }
        }

        public static void CreateProperty(iModule Module, string PropertyName, string PropertyType, object PropertyValue)
        {
            if (Module != null)
            {
                //Property = new ModuleProperty() { PropertyName = PropertyName, PropertyType = PropertyType, ProprtyValue = PropertyValue };

                //if (!module.Properties.ContainsKey(PropertyName))
                //{
                //    module.Properties.Add(PropertyName, Property);
                //}
            }
        }

        public static  void CreateProperty(iModule Module, string PropertyName, string PropertyType)
        {
            //Property = new ModuleProperty() { PropertyName = PropertyName, PropertyType = PropertyType, ProprtyValue = null };

            //if (!module.Properties.ContainsKey(PropertyName))
            //{
            //    module.Properties.Add(PropertyName, Property);
            //}
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryModule
{
    public class ModuleRepository
    {
        public ModuleRepository()
        {
            Modules = new Dictionary<string, iModule>();
        }
        public Dictionary<string, iModule> Modules { get; set; }

        public iModule GetModuleByName(string Name)
        {
            if (Modules != null)
            {
                if (Modules.ContainsKey(Name))
                {
                    var module = Modules[Name];

                    return module;
                }
            }
            return null;
        }

        public bool ContainsProperty(iModule module, string PropertyName, string type)
        {

            if (Modules != null)
            {
                var Module = GetModuleByName(module.ModuleName);


                if (Module != null)
                {
                    var t = (IDictionary<string, object>)(Module as Module).GetExpando();

                    if (t != null)
                    {
                        var contians = dynamicHelper.ContainsProperty(t, PropertyName, type);

                        return contians;
                    }
                }
                
            }
            return false;
        }

        public bool ContainsAction(iModule module, string ActionName)
        {

            if (Modules != null)
            {
                var Module = GetModuleByName(module.ModuleName);


                if (Module != null)
                {
                    var t = (IDictionary<string, object>)(Module as Module).GetExpando();

                    if (t != null)
                    {
                        var contians = dynamicHelper.ContainsAction(t, ActionName);

                        return contians;
                    }
                }
            }
            return false;
        }

        public bool ContainsMethod(iModule module, string methodname, string type)
        {
            if (Modules != null)
            {
                var Module = GetModuleByName(module.ModuleName);


                if (Module != null)
                {
                    var t = (IDictionary<string, object>)(Module as Module).GetExpando();

                    if (t != null)
                    {
                        var contians = dynamicHelper.ContainsMethod(t, methodname, type);

                        return contians;
                    }
                }

            }
            return false;
        }

        public bool ContainsAction(string ModuleName, string ActionName)
        {

            if (Modules != null)
            {
                var Module = GetModuleByName(ModuleName);


                if (Module != null)
                {
                    var t = (IDictionary<string, object>)(Module as Module).GetExpando();

                    if (t != null)
                    {
                        var contians = dynamicHelper.ContainsAction(t, ActionName);

                        return contians;
                    }
                }
            }
            return false;
        }

        public bool ContainsProprty(string ModuleName, string PropertyName)
        {
            if (Modules != null)
            {
                var Module = GetModuleByName(ModuleName);

                if (Module != null)
                {
                    var t = (IDictionary<string, object>)(Module as Module).GetExpando();

                    if (t != null && t.Keys.Count > 0 && t.Keys.FirstOrDefault() == PropertyName)
                    {
                        return true;
                    }
                    else
                        return false;
                }

            }
            return false;
        }

        public IDictionary<string, object> GetExpando(iModule module)
        {
            var t = (IDictionary<string, object>)(module as Module).GetExpando();

            return t;
        }

        public iModuleProperty GetPropertyByName(string ModuleName, string PropertyName, string type)
        {
            if (Modules != null)
            {
                var Module = GetModuleByName(ModuleName);

                if (Module != null)
                {
                    var t = (IDictionary<string, object>)(Module as Module).GetExpando();

                    if (t != null && t.Keys.Count > 0 && t.Keys.FirstOrDefault() == PropertyName)
                    {
                        if (type == "string")
                        {
                            object s = string.Empty;
                            var r = t.TryGetValue(PropertyName, out s);

                            if (r)
                            {
                                var v = s.GetType().Name;


                                if (v !=  null)
                                {
                                    var str = System.String.Empty;

                                    if (str.GetType().Name == v)
                                    {
                                        var iModuleProperty = new ModuleProperty() { PropertyName = PropertyName, PropertyType = type, ProprtyValue = s };

                                        return iModuleProperty;
                                    }
                                    //return prop;
                                }

                                
                            }
                        }


                    }
                }
            }
            return null;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;

namespace ClassLibraryModule
{
    public static class dynamicHelper
    {
        public static ExpandoObject convertToExpando(object obj)
        {
            //Get Properties Using Reflections
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = obj.GetType().GetProperties(flags);

            //Add Them to a new Expando
            ExpandoObject expando = new ExpandoObject();
            foreach (PropertyInfo property in properties)
            {
                AddProperty(expando, property.Name, property.GetValue(obj));
            }

            return expando;
        }

        public static void AddProperty(ExpandoObject expando, string propertyName, object propertyValue)
        {
            //Take use of the IDictionary implementation
            var expandoDict = expando as IDictionary<string, Object>;
            if (expandoDict != null)
            {
                if (expandoDict.ContainsKey(propertyName))
                    expandoDict[propertyName] = propertyValue;
                else
                    expandoDict.Add(propertyName, propertyValue);
            }
        }

        public static bool ContainsAction(IDictionary<string, Object> expandoDict, string ActionName)
        {
            if (expandoDict.ContainsKey(ActionName))
            {
                object s = string.Empty;
                var r = expandoDict.TryGetValue(ActionName, out s);

                if (r)
                {
                    var t = s.GetType().Name;

                    if (t != null)
                    {
                        if (t.Contains("Action"))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static bool ContainsMethod(IDictionary<string, Object> expandoDict, string methodname, string type)
        {
            if (expandoDict.ContainsKey(methodname))
            {
                if (type == "string")
                {
                    object s = string.Empty;
                    var r = expandoDict.TryGetValue(methodname, out s);
                    if (r)
                    {
                        var v = s.GetType().Name;

                        if (v != null)
                        {
                            if (v.Contains("Func"))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool ContainsProperty(IDictionary<string, Object> expandoDict, string propertyName, string type)
        {
            if (expandoDict.ContainsKey(propertyName))
            {

                if (type == "string")
                {
                    object s = string.Empty;
                    var r = expandoDict.TryGetValue(propertyName, out s);

                    if (r)
                    {
                        var v = s.GetType().Name;


                        if (v != null)
                        {
                            var str = System.String.Empty;

                            if (str.GetType().Name == v)
                            {
                                return true;
                            }
                        }
                    }
                }
               
            }
            return false;
        }

        public static void AddAction(IDictionary<string, Object> expandoDict, Action Action, string methodname)
        {


            if (expandoDict != null)
            {
                expandoDict.Add(methodname, Action);
            }
        }

        public static void AddAction(IDictionary<string, Object> expandoDict, Action<int> Action, string methodname)
        {


            if (expandoDict != null)
            {
                expandoDict.Add(methodname, Action);
            }
        }

        public static void AddAction(IDictionary<string, Object> expandoDict, Action<string> Action, string methodname)
        {


            if (expandoDict != null)
            {
                expandoDict.Add(methodname, Action);
            }
        }

        public static void AddMethod(IDictionary<string, Object> expandoDict, Func<string> method, string methodname)
        {
            if (expandoDict != null)
            {
                expandoDict.Add(methodname, method);
            }
        }

        public static void AddMethod(IDictionary<string, Object> expandoDict, Func<int >method, string methodname)
        {
            if (expandoDict != null)
            {
                expandoDict.Add(methodname, method);
            }
        }

        
    }
}

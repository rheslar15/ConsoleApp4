using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryModule;
using System.Reflection;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // check for mudiule instance creation
            var ModuleRepository = new ModuleRepository();

            ModuleFactory.SetModuleRepository(ModuleRepository);


            ModuleFactory.CreateModule("Authenticate");

            Assert.IsTrue(ModuleRepository.GetModuleByName("Authenticate") != null);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // check for method creation
            var ModuleRepository = new ModuleRepository();

            // initialize repositories
            ModuleFactory.SetModuleRepository(ModuleRepository);
            ModulePropertyFactory.SetModuleRespoitory(ModuleRepository);

            ModuleFactory.CreateModule("Authenticate");

            Assert.IsTrue(ModuleRepository.GetModuleByName("Authenticate") != null);

            // add new property to class instance
            ModulePropertyFactory.CreateProperty("Authenticate", "ApiUrl", "string", "www.example.com");

            Assert.IsTrue(ModuleRepository.GetPropertyByName("Authenticate", "ApiUrl", "string") != null);

            var d = ModuleRepository.GetModuleByName("Authenticate");

            if (d != null)
            {
                var Print = new Action(() => { Console.WriteLine("Hellooo!!!"); });

                var t = ModuleRepository.GetExpando(d);

                if (t != null)
                {
                    dynamicHelper.AddAction(t, Print, "Print");
                }

                Action<int> PrintInt = input => Console.WriteLine(input.ToString());

                var t1 = ModuleRepository.GetExpando(d);

                if (t1 != null)
                {
                    dynamicHelper.AddAction(t, PrintInt, "Printint");
                }

                Assert.IsTrue(dynamicHelper.ContainsProperty(t, "ApiUrl", "string"));

                Assert.IsTrue(dynamicHelper.ContainsAction(t, "Print"));

                Assert.IsTrue(dynamicHelper.ContainsAction(t, "Printint"));

                var funct = new Func<string>(() => { return "funct"; });


                dynamicHelper.AddMethod(t, funct, "getString");

                Assert.IsTrue(dynamicHelper.ContainsMethod(t, "getString", "string"));
            }

        }
    }
}

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
            ModuleMethodFactory.SetModuleRepository(ModuleRepository);

            ModuleFactory.CreateModule("Authenticate");

            Assert.IsTrue(ModuleRepository.GetModuleByName("Authenticate") != null);

            // add new property to class instance
            ModulePropertyFactory.CreateProperty("Authenticate", "ApiUrl", "string", "www.example.com");

            Assert.IsTrue(ModuleRepository.GetPropertyByName("Authenticate", "ApiUrl", "string") != null);

            var d = ModuleRepository.GetModuleByName("Authenticate");

            if (d != null)
            {
                var Print = new Action(() => { Console.WriteLine("Hellooo!!!"); });

               
                Action<int> PrintInt = input => Console.WriteLine(input.ToString());

                ModuleMethodFactory.CreateAction(d, Print, "Print");



                Assert.IsTrue(ModuleRepository.ContainsProperty(d, "ApiUrl", "string"));

                Assert.IsTrue(ModuleRepository.ContainsAction(d, "Print"));

                Assert.IsFalse(ModuleRepository.ContainsAction(d, "Printint"));

                var funct = new Func<string>(() => { return "funct"; });

                ModuleMethodFactory.CreateMethod(d, funct, "getString", "string");

                //dynamicHelper.AddMethod(t, funct, "getString");

                Assert.IsTrue(ModuleRepository.ContainsMethod(d, "getString", "string"));
            }

        }
    }
}

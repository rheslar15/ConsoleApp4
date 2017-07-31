using ClassLibraryModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            // test module factory

            var ModuleRepository = new ModuleRepository();

            ModuleFactory.SetModuleRepository(ModuleRepository);
            ModulePropertyFactory.SetModuleRespoitory(ModuleRepository);

            ModuleFactory.CreateModule("Authenticate");

            Assert.IsTrue(ModuleRepository.GetModuleByName("Authenticate") != null);

            ModulePropertyFactory.CreateProperty("Authenticate", "ApiUrl", "string", "www.example.com");

            Assert.IsTrue(ModuleRepository.GetPropertyByName("Authenticate", "ApiUrl", "string") != null);
        }
    }
}

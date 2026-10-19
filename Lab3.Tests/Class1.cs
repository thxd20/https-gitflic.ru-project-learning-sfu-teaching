using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace lab3.tests
{
    public static class HelloPrinter
    {
        public static void PrintHello()
        {
            Console.WriteLine("Hello World");
        }
    }

    [TestClass]
    public class HelloWorldTests
    {
        [TestMethod]
        public void PrintHelloWorld_Output()
        {
            var original = Console.Out;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                HelloPrinter.PrintHello();

                string result = sw.ToString().Trim();
                Assert.AreEqual("Hello World", result);
            }

            Console.SetOut(original);
        }
    }
}

using Exercises;
using System.Reflection;

namespace PluginProject
{
    public class Class1 : IPlugin
    {
        public void Execute()
        {
            Console.WriteLine($"Hi from: {Assembly.GetExecutingAssembly().FullName}");
        }

        public string GetText()
        {
            return nameof(Class1);
        }
    }
}

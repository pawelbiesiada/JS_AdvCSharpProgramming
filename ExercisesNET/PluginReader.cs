using Exercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal class PluginReader
    {
        static void Main()
        {
            // read external assembly from current folder with IPlugin implementation 

            // execute Execute() method
            var assembliesFiles = Directory.GetFiles(".", "*.dll");

            foreach (var assemblyFile in assembliesFiles)
            {
                var assembly = Assembly.LoadFile(Path.GetFullPath(assemblyFile));

                var matchedTypes = assembly.DefinedTypes
                    .Where(x => x.IsClass && x.ImplementedInterfaces.Any(i => i.FullName == typeof(IPlugin).FullName));

                foreach(var pluginType in matchedTypes)
                {
                    //constructurs
                    if(pluginType.DeclaredConstructors.Any(c => c.GetParameters().Count() == 0))
                    {
                        IPlugin plugin = (IPlugin)assembly.CreateInstance(pluginType.FullName);

                        plugin.Execute();
                    }                    
                }
            }
        }
    }
}

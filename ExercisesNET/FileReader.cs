using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisesNET
{
    internal class FileReader
    {

        public async Task DownloadFileAsync(string[] paths)
        {
            List<Task> tasks = new List<Task>();

            foreach (var path in paths)
            {
                tasks.Add(File.ReadAllLinesAsync(path));
            }

            var isDoneTask = Task.WhenAll(tasks.ToArray());

            ///
            ///
            ///
            ///

            await isDoneTask;


            var foreachAsync = Task.WhenEach(tasks.ToArray());



            await foreach (var item in foreachAsync)
            {

            }

            //Task.WaitAll(tasks.ToArray());


            ///
            ///
        }

    }
}

namespace AuthProvider
{
    public class Authenticator
    {
        public async Task<bool> IsAuthenticated()
        {
            var content = await File.ReadAllTextAsync("");

            return await Task.FromResult(true);
        }


        public async Task DoSomething()
        {

            var readTask = File.ReadAllTextAsync("");

            ///
            //
            //
            //

            //var content = await readTask;
            
            readTask.Wait();
            var content = readTask.Result;


            Console.WriteLine(content);
        }
    }
}

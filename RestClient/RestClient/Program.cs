namespace RestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var userRequest = client.GetAsync("https://localhost:7142/Users/User/1");

            userRequest.Wait();

            if (userRequest.Result.IsSuccessStatusCode)
            {
                var userContent = userRequest.Result.Content.ReadAsStringAsync().Result;
            }


            var userClient = new swaggerClient("https://localhost:7142", new HttpClient());

            var user = userClient.UserAsync(1).Result;
        }
    }
}

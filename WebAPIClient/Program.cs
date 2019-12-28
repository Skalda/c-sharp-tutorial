using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace WebAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        
        static async Task Main(string[] args)
        {
            var repositories = await ProcessRepositories();

            foreach (var repository in repositories)
            {
                Console.WriteLine(repository.Name);
                Console.WriteLine(repository.Description);
                Console.WriteLine(repository.GitHubHomeUrl);
                Console.WriteLine(repository.Homepage);
                Console.WriteLine(repository.Watchers);
                Console.WriteLine(repository.LastPush);
                Console.WriteLine();
            }
        }

        private static async Task<List<Repository>> ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            var serializer = new DataContractJsonSerializer(typeof(List<Repository>));
            var streamTask = client.GetStreamAsync("https://api.github.com/orgs/dotnet/repos");
            var repositories = serializer.ReadObject(await streamTask) as List<Repository>;
            return repositories;
        }
    }
}
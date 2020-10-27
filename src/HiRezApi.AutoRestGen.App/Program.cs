using System;
using System.IO;
using System.Threading.Tasks;
using HiRezApi.Common;

namespace HiRezApi.AutoRestGen.App
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var workingDirectory = Path.Combine(Environment.CurrentDirectory, "output");
            var credentials = new HiRezApiCredentials("YourDeveloperId", "YourAuthKey");
            var downloader = new ApiResponseDownloader(workingDirectory, credentials);
            await downloader.Download();

            var generator = new SwaggerGenerator(workingDirectory);
            generator.Generate();
        }
    }
}
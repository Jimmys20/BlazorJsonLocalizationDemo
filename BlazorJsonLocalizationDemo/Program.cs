using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SoloX.BlazorJsonLocalization;
using SoloX.BlazorJsonLocalization.WebAssembly;

namespace BlazorJsonLocalizationDemo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddWebAssemblyJsonLocalization(builder =>
            {
                builder
                  .EnableDisplayKeysWhileLoadingAsynchronously()
                  .UseHttpHostedJson(options =>
                  {
                      options.ApplicationAssembly = typeof(Program).Assembly;
                      options.ResourcesPath = "Resources";
                  });
            });

            //builder.Services.AddWebAssemblyJsonLocalization(builder =>
            //{
            //    builder
            //      .EnableDisplayKeysWhileLoadingAsynchronously()
            //      .UseEmbeddedJson(options =>
            //      {
            //          options.ResourcesPath = "Resources";
            //      });
            //});

            await builder.Build().RunAsync();
        }
    }
}

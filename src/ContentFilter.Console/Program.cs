

using ContentFilterApp.Core.ContentFillters.Filter.Words;
using ContentFilterApp.Core.ContentFillters.Interface;
using ContentFilterApp.Core.ContentFilters;
using ContentFilterApp.FilterApp;
using ContentFilterApp.Infrastructure.Interfaces;
using ContentFilterApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddScoped<IContentFilter, ContentFilter>();
            services.AddScoped<IFileReaderService, FileReaderService>();
            services.AddScoped<IFilterApp, FilterApp>();
            //services.AddScoped<ILogger>();
        });
        
}

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<IFilterApp>().Handle();
}
catch(Exception ex)
{
    Console.WriteLine(ex.ToString());
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

internal class StartUp
{
    private IConfiguration configuration;
    public StartUp()
    {
        configuration = GetConfig();
    }


    internal void SetUp()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
        serviceProvider.GetRequiredService<Game>().Run();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<IUI, ConsoleUI>();
        services.AddSingleton<Game>();

    }

    private IConfiguration GetConfig()
    {
       return  new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
    }
}
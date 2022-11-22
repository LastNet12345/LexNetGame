using LexNetGame.ConsoleGame.Services;
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
        services.AddSingleton<IMap, Map>();
        services.AddSingleton<Game>();
        services.AddSingleton<ILimitedList<string>>(new MessageLog<string>(6));
        // services.AddSingleton<ILimitedList<Item>>(new LimitedList<Item>(3));
        services.AddSingleton<IMapSettings>(configuration.GetSection("game:mapsettings").Get<MapSettings>()!);
        services.Configure<MapSettings>(configuration.GetSection("game:mapsettings").Bind);
        services.AddSingleton<IMapService, MapService>();


    }

    private IConfiguration GetConfig()
    {
       return  new ConfigurationBuilder()
                    .SetBasePath(Environment.CurrentDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();
    }
}
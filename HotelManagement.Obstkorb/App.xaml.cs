using Hotelmanagement.Obstkorb.DatabaseInterface;
using HotelManagement.Obstkorb.View;
using HotelManagement.Obstkorb.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System;

namespace HotelManagement.Obstkorb;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        // DI-Setup
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        var connectionString =
            "Server=DEIN_SERVER;Database=DEINE_DATENBANK;User Id=DEIN_BENUTZER;Password=DEIN_PASSWORT;";

        // Datenbankverbindung registrieren
        services.AddSingleton<IDatabaseConnectionFactory>(new DatabaseConnectionFactory(connectionString));

        // Stores
        services.AddScoped<IUserStore, UserStore>();
        services.AddScoped<IHotelBuchungStore, HotelbuchungStore>();

        // ViewModels
        services.AddTransient<LoginViewModel>();
        services.AddTransient<SignInViewModel>();
        services.AddTransient<SignUpViewModel>();
        services.AddTransient<HomeViewModel>();
        services.AddTransient<MainViewModel>();

        // MainWindow für die Hauptanwendung
        services.AddTransient<MainWindow>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var loginWindow = _serviceProvider.GetService<LoginWindow>();
        loginWindow?.Show();
    }
}

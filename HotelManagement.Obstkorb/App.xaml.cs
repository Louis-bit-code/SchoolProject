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

    private void Application_Startup(object sender, StartupEventArgs e)
    {
        // LoginWindow wird zuerst angezeigt
        var loginWindow = new LoginWindow();
        if (loginWindow.ShowDialog() == true)
        {
            // Wenn Login erfolgreich ist, zeige MainWindow
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
        else
        {
            // Falls Login abgebrochen oder fehlgeschlagen, beende die App
            Current.Shutdown();
        }
    }
}


using Hotelmanagement.Obstkorb.DatabaseInterface;
using HotelManagement.Obstkorb.DatabaseInterface;
using Hotelmanagement.Obstkorb.Model;
using Hotelmanagement.Obstkorb.Model.Freizeitaktivität;
using Hotelmanagement.Obstkorb.Model.Hotel;
using HotelManagement.Obstkorb.View;
using HotelManagement.Obstkorb.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace HotelManagement.Obstkorb
{
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
            // Registrierung der Verbindungszeichenfolge
            services.AddSingleton<string>(provider => "Server=DESKTOP-LOUIS;Database=Projekt;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;");


            // Registrierung des Stores
            services.AddSingleton<BuchungStore>();

            services.AddTransient<ZimmerBuchungViewModel>(); // ViewModel selbst registrieren
            services.AddTransient<Func<ZimmerBuchungViewModel>>(provider => () => provider.GetRequiredService<ZimmerBuchungViewModel>());


            // ViewModels

            services.AddTransient<MainViewModel>();
            services.AddTransient<BookingOverviewViewModel>();
            services.AddTransient<Freizeitaktivität>();
            services.AddTransient<FreizeitAktivitätsBuchung>();
            services.AddTransient<Hotelbuchung>();
            services.AddTransient<HotelBuchungen>();
            services.AddTransient<Hotelzimmer>();
            services.AddTransient<Preis>();
            services.AddTransient<Zusatzoptionen>();
            services.AddTransient<Kunde>();

            // Views
            services.AddSingleton<MainWindow>();

        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                var mainWindow = _serviceProvider.GetService<MainWindow>();
                if (mainWindow != null)
                {
                    mainWindow.DataContext = _serviceProvider.GetService<MainViewModel>();
                    mainWindow.Show();
                }
                else
                {
                    throw new InvalidOperationException("MainWindow konnte nicht erstellt werden.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Starten der Anwendung: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }


    }
}

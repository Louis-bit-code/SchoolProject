using Hotelmanagement.Obstkorb.DatabaseInterface;
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
            var connectionString =
                "Server=DEIN_SERVER;Database=DEINE_DATENBANK;User Id=DEIN_BENUTZER;Password=DEIN_PASSWORT;";

            // Datenbankverbindung registrieren
            services.AddSingleton<IDatabaseConnectionFactory>(new DatabaseConnectionFactory(connectionString));

            // Stores
            services.AddScoped<IHotelBuchungStore, HotelbuchungStore>();
            services.AddScoped<IHotelZimmerStore, HotelZimmerStore>();

            // ViewModels
           
            services.AddTransient<HomeViewModel>();
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
            services.AddTransient<MainWindow>();
        }

    }
}

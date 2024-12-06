using HotelManagement.Obstkorb.View;
using System.ComponentModel;
using System.Windows.Input;

namespace HotelManagement.Obstkorb.ViewModel;

public class MainViewModel : BaseViewModel
{
    private object _currentView;

    public object CurrentView
    {
        get { return _currentView; }
        set
        {
            SetProperty(ref _currentView, value);
        }
    }

    public ICommand ShowFreizeitaktivitätenViewCommand { get; }
    public ICommand ShowAutobuchungViewCommand { get; }

    public MainViewModel()
    {
        // Initiale Ansicht
        ShowFreizeitaktivitätenViewCommand = new RelayCommand<object>(o => ShowFreizeitAktivitätenView());
        ShowAutobuchungViewCommand = new RelayCommand<object>(o => ShowAutoBuchungView());

        ShowFreizeitAktivitätenView(); // Standardmäßig Freizeitaktivitäten anzeigen
    }

    private void ShowFreizeitAktivitätenView()
    {
        var view = new FreizeitAktivitätenView();
        view.DataContext = new FreizeitaktivitätenViewModel();
        CurrentView = view;
    }

    private void ShowAutoBuchungView()
    {
        var view = new AutoBuchungView();
        view.DataContext = new AutobuchungViewModel();
        CurrentView = view;
    }
}

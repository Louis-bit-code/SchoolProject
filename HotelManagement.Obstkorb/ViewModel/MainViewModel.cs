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
        ShowFreizeitaktivitätenViewCommand = new RelayCommand<object>(o => CurrentView = new FreizeitaktivitätenViewModel());
        ShowAutobuchungViewCommand = new RelayCommand<object>(o => CurrentView = new AutobuchungViewModel());

        CurrentView = new FreizeitaktivitätenViewModel(); // Standardmäßig Freizeitaktivitäten anzeigen
    }
}
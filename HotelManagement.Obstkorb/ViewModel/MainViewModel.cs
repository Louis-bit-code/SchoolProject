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
            _currentView = value;
            OnPropertyChanged(nameof(CurrentView));
        }
    }

    public ICommand ShowFreizeitaktivitätenViewCommand { get; }
    public ICommand ShowAutobuchungViewCommand { get; }

    public MainViewModel()
    {
        // Initiale Ansicht
        ShowFreizeitaktivitätenViewCommand = new RelayCommand(o => CurrentView = new FreizeitaktivitätenViewModel());
        ShowAutobuchungViewCommand = new RelayCommand(o => CurrentView = new AutobuchungViewModel());

        CurrentView = new FreizeitaktivitätenViewModel(); // Standardmäßig Freizeitaktivitäten anzeigen
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
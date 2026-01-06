using System.Net.Http;
using Misa.Ui.Avalonia.Infrastructure.Services.Navigation;
using Misa.Ui.Avalonia.Infrastructure.Stores;
using Misa.Ui.Avalonia.Presentation.Mapping;
using NavigationStore = Misa.Ui.Avalonia.Infrastructure.Stores.NavigationStore;

namespace Misa.Ui.Avalonia.App.Shell;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly HttpClient _httpClient;
    private readonly LookupsStore _lookupsStore;
    public INavigationService NavigationService { get; set; }

    public ViewModelBase? CurrentViewModel => NavigationService.NavigationStore.CurrentViewModel;
    public ViewModelBase? CurrentInfoViewModel => NavigationService.NavigationStore.CurrentInfoViewModel;
    public NavigationViewModel Navigation { get; }
    public InfoBarViewModel InfoBar { get; }
    public TitleBarViewModel TitleBar { get; }
    public StatusBarViewModel StatusBar { get; }

    public MainWindowViewModel(INavigationService navigationService, LookupsStore lookupsStore)
    {
        NavigationService = navigationService;
        _lookupsStore = lookupsStore;
        
        _httpClient = NavigationService.NavigationStore.MisaHttpClient;

        Navigation = new NavigationViewModel(NavigationService);
        InfoBar = new InfoBarViewModel(NavigationService);
        TitleBar = new TitleBarViewModel(NavigationService);
        StatusBar = new StatusBarViewModel(NavigationService);
        
        NavigationService.NavigationStore.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(NavigationStore.CurrentViewModel))
            {
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        };
        
        NavigationService.NavigationStore.PropertyChanged += (_, e) =>
        {
            if (e.PropertyName == nameof(NavigationStore.CurrentInfoViewModel))
            {
                OnPropertyChanged(nameof(CurrentInfoViewModel));
            }
        };
    }
}
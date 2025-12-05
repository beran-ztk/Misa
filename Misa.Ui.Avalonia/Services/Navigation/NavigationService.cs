using Misa.Ui.Avalonia.Stores;
using Misa.Ui.Avalonia.ViewModels.Informations;
using Misa.Ui.Avalonia.ViewModels.Items;
using Misa.Ui.Avalonia.ViewModels.Shells;

namespace Misa.Ui.Avalonia.Services.Navigation;

public class NavigationService : INavigationService
{
    private readonly NavigationStore _navigationStore;
    public NavigationService(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }
    public void ShowItems()
    {
        _navigationStore.CurrentViewModel = new ItemViewModel(this);
    }
    public void ShowNotifications()
    {
        _navigationStore.CurrentInfoViewModel = new NotificationViewModel();
    }
}
using Misa.Ui.Avalonia.Stores;
using Misa.Ui.Avalonia.ViewModels.Informations;
using Misa.Ui.Avalonia.ViewModels.Items;
using Misa.Ui.Avalonia.ViewModels.Tasks;

namespace Misa.Ui.Avalonia.Services.Navigation;

public class NavigationService : INavigationService
{
    public NavigationService(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }
    private readonly NavigationStore _navigationStore;
    public void ShowItems()
    {
        _navigationStore.CurrentViewModel = new ItemViewModel(this, _navigationStore);
    }
    public void ShowNotifications()
    {
        _navigationStore.CurrentInfoViewModel = new NotificationViewModel();
    }
    public void ShowTasks()
    {
        _navigationStore.CurrentViewModel = new TaskViewModel(_navigationStore);
    }
}
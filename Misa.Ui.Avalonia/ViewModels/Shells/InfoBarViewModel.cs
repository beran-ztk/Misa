using CommunityToolkit.Mvvm.Input;
using Misa.Ui.Avalonia.Services.Navigation;

namespace Misa.Ui.Avalonia.ViewModels.Shells;

public partial class InfoBarViewModel : ViewModelBase
{
    public InfoBarViewModel(INavigationService navigationService)
    {
        _navigationService  = navigationService;
    }
    private readonly INavigationService _navigationService;
    
    [RelayCommand]
    public void ShowNotifications()
    {
        _navigationService.ShowNotifications();
    }
}
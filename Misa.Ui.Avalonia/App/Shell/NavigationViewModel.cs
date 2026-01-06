using CommunityToolkit.Mvvm.Input;
using Misa.Ui.Avalonia.Infrastructure.Services.Navigation;
using Misa.Ui.Avalonia.Presentation.Mapping;

namespace Misa.Ui.Avalonia.App.Shell;

public partial class NavigationViewModel : ViewModelBase
{
    public NavigationViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
    }
    private readonly INavigationService _navigationService;
    
    [RelayCommand]
    public void ShowTasks()
    {
        _navigationService.ShowTasks();
    }
}
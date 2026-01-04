using Misa.Ui.Avalonia.Presentation.Mapping;
using Misa.Ui.Avalonia.Services.Navigation;

namespace Misa.Ui.Avalonia.App.Shell;

public partial class InfoBarViewModel : ViewModelBase
{
    public InfoBarViewModel(INavigationService navigationService)
    {
        _navigationService  = navigationService;
    }
    private readonly INavigationService _navigationService;
}
using Misa.Ui.Avalonia.Infrastructure.Services.Navigation;
using Misa.Ui.Avalonia.Presentation.Mapping;

namespace Misa.Ui.Avalonia.App.Shell;

public partial class InfoBarViewModel : ViewModelBase
{
    public InfoBarViewModel(INavigationService navigationService)
    {
        _navigationService  = navigationService;
    }
    private readonly INavigationService _navigationService;
}
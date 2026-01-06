using Misa.Ui.Avalonia.Infrastructure.Services.Navigation;
using Misa.Ui.Avalonia.Presentation.Mapping;

namespace Misa.Ui.Avalonia.App.Shell;

public class TitleBarViewModel : ViewModelBase
{
    public TitleBarViewModel(INavigationService navigationService)
    {
        
    }
    public string AppName => "MISA";
}
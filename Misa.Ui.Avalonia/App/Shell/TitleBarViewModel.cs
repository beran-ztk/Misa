using Misa.Ui.Avalonia.Presentation.Mapping;
using Misa.Ui.Avalonia.Services.Navigation;

namespace Misa.Ui.Avalonia.App.Shell;

public class TitleBarViewModel : ViewModelBase
{
    public TitleBarViewModel(INavigationService navigationService)
    {
        
    }
    public string AppName => "MISA";
}
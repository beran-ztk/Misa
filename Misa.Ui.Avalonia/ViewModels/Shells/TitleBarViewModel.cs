using Avalonia.Input;
using Misa.Ui.Avalonia.Services.Navigation;

namespace Misa.Ui.Avalonia.ViewModels.Shells;

public class TitleBarViewModel : ViewModelBase
{
    public TitleBarViewModel(INavigationService navigationService)
    {
        
    }
    public string AppName => "MISA";
}
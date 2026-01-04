using Misa.Ui.Avalonia.Presentation.Mapping;
using Misa.Ui.Avalonia.Services.Navigation;

namespace Misa.Ui.Avalonia.App.Shell;

public class StatusBarViewModel : ViewModelBase
{
    public StatusBarViewModel(INavigationService navigationService)
    {
        
    }
    public string Meow => "Meow";
}
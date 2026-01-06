using Misa.Ui.Avalonia.Infrastructure.Services.Navigation;
using Misa.Ui.Avalonia.Presentation.Mapping;

namespace Misa.Ui.Avalonia.App.Shell;

public class StatusBarViewModel : ViewModelBase
{
    public StatusBarViewModel(INavigationService navigationService)
    {
        
    }
    public string Meow => "Meow";
}
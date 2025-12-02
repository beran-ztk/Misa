using Misa.Ui.Avalonia.Services.Navigation;

namespace Misa.Ui.Avalonia.ViewModels.Shells;

public class StatusBarViewModel : ViewModelBase
{
    public StatusBarViewModel(INavigationService navigationService)
    {
        
    }
    public string Meow => "Meow";
}
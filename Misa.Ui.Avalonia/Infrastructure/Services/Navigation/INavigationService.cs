using Misa.Ui.Avalonia.Infrastructure.Stores;
using NavigationStore = Misa.Ui.Avalonia.Infrastructure.Stores.NavigationStore;

namespace Misa.Ui.Avalonia.Infrastructure.Services.Navigation;

public interface INavigationService
{
    public NavigationStore NavigationStore { get; }
    public LookupsStore LookupsStore { get; }
    public void ShowTasks();
}
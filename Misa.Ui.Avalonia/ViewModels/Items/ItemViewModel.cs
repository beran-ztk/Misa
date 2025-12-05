using Misa.Ui.Avalonia.Services.Navigation;
using Misa.Ui.Avalonia.ViewModels.Entities;
using Misa.Ui.Avalonia.ViewModels.Shells;

namespace Misa.Ui.Avalonia.ViewModels.Items;

public class ItemViewModel : ViewModelBase
{
    public ItemViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        ItemNavigationVM = new ItemNavigationViewModel();
        ItemListVM = new ItemListViewModel();
        EntityViewModel = new EntityMainDetailViewModel();
    }
    private readonly INavigationService _navigationService;
    public ItemNavigationViewModel ItemNavigationVM { get; }
    public ItemListViewModel ItemListVM { get; }
    public EntityMainDetailViewModel EntityViewModel { get; }
}
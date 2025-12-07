using Misa.Ui.Avalonia.Stores;
using Misa.Ui.Avalonia.ViewModels.Items;
using Misa.Ui.Avalonia.ViewModels.Shells;

namespace Misa.Ui.Avalonia.ViewModels.Entities;

public class EntityMainDetailViewModel : ViewModelBase
{
    public EntityMainDetailViewModel(ItemViewModel parent, NavigationStore navigationStore)
    {
        Parent = parent;
        NavigationStore = navigationStore;

        InformationViewModel = new EntityInformationViewModel(Parent, NavigationStore);
    }
    private int _selectedTabIndex;
    public ItemViewModel Parent { get; }
    public NavigationStore NavigationStore { get; }
    public EntityInformationViewModel InformationViewModel { get; }

    public int SelectedTabIndex
    {
        get => _selectedTabIndex;
        set => SetProperty(ref _selectedTabIndex, value);
    }
}
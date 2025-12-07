using Misa.Contract.Entities;
using Misa.Ui.Avalonia.Stores;
using Misa.Ui.Avalonia.ViewModels.Items;
using Misa.Ui.Avalonia.ViewModels.Shells;

namespace Misa.Ui.Avalonia.ViewModels.Entities;

public class EntityInformationViewModel : ViewModelBase
{
    public EntityInformationViewModel(ItemViewModel parent, NavigationStore navigationStore)
    {
        Parent = parent;
    }
    public ItemViewModel Parent { get; set; }
}
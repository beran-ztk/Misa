using Misa.Contract.Entities;
using Misa.Contract.Items;
using Misa.Ui.Avalonia.ViewModels.Shells;

namespace Misa.Ui.Avalonia.Interfaces;

public interface IEntityDetail
{
    public ReadEntityDto? SelectedEntity { get; set; }
}
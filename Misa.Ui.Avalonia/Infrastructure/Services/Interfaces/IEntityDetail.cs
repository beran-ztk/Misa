using System;

namespace Misa.Ui.Avalonia.Infrastructure.Services.Interfaces;

public interface IEntityDetail
{
    public Guid? SelectedEntity { get; set; }
    public void ReloadList();
}
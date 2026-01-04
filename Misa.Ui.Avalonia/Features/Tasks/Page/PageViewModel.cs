using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Misa.Contract.Entities;
using Misa.Contract.Items;
using Misa.Ui.Avalonia.Features.Details;
using Misa.Ui.Avalonia.Features.Tasks.List;
using Misa.Ui.Avalonia.Interfaces;
using Misa.Ui.Avalonia.Presentation.Mapping;
using Misa.Ui.Avalonia.Services.Navigation;
using NavigationViewModel = Misa.Ui.Avalonia.Features.Tasks.Navigation.NavigationViewModel;

namespace Misa.Ui.Avalonia.Features.Tasks.Page;

public enum TaskDetailMode
{
    None,
    Create,
    View,
    Edit
}
public partial class PageViewModel : ViewModelBase, IEntityDetail
{
    private ReadEntityDto? _readEntity;
    
    private ReadItemDto? _selectedTask;
    
    private ViewModelBase? _currentInfoModel;
    public INavigationService NavigationService;
    public DetailMainDetailViewModel DetailViewModel { get; } 
    public ListViewModel Model { get; }
    public NavigationViewModel Navigation { get; }
    public ObservableCollection<ReadItemDto> Items { get; set; } = [];
    
    [ObservableProperty] private bool _isCreateTaskFormOpen;
    public PageViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        
        Model = new ListViewModel(this);
        Navigation = new NavigationViewModel(this);
        DetailViewModel = new DetailMainDetailViewModel(this, NavigationService);
    }

    [ObservableProperty] public Guid? _selectedEntity;
    public void ReloadList()
    {
        _ = Model.LoadAsync();
    }

    public ViewModelBase? CurrentInfoModel
    {
        get => _currentInfoModel;
        set => SetProperty(ref _currentInfoModel, value);
        
    }
    public void ShowDetails() => CurrentInfoModel = DetailViewModel;
    public ReadItemDto? SelectedTask
    {
        get => _selectedTask;
        set
        {
            SetProperty(ref _selectedTask, value);
            SelectedEntity = value?.Entity.Id;
            ShowDetails();
        }
    }
}
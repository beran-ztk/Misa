using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Misa.Contract.Items;
using Misa.Ui.Avalonia.Features.Details;
using Misa.Ui.Avalonia.Features.Tasks.Shared;
using Misa.Ui.Avalonia.Features.Tasks.Create;
using Misa.Ui.Avalonia.Features.Tasks.List;
using Misa.Ui.Avalonia.Interfaces;
using Misa.Ui.Avalonia.Presentation.Mapping;
using Misa.Ui.Avalonia.Services.Navigation;
using NavigationViewModel = Misa.Ui.Avalonia.Features.Tasks.Navigation.NavigationViewModel;

namespace Misa.Ui.Avalonia.Features.Tasks.Page;

public partial class PageViewModel : ViewModelBase, IEntityDetail, IDisposable
{
    private ReadItemDto? _selectedTask;
    private ViewModelBase? _currentInfoModel;

    public INavigationService NavigationService;
    public DetailMainDetailViewModel DetailViewModel { get; }

    public ListViewModel Model { get; }
    public NavigationViewModel Navigation { get; }

    public ObservableCollection<ReadItemDto> Items { get; } = [];

    [ObservableProperty] public Guid? _selectedEntity;

    [ObservableProperty] private string? _pageError;

    public IEventBus Bus { get; }

    private readonly IDisposable _subOpenCreate;
    private readonly IDisposable _subCloseRight;
    private readonly IDisposable _subReload;
    private readonly IDisposable _subCreated;
    private readonly IDisposable _subCreateFailed;

    public PageViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;

        Bus = new EventBus();

        Model = new ListViewModel(this, Bus);
        Navigation = new NavigationViewModel(this, Bus);
        DetailViewModel = new DetailMainDetailViewModel(this, NavigationService);

        _subOpenCreate = Bus.Subscribe<OpenCreateRequested>(_ =>
        {
            PageError = null;
            CurrentInfoModel = new CreateViewModel(this, Bus);
        });

        _subCloseRight = Bus.Subscribe<CloseRightPaneRequested>(_ =>
        {
            PageError = null;
            CurrentInfoModel = null;
        });

        _subReload = Bus.Subscribe<ReloadTasksRequested>(evt =>
        {
            PageError = null;
            _ = Model.LoadAsync();
        });

        _subCreated = Bus.Subscribe<TaskCreated>(e =>
        {
            PageError = null;

            Items.Add(e.Created);

            SelectedTask = e.Created;
        });

        _subCreateFailed = Bus.Subscribe<TaskCreateFailed>(e =>
        {
            PageError = e.Message;
        });
    }

    public void ReloadList() => Bus.Publish(new ReloadTasksRequested());

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
    public void Dispose()
    {
        _subOpenCreate.Dispose();
        _subCloseRight.Dispose();
        _subReload.Dispose();
        _subCreated.Dispose();
        _subCreateFailed.Dispose();
    }
}

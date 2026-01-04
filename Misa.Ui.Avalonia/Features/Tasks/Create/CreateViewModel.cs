using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Media;
using CommunityToolkit.Mvvm.Input;
using Misa.Contract.Items;
using Misa.Contract.Items.Lookups;
using Misa.Ui.Avalonia.Features.Tasks.Shared;
using Misa.Ui.Avalonia.Features.Tasks.Shared;
using Misa.Ui.Avalonia.Presentation.Mapping;
using ReactiveUI;
using PageViewModel = Misa.Ui.Avalonia.Features.Tasks.Page.PageViewModel;

namespace Misa.Ui.Avalonia.Features.Tasks.Create;

public partial class CreateViewModel : ViewModelBase
{
    public PageViewModel MainViewModel { get; }
    private readonly IEventBus _bus;

    public ReactiveCommand<Unit, Unit> CreateTaskCommand { get; }

    private string _title = string.Empty;
    private int _priorityId = 1;
    private int _categoryId = 1;
    private string? _errorMessageTitle = null;
    private IBrush? _titleBorderBrush;

    public CreateViewModel(PageViewModel vm, IEventBus bus)
    {
        MainViewModel = vm;
        _bus = bus;

        CreateTaskCommand = ReactiveCommand.CreateFromTask(
            execute: CreateTaskCommandAsync,
            canExecute: this.WhenAnyValue(x => x.Title, t => !string.IsNullOrWhiteSpace(t))
        );

        CreateTaskCommand.ThrownExceptions.Subscribe(_ =>
        {
            ErrorMessageTitle = "Unexpected error while creating the task.";
            TitleBorderBrush = Brushes.Red;
        });
    }

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public int PriorityId
    {
        get => _priorityId;
        set => SetProperty(ref _priorityId, value);
    }

    public int CategoryId
    {
        get => _categoryId;
        set => SetProperty(ref _categoryId, value);
    }

    public string? ErrorMessageTitle
    {
        get => _errorMessageTitle;
        set => SetProperty(ref _errorMessageTitle, value);
    }

    public IBrush? TitleBorderBrush
    {
        get => _titleBorderBrush;
        set => SetProperty(ref _titleBorderBrush, value);
    }

    public IReadOnlyList<PriorityDto> Priorities =>
        MainViewModel.NavigationService.LookupsStore.Priorities;

    public IReadOnlyList<CategoryDto> Categories =>
        MainViewModel.NavigationService.LookupsStore.TaskCategories;

    private void TitleError(string message)
    {
        ErrorMessageTitle = message;
        TitleBorderBrush = Brushes.Red;
    }

    [RelayCommand]
    private void CancelTask()
    {
        _bus.Publish(new CloseRightPaneRequested());
    }

    private async Task CreateTaskCommandAsync()
    {
        var trimmedTitle = Title?.Trim();

        if (string.IsNullOrWhiteSpace(trimmedTitle))
        {
            TitleError("Please specify a title.");
            return;
        }

        ErrorMessageTitle = null;
        TitleBorderBrush = null;

        var dto = new CreateItemDto
        {
            OwnerId = null,
            PriorityId = PriorityId,
            CategoryId = CategoryId,
            Title = trimmedTitle
        };

        var response = await MainViewModel.NavigationService.NavigationStore
            .MisaHttpClient.PostAsJsonAsync(requestUri: "api/tasks", dto);

        if (!response.IsSuccessStatusCode)
        { 
            var body = await response.Content.ReadAsStringAsync();
            var msg = string.IsNullOrWhiteSpace(body)
                ? $"Server returned {response.StatusCode}."
                : $"Server returned {response.StatusCode}: {body}";

            TitleError(msg);
            _bus.Publish(new TaskCreateFailed(msg));
            return;
        }

        var createdItem = await response.Content.ReadFromJsonAsync<ReadItemDto>();
        if (createdItem == null)
        {
            TitleError("Server returned success but no task payload.");
            _bus.Publish(new TaskCreateFailed("Server returned success but no task payload."));
            return;
        }

        _bus.Publish(new TaskCreated(createdItem));
    }
}

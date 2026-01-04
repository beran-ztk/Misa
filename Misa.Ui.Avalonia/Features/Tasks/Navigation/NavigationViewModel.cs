using System;
using System.Reactive;
using Misa.Ui.Avalonia.Features.Tasks.Shared;
using Misa.Ui.Avalonia.Features.Tasks.Page;
using Misa.Ui.Avalonia.Presentation.Mapping;
using ReactiveUI;

namespace Misa.Ui.Avalonia.Features.Tasks.Navigation;

public class NavigationViewModel : ViewModelBase
{
    public PageViewModel MainViewModel { get; }
    public ReactiveCommand<Unit, Unit> AddTaskCommand { get; }

    private readonly IEventBus _bus;

    public NavigationViewModel(PageViewModel vm, IEventBus bus)
    {
        MainViewModel = vm;
        _bus = bus;

        AddTaskCommand = ReactiveCommand.Create(() => _bus.Publish(new OpenCreateRequested()));

        AddTaskCommand.ThrownExceptions.Subscribe(_ => _bus.Publish(new TaskCreateFailed("Unexpected error while opening Create view.")));
    }
}
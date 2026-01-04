using System;
using System.Reactive;
using Misa.Ui.Avalonia.Features.Tasks.Create;
using Misa.Ui.Avalonia.Features.Tasks.Page;
using Misa.Ui.Avalonia.Presentation.Mapping;
using ReactiveUI;

namespace Misa.Ui.Avalonia.Features.Tasks.Navigation;

public class NavigationViewModel : ViewModelBase
{
    public PageViewModel MainViewModel { get; }
    public ReactiveCommand<Unit, Unit> AddTaskCommand { get; }
    public NavigationViewModel(PageViewModel vm)
    {
        MainViewModel = vm;
        AddTaskCommand = ReactiveCommand.Create(AddTaskCommandAsync);
        AddTaskCommand
            .ThrownExceptions
            .Subscribe(Console.WriteLine);
    }
    private void AddTaskCommandAsync()
    {
        MainViewModel.IsCreateTaskFormOpen = true;
        MainViewModel.CurrentInfoModel = new CreateViewModel(MainViewModel);
    }
}
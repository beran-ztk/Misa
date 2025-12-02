using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Misa.Ui.Avalonia.ViewModels.Shells;

namespace Misa.Ui.Avalonia.Stores;

public class NavigationStore : ObservableObject
{
    private ViewModelBase? _currentViewModel;
    private ViewModelBase? _currentInfoViewModel;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set => SetProperty(ref _currentViewModel, value);
    }
    public ViewModelBase? CurrentInfoViewModel
    {
        get => _currentInfoViewModel;
        set => SetProperty(ref _currentInfoViewModel, value);
    }
}
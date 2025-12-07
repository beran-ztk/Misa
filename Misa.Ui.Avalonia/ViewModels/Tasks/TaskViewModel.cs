using System;
using System.Net.Http;
using Misa.Ui.Avalonia.Services.Navigation;
using Misa.Ui.Avalonia.Stores;
using Misa.Ui.Avalonia.ViewModels.Entities;
using Misa.Ui.Avalonia.ViewModels.Items;
using Misa.Ui.Avalonia.ViewModels.Shells;
using ReactiveUI;

namespace Misa.Ui.Avalonia.ViewModels.Tasks;

public class TaskViewModel : ViewModelBase
{
    public TaskViewModel(NavigationStore navigationStore)
    {
        NavigationStore = navigationStore;
        
        _httpClient = NavigationStore.MisaHttpClient;
        ListModel = new TaskListViewModel();
        Navigation = new TaskNavigationViewModel(NavigationStore);
    }
    private readonly HttpClient _httpClient;
    public TaskListViewModel ListModel { get; }
    public TaskNavigationViewModel Navigation { get; }
    public NavigationStore NavigationStore { get; }
}
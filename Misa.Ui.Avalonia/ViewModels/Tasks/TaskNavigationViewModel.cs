using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using System.Threading.Tasks;
using Misa.Contract.Entities;
using Misa.Ui.Avalonia.Stores;
using Misa.Ui.Avalonia.ViewModels.Shells;
using ReactiveUI;

namespace Misa.Ui.Avalonia.ViewModels.Tasks;

public class TaskNavigationViewModel : ViewModelBase
{
    public TaskNavigationViewModel(NavigationStore navigationStore)
    {
        _httpClient = navigationStore.MisaHttpClient;
        
        AddTaskCommand = ReactiveCommand.CreateFromTask(AddTaskCommandAsync);
        AddTaskCommand
            .ThrownExceptions
            .Subscribe(Console.WriteLine);
    }
    private readonly HttpClient _httpClient;
    public ReactiveCommand<Unit, Unit> AddTaskCommand { get; }
    
    private async Task AddTaskCommandAsync()
    {
        try
        {
            var response = await _httpClient.PostAsync(requestUri: "api/tasks/add", content: null);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Server returned {response.StatusCode}: {body}");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
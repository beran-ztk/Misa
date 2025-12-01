using System;
using System.Threading.Tasks;
using Misa.Contract.Items;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reactive;
using ReactiveUI;

namespace Misa.Ui.Avalonia.ViewModels.Shells;

public partial class MainWindowViewModel : ViewModelBase
{
    private readonly HttpClient _httpClient;
    public ReactiveCommand<Unit, Unit> CreateItemCommand { get; }

    public MainWindowViewModel()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("http://localhost:4500") };
        CreateItemCommand = ReactiveCommand.CreateFromTask(CreateItemAsync);
        CreateItemCommand
            .ThrownExceptions
            .Subscribe(Console.WriteLine);
    }

    private async Task CreateItemAsync()
    {
        try
        {
            var item = new ItemDto("Test", "Meow");
            var response = await _httpClient.PostAsJsonAsync(requestUri: "api/items", item);
            if (!response.IsSuccessStatusCode)
            {
                var body = await response.Content.ReadAsStringAsync();
                // Hier kannst du dir ansehen, was der Server sagt
                Console.WriteLine($"Server returned {response.StatusCode}: {body}");
                // Kein Throw – du entscheidest, wie du reagierst
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
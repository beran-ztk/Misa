using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Misa.Contract.Audit;
using Misa.Contract.Audit.Session;
using Misa.Ui.Avalonia.Presentation.Mapping;

namespace Misa.Ui.Avalonia.Features.Details.Information.Extensions.Sessions;

public partial class PauseSessionViewModel : ViewModelBase
{
    public InformationViewModel Parent { get; }
    public PauseSessionViewModel(InformationViewModel parent)
    {
        Parent = parent;
    }
    [ObservableProperty] private string? _pauseReason;
    
    [RelayCommand]
    private async Task PauseSession()
    {
        try
        {
            var dto = new PauseSessionDto(Parent.Parent.ItemOverview.Item.Id, PauseReason);
            
            var response = await Parent.Parent.EntityDetailHost.NavigationService.NavigationStore
                .MisaHttpClient.PostAsJsonAsync(requestUri: "Sessions/Pause", dto);

            if (!response.IsSuccessStatusCode)
                Console.WriteLine($"Server returned {response.StatusCode}: {response.ReasonPhrase}");

            await Parent.Parent.Reload();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}
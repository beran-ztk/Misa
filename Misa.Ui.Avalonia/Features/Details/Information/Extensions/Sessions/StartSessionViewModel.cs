using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Misa.Contract.Audit;
using Misa.Ui.Avalonia.Presentation.Mapping;

namespace Misa.Ui.Avalonia.Features.Details.Information.Extensions.Sessions;

public partial class StartSessionViewModel : ViewModelBase
{
    public InformationViewModel Parent { get; }
    public StartSessionViewModel(InformationViewModel parent)
    {
        Parent = parent;
    }
    [ObservableProperty] private int? plannedMinutes;
    [ObservableProperty] private string? objective;
    [ObservableProperty] private bool? stopAutomatically;
    [ObservableProperty] private string? autoStopReason;
    [RelayCommand]
    private void ShowSessionStartForm()
    {
        PlannedMinutes = null;
        Objective = null;
        StopAutomatically = false;
        AutoStopReason = null;
    }

    [RelayCommand]
    private async Task StartSession()
    {
        try
        {
            SessionDto dto = new()
            {
                EntityId = Parent.Parent.ItemOverview.Item.Id,
                PlannedDuration = PlannedMinutes.HasValue 
                    ? TimeSpan.FromMinutes(Convert.ToInt32(PlannedMinutes)) 
                    : null,
                Objective = Objective,
                StopAutomatically = StopAutomatically ?? false,
                AutoStopReason = AutoStopReason
            };
            var response = await Parent.Parent.EntityDetailHost.NavigationService.NavigationStore
                .MisaHttpClient.PostAsJsonAsync(requestUri: "Sessions/Start", dto);

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
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Misa.Contract.Audit;
using Misa.Contract.Audit.Lookups;
using Misa.Contract.Audit.Session;
using Misa.Ui.Avalonia.Presentation.Mapping;

namespace Misa.Ui.Avalonia.Features.Details.Information.Extensions.Sessions;

public partial class StopSessionViewModel : ViewModelBase
{
    public InformationViewModel Parent { get; }
    public StopSessionViewModel(InformationViewModel parent)
    {
        Parent = parent;
    }
    
    [ObservableProperty] private int? efficiency;
    [ObservableProperty] private int? concentration;
    [ObservableProperty] private string? summary;
    [ObservableProperty] private int? efficiencyId; 
    [ObservableProperty] private int? concentrationId; 
    public IReadOnlyList<SessionEfficiencyTypeDto> EfficiencyTypes =>
        Parent.Parent.EntityDetailHost.NavigationService.LookupsStore.EfficiencyTypes;
    public IReadOnlyList<SessionConcentrationTypeDto> ConcentrationTypes =>
        Parent.Parent.EntityDetailHost.NavigationService.LookupsStore.ConcentrationTypes;
    [RelayCommand]
    private async Task StopSession()
    {
        try
        {
            var stopSession = new StopSessionDto
            {
                EntityId = Parent.Parent.ItemOverview.Item.Id,
                Efficiency = EfficiencyId,
                Concentration = ConcentrationId,
                Summary = Summary
            };
            var response = await Parent.Parent.EntityDetailHost.NavigationService.NavigationStore
                .MisaHttpClient.PostAsJsonAsync( requestUri: $"Sessions/Stop", stopSession );
            
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
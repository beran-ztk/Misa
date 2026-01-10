using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Misa.Ui.Avalonia.Presentation.Mapping;

namespace Misa.Ui.Avalonia.Features.Details.Information.Extensions.Sessions;

public partial class CurrentSessionViewModel : ViewModelBase
{
    public InformationViewModel Parent { get; }
    public CurrentSessionViewModel(InformationViewModel parent)
    {
        Parent = parent;
    }
    [RelayCommand]
    private async Task SessionContinue()
    {
        try
        {
            var response = await Parent.Parent.EntityDetailHost.NavigationService.NavigationStore
                .MisaHttpClient.PostAsync(
                    requestUri: $"Sessions/Continue/{Parent.Parent.ItemOverview.Item.Id}",
                    content: null
                );


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
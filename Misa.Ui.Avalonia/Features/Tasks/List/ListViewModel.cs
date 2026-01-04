using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Avalonia.Threading;
using Misa.Contract.Items;
using Misa.Ui.Avalonia.Presentation.Mapping;
using PageViewModel = Misa.Ui.Avalonia.Features.Tasks.Page.PageViewModel;

namespace Misa.Ui.Avalonia.Features.Tasks.List;

public class ListViewModel : ViewModelBase
{
    public ListViewModel(PageViewModel vm)
    {
        MainViewModel = vm;
        _ = LoadAsync();
    }
    public PageViewModel MainViewModel { get; }
    
    
    public async Task LoadAsync()
    {
        try
        {
            var response = await MainViewModel.NavigationService.NavigationStore.MisaHttpClient
                .GetFromJsonAsync<ReadItemDto[]>(requestUri: "api/tasks");
            
            if (response == null)
                return;
            
            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                MainViewModel.Items.Clear();
                foreach (var item in response)
                {
                    MainViewModel.Items.Add(item);
                }
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    } 
}
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Avalonia.Threading;
using Misa.Contract.Items;
using Misa.Ui.Avalonia.Features.Tasks.Shared;
using Misa.Ui.Avalonia.Features.Tasks.Shared;
using Misa.Ui.Avalonia.Presentation.Mapping;
using PageViewModel = Misa.Ui.Avalonia.Features.Tasks.Page.PageViewModel;

namespace Misa.Ui.Avalonia.Features.Tasks.List;

public class ListViewModel : ViewModelBase
{
    public PageViewModel MainViewModel { get; }
    private readonly IEventBus _bus;

    public ListViewModel(PageViewModel vm, IEventBus bus)
    {
        MainViewModel = vm;
        _bus = bus;

        _ = LoadAsync();
    }

    public async Task LoadAsync()
    {
        try
        {
            var items = await MainViewModel.NavigationService.NavigationStore.MisaHttpClient
                .GetFromJsonAsync<ReadItemDto[]>(requestUri: "api/tasks");

            if (items == null)
                return;

            await Dispatcher.UIThread.InvokeAsync(() =>
            {
                MainViewModel.Items.Clear();
                foreach (var item in items)
                    MainViewModel.Items.Add(item);
            });
        }
        catch
        {
            _bus.Publish(new TaskCreateFailed("Failed to load tasks list."));
        }
    }
}
using System;
using System.Net.Http.Json;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Misa.Contract.Entities;
using Misa.Ui.Avalonia.Infrastructure.Services.Interfaces;
using Misa.Ui.Avalonia.Infrastructure.Services.Navigation;
using Misa.Ui.Avalonia.Presentation.Mapping;
using ReactiveUI;

namespace Misa.Ui.Avalonia.Features.Details.Page;

public partial class DetailPageViewModel : ViewModelBase, IDisposable
{
    public IEntityDetailHost EntityDetailHost { get; }

    [ObservableProperty] private EntityDto _detailedEntity = new();
    [ObservableProperty] private int _selectedTabIndex;

    public Information.InformationViewModel InformationViewModel { get; }

    private readonly CompositeDisposable _disposables = new();
    private CancellationTokenSource? _loadCts;

    public DetailPageViewModel(IEntityDetailHost entityDetailHost)
    {
        EntityDetailHost = entityDetailHost;
        
        InformationViewModel = new Information.InformationViewModel(this);
        
        this.WhenAnyValue(x => x.EntityDetailHost.ActiveEntityId)
            .Where(id => id != Guid.Empty)
            .DistinctUntilChanged()
            .Subscribe(id => _ = LoadEntityAsync(id));
    }

    public async Task Reload()
    {
        await LoadEntityAsync(EntityDetailHost.ActiveEntityId);
    }
    private async Task LoadEntityAsync(Guid entityId)
    {
        Console.WriteLine("Entity change detected!");
        
        await _loadCts?.CancelAsync();
        _loadCts?.Dispose();
        _loadCts = new CancellationTokenSource();

        try
        {
            var response = await EntityDetailHost.NavigationService.NavigationStore.MisaHttpClient
                .GetFromJsonAsync<EntityDto>($"api/entities/{entityId}", _loadCts.Token);

            if (response != null)
                DetailedEntity = response;
        }
        catch (OperationCanceledException)
        {
            // expected on fast switching
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void Dispose()
    {
        _loadCts?.Cancel();
        _loadCts?.Dispose();
        _disposables.Dispose();
    }
}

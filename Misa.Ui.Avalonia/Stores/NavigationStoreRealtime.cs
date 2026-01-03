using System;
using System.Net.Http;
using System.Text.Json;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using Misa.Contract.Events;
using Misa.Ui.Avalonia.Services.Realtime;
using Misa.Ui.Avalonia.ViewModels.Shells;

namespace Misa.Ui.Avalonia.Stores;

public partial class NavigationStore : ObservableObject
{
    public RealtimeEventsClient Realtime { get; } = new();

    public Action<Guid>? RefreshItemById { get; set; }
    public Action? RefreshCurrent { get; set; }

    public event Action<EventDto>? RealtimeEventReceived;

    public void WireRealtimeHandlers()
    {
        Console.WriteLine($"[NavStore] got event, store={GetHashCode()}");

        Realtime.EventReceived += evt =>
        {
            // 1) rohes Event an alle Interessenten
            RealtimeEventReceived?.Invoke(evt);

            // 2) optional: globaler Minimal-Refresher (nur wenn du es willst)
            HandleGlobalRefresh(evt);
        };
    }

    private void HandleGlobalRefresh(EventDto evt)
    {
        if (!string.Equals(evt.EventType, "DeadlineRemoved", StringComparison.Ordinal))
            return;

        Guid itemId;
        try
        {
            using var doc = JsonDocument.Parse(evt.Payload);
            itemId = doc.RootElement.GetProperty("itemId").GetGuid();
        }
        catch { return; }

        Dispatcher.UIThread.Post(() =>
        {
            RefreshItemById?.Invoke(itemId);
            RefreshCurrent?.Invoke();
        });
    }
}

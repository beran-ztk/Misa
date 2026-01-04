using System;
using System.Collections.Generic;

namespace Misa.Ui.Avalonia.Features.Tasks.Shared;

public sealed class EventBus : IEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _handlers = new();

    public IDisposable Subscribe<T>(Action<T> handler)
    {
        var t = typeof(T);
        if (!_handlers.TryGetValue(t, out var list))
        {
            list = new List<Delegate>();
            _handlers[t] = list;
        }

        list.Add(handler);

        return new Unsubscriber(() =>
        {
            if (_handlers.TryGetValue(t, out var l))
                l.Remove(handler);
        });
    }

    public void Publish<T>(T evt)
    {
        var t = typeof(T);
        if (!_handlers.TryGetValue(t, out var list))
            return;

        var snapshot = list.ToArray();
        foreach (var d in snapshot)
            ((Action<T>)d)(evt);
    }

    private sealed class Unsubscriber : IDisposable
    {
        private readonly Action _unsubscribe;
        private bool _disposed;

        public Unsubscriber(Action unsubscribe) => _unsubscribe = unsubscribe;

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _unsubscribe();
        }
    }
}
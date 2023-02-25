using Microsoft.AspNetCore.Components;
using System;
using Blazored.Toast.Services;
using System.Threading.Channels;

namespace Blazored.Toast.Configuration;

public class ToastInstance
{
    internal event Action<Guid>? OnClose;
    internal ToastInstance(RenderFragment message, ToastLevel level, ToastSettings toastSettings)
    {
        Message = message;
        Level = level;
        ToastSettings = toastSettings;
    }
    internal ToastInstance(RenderFragment customComponent, ToastSettings settings)
    {
        CustomComponent = customComponent;
        ToastSettings = settings;
    }

    public Guid Id { get; } = Guid.NewGuid();
    internal DateTime TimeStamp { get; } = DateTime.Now;
    internal RenderFragment? Message { get; }
    internal ToastLevel Level { get; }
    internal ToastSettings ToastSettings { get; }
    internal RenderFragment? CustomComponent { get; }

    public void Close()
    {
        OnClose?.Invoke(Id);
    }
}

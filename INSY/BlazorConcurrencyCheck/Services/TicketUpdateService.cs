using System;

namespace BlazorConcurrencyCheck.Services;

public class TicketUpdateService
{
    public event Action<int>? OnTicketUpdated;

    public void NotifyTicketUpdated(int ticketId)
    {
        OnTicketUpdated?.Invoke(ticketId);
    }
}

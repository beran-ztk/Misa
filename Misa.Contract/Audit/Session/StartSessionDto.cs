namespace Misa.Contract.Audit.Session;

public record StartSessionDto(
    Guid ItemId, 
    TimeSpan? PlannedDuration,
    string? Objective, 
    bool StopAutomatically, 
    string? AutoStopReason
);
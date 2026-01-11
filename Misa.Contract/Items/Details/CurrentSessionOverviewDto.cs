using Misa.Contract.Audit;
using Misa.Contract.Audit.Session;

namespace Misa.Contract.Items.Details;

public class CurrentSessionOverviewDto
{
    public SessionResolvedDto? ActiveSession { get; set; }
    public SessionResolvedDto? LatestClosedSession { get; set; }
    
    public bool CanStartSession; // When not active
    public bool CanPauseSession; // When Running
    public bool CanContinueSession; // When Paused
    public bool CanStopSession; // When active
    
    public int ItemSessionCount { get; set; }
    public double? AvgEfficiency { get; set; }
    public double? AvgConcentration { get; set; }
    public double? AvgAccuracyOfPlannedDuration { get; set; }
}
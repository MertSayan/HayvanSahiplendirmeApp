namespace Application.Features.MediatR.Users.Results
{
    public class AdminDashboardStatsQueryResult
    {
        public int TotalUserCount { get; set; }
        public int ActivePetCount { get; set; }
        public double AdoptionRate { get; set; }
        public int PendingApprovalCount { get; set; }
    }
}

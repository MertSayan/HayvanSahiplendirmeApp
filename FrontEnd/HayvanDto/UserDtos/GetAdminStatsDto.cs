namespace HayvanDto.UserDtos
{
    public class GetAdminStatsDto
    {

        public int totalUserCount { get; set; }
        public int activePetCount { get; set; }
        public int adoptionRate { get; set; }
        public int pendingApprovalCount { get; set; }


    }
}

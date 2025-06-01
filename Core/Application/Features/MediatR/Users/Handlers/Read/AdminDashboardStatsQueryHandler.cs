using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.UserInterface;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Read
{
    public class AdminDashboardStatsQueryHandler : IRequestHandler<AdminDashboardStatsQuery, AdminDashboardStatsQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public AdminDashboardStatsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AdminDashboardStatsQueryResult> Handle(AdminDashboardStatsQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetDashboardStatsAsync();
        }
    }
}

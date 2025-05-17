using Application.Features.MediatR.Users.Queries;
using Application.Features.MediatR.Users.Results;
using Application.Interfaces.UserInterface;
using MediatR;

namespace Application.Features.MediatR.Users.Handlers.Read
{
    public class GetByIdUserProfileStatsQueryHandler : IRequestHandler<GetByIdUserProfileStatsQuery, GetByIdUserProfileStatsQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public GetByIdUserProfileStatsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetByIdUserProfileStatsQueryResult> Handle(GetByIdUserProfileStatsQuery request, CancellationToken cancellationToken)
        {
            var (totalpets, totallikes, succesfulAdoptions) = await _userRepository.GetUserStatsAsync(request.Id);
            return new GetByIdUserProfileStatsQueryResult
            {
                SuccessfulAdoptions = succesfulAdoptions,
                TotalLikes = totallikes,
                TotalPets = totalpets,
            };
        }
    }
}

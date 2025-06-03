using Application.Features.MediatR.Messages.Results;
using MediatR;

namespace Application.Features.MediatR.Messages.Queries
{
    public class GetUserConversationsQuery:IRequest<List<GetUserConversationDto>>
    {
        public int UserId { get; set; }

        public GetUserConversationsQuery(int userId)
        {
            UserId = userId;
        }
    }
}

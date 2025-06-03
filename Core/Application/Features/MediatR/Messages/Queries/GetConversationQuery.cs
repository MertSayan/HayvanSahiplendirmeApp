using Domain;
using MediatR;

namespace Application.Features.MediatR.Messages.Queries
{
    public class GetConversationQuery:IRequest<List<Message>>
    {
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }

        public GetConversationQuery(int userId1, int userId2)
        {
            UserId1 = userId1;
            UserId2 = userId2;
        }
    }
}

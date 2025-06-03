using MediatR;

namespace Application.Features.MediatR.Messages.Queries
{
    public class GetMessagesBetweenUsersQuery:IRequest<List<MessageDto>>
    {
        public int UserId1 { get; set; } // giriş yapan
        public int UserId2 { get; set; } // karşı taraf
    }
}

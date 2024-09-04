using MediatR;
using ProjectUsers.Application.Users.Commands.Response;

namespace ProjectUsers.Application.Users.Queries.Request
{
    public class GetAllUsersQueryRequest : IRequest<List<ListUserResponse>>
    {
    }
}

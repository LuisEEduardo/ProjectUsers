using MediatR;
using ProjectUsers.Application.Users.Commands.Response;

namespace ProjectUsers.Application.Users.Queries.Request;

public record class GetUserByIdQueryRequest : IRequest<ListUserResponse>
{
    public Guid Id { get; set; }
}

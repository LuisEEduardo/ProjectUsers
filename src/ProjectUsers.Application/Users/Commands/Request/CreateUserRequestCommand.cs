using MediatR;
using ProjectUsers.Application.Users.Commands.Response;
using ProjectUsers.Domain.Entities;

namespace ProjectUsers.Application.Users.Commands.Request;

public record CreateUserRequestCommand : IRequest<ListUserResponse>
{
    public string Name { get; }
    public string Email { get; }
    public Role Role { get; }
}

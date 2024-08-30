using MediatR;
using ProjectUsers.Application.Users.Commands.Response;
using ProjectUsers.Domain.Entities;

namespace ProjectUsers.Application.Users.Commands.Request;

public record UpdateUserRequestCommand : IRequest<ListUserResponse>
{
    public Guid Id { get; set; }
    public string Name { get; }
    public string Email { get; }
    public Role Role { get; }
}

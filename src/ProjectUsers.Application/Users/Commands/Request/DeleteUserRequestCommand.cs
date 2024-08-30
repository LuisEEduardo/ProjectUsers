using MediatR;

namespace ProjectUsers.Application.Users.Commands.Request;

public record DeleteUserRequestCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

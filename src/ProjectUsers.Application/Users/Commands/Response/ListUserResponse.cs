using ProjectUsers.Domain.Entities;

namespace ProjectUsers.Application.Users.Commands.Response;

public record ListUserResponse
{
    public ListUserResponse(Guid id, string name, string email, Role role)
    {
        Id = id;
        Name = name;
        Email = email;
        Role = role;
    }

    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }
    public Role Role { get; }
}

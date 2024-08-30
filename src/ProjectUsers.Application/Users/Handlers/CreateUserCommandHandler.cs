using MediatR;
using ProjectUsers.Application.Users.Commands.Request;
using ProjectUsers.Application.Users.Commands.Response;
using ProjectUsers.Domain.Entities;
using ProjectUsers.Domain.Notifications;
using ProjectUsers.Domain.Repositories;

namespace ProjectUsers.Application.Users.Handlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserRequestCommand, CreateUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationContext _notificationContext;

    public CreateUserCommandHandler(IUnitOfWork unitOfWork, INotificationContext notificationContext)
    {
        _unitOfWork = unitOfWork;
        _notificationContext = notificationContext;
    }

    public async Task<CreateUserResponse> Handle(CreateUserRequestCommand request, CancellationToken cancellationToken)
    {
        var user = new User(request.Name, request.Email, request.Role);

        if (user.Valid)
        {
            _notificationContext.AddNotification(user.ValidationResult);
            return null;
        }

        _unitOfWork.UserRepository.Create(user);

        await _unitOfWork.CommitAsync();

        return new CreateUserResponse(user.Id, user.Name, user.Email, user.Role);
    }
}


using MediatR;
using ProjectUsers.Application.Users.Commands.Request;
using ProjectUsers.Application.Users.Commands.Response;
using ProjectUsers.Domain.Notifications;
using ProjectUsers.Domain.Repositories;

namespace ProjectUsers.Application.Users.Handlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequestCommand, ListUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationContext _notificationContext;

    public UpdateUserCommandHandler(IUnitOfWork unitOfWork, INotificationContext notificationContext)
    {
        _unitOfWork = unitOfWork;
        _notificationContext = notificationContext;
    }

    public async Task<ListUserResponse> Handle(UpdateUserRequestCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            _notificationContext.AddNotification("user invalid");
            return null;
        }

        user.Edit(request.Name, request.Email, request.Role);

        _unitOfWork.UserRepository.Update(user);

        await _unitOfWork.CommitAsync();

        return new ListUserResponse(user.Id, user.Name, user.Email, user.Role);
    }
}
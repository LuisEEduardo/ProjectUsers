using MediatR;
using ProjectUsers.Application.Users.Commands.Request;
using ProjectUsers.Domain.Notifications;
using ProjectUsers.Domain.Repositories;

namespace ProjectUsers.Application.Users.Handlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserRequestCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationContext _notificationContext;

    public DeleteUserCommandHandler(IUnitOfWork unitOfWork, INotificationContext notificationContext)
    {
        _unitOfWork = unitOfWork;
        _notificationContext = notificationContext;
    }

    public async Task<bool> Handle(DeleteUserRequestCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

        if (user is null)
        {
            _notificationContext.AddNotification("User invalid");
            return false;
        }

        _unitOfWork.UserRepository.Delete(user);

        await _unitOfWork.CommitAsync();

        return true;
    }
}

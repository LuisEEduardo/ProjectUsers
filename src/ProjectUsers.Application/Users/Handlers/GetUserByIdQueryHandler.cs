using MediatR;
using ProjectUsers.Application.Users.Commands.Response;
using ProjectUsers.Application.Users.Queries.Request;
using ProjectUsers.Domain.Notifications;
using ProjectUsers.Domain.Repositories;

namespace ProjectUsers.Application.Users.Handlers
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, ListUserResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationContext _notificationContext;

        public GetUserByIdQueryHandler(IUnitOfWork unitOfWork, INotificationContext notificationContext)
        {
            _unitOfWork = unitOfWork;
            _notificationContext = notificationContext;
        }

        public async Task<ListUserResponse> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.Id);

            if (user is null)
            {
                _notificationContext.AddNotification("user not found");
                return null;
            }

            return new ListUserResponse(user.Id, user.Name, user.Email, user.Role);
        }
    }
}

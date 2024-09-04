using AutoMapper;
using MediatR;
using ProjectUsers.Application.Users.Commands.Response;
using ProjectUsers.Application.Users.Queries.Request;
using ProjectUsers.Domain.Notifications;
using ProjectUsers.Domain.Repositories;

namespace ProjectUsers.Application.Users.Handlers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, List<ListUserResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly INotificationContext _notificationContext;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, INotificationContext notificationContext, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _notificationContext = notificationContext;
        _mapper = mapper;
    }

    public async Task<List<ListUserResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _unitOfWork.UserRepository.GetAllAsync();

        if (users is null)
        {
            _notificationContext.AddNotification("users not found");
            return null;
        }

        return _mapper.Map<List<ListUserResponse>>(users);
    }
}

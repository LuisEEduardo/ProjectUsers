using FluentValidation;
using ProjectUsers.Domain.Entities;

namespace ProjectUsers.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
           
        }
    }
}

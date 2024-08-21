using FluentValidation;
using ProjectUsers.Domain.Entities;

namespace ProjectUsers.Domain.Validations
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(u => u.Name)
                 .NotNull()
                 .WithMessage("The {PropertyName} is required")
                 .NotEmpty()
                 .WithMessage("{PropertyName} is not empty")
                 .Length(1, 200)
                 .WithMessage("{PropertyName} must be between 1 and 200 characters.");

            RuleFor(u => u.Email)
                 .NotNull()
                 .WithMessage("The {PropertyName} is required")
                 .NotEmpty()
                 .WithMessage("{PropertyName} is not empty")
                 .Length(1, 256)
                 .WithMessage("{PropertyName} must be between 1 and 256 characters.");

            RuleFor(u => u.Role)
                 .NotNull()
                 .WithMessage("The {PropertyName} is required");
        }
    }
}

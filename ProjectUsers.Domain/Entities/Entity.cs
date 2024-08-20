using FluentValidation;
using FluentValidation.Results;

namespace ProjectUsers.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? UpdatedAt { get; protected set; }
        public bool Valid { get; private set; }
        public ValidationResult ValidationResult { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now.AddMinutes(-3);
            UpdatedAt = null;
        }

        public bool Validate<Model>(Model model, AbstractValidator<Model> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}

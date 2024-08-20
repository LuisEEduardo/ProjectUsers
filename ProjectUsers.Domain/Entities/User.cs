using ProjectUsers.Domain.Validations;

namespace ProjectUsers.Domain.Entities
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }

        public User() { }

        public User(string name, string email, Role role)
        {
            Name = name;
            Email = email;
            Role = role;

            Validate(this, new UserValidation());
        }        
    }
}

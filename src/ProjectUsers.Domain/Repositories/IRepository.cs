using ProjectUsers.Domain.Entities;
using System.Linq.Expressions;

namespace ProjectUsers.Domain.Repositories
{
    public interface IRepository<Model> where Model : Entity
    {
        Task<Model> GetByIdAsync(Guid id);

        Task<Model> GetByPredicateAsync(Expression<Func<Model, bool>> predicate);

        Task<IList<Model>> GetAllAsync();

        void Create(Model model);

        void Update(Model model);

        void Delete(Model model);

        Task<bool> ExistPredicateAsync(Expression<Func<Model, bool>> predicate);
    }
}
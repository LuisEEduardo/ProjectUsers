using Microsoft.EntityFrameworkCore;
using ProjectUsers.Data.Context;
using ProjectUsers.Domain.Entities;
using ProjectUsers.Domain.Repositories;
using System.Linq.Expressions;

namespace ProjectUsers.Data.Repositories
{
    public class Repository<Model> : IRepository<Model> where Model : Entity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Model> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<Model>();
        }

        public async Task<IList<Model>> GetAllAsync()
            => await _dbSet.AsNoTracking().ToListAsync();

        public async Task<Model> GetByIdAsync(Guid id)
            => await _dbSet.FirstOrDefaultAsync(u => u.Id.Equals(id));

        public async Task<Model> GetByPredicateAsync(Expression<Func<Model, bool>> predicate)
            => await _dbSet.FirstOrDefaultAsync(predicate);

        public void Create(Model model)
        {
            _dbSet.AddAsync(model);            
        }

        public void Update(Model model)
        {
            _dbSet.Update(model);            
        }

        public void Delete(Model model)
        {
            _dbSet.Remove(model);
        }

        public async Task<bool> ExistPredicateAsync(Expression<Func<Model, bool>> predicate)
            => await _dbSet.AnyAsync(predicate);
    }
}
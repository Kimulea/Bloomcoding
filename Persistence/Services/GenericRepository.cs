using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private BloomcodingContext _context;
        private DbSet<T> _table;

        public GenericRepository(BloomcodingContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public Task Remove(T entity)
        {
            _table.Remove(entity);
            return _context.SaveChangesAsync();
        }
        public Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _table.FirstOrDefaultAsync(predicate);
        }

        public async Task<T> GetById(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToArrayAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToArrayAsync();
        }

        public async Task<int> CountAll()
        {
            return await _table.CountAsync();
        }

        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return await _table.CountAsync(predicate); 
        }
    }
}

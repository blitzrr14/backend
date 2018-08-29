namespace repository 
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using repository.interfaces;
    using Microsoft.EntityFrameworkCore;
    using dal.interfaces;

    public class ReadOnlyRepository<TContext> : IReadOnlyRepository
    where TContext : DbContext
    {
        protected readonly TContext _context;

        public ReadOnlyRepository(TContext context) => _context = context;
        public async Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties, int? skip, int? take)
        where TEntity : class , IEntity
        {
            return await GetQueryable<TEntity>(null,orderBy,includeProperties,skip,take).ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> GetManyWithFilter<TEntity>(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
             string includeProperties, int? skip, int? take)
        where TEntity : class , IEntity
        {
            return await GetQueryable<TEntity>(filter,orderBy,includeProperties,skip,take).ToListAsync();

        }


        Task<TEntity> IReadOnlyRepository.GetByIdAsync<TEntity>(object id)
        {

          //  var x = GetQueryable<TEntity>(i=>);
           return  _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetFirst<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties)
        where TEntity : class , IEntity
        {

            return await GetQueryable<TEntity>(filter, orderBy, includeProperties).FirstOrDefaultAsync();
        
        }

        public virtual IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, string includeProperties = null, int? skip = null, int? take=null)
        where TEntity : class, IEntity
        {

             includeProperties = includeProperties ?? string.Empty;
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query;
        }

    
    }
}
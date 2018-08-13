using System;
using System.Threading.Tasks;
using dal.interfaces;

namespace repository.interfaces
{
    public interface IRepository : IReadOnlyRepository
    {

        void Save();

        Task SaveAsync();

        void Create<TEntity>(TEntity entity, string createdBy) where TEntity : class, IEntity;
        void Update<TEntity>(TEntity entity) where TEntity : class, IEntity;
        void Delete<TEntity>(object id) where TEntity : class , IEntity;




    }

}
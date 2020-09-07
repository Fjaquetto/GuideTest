using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuideAPI.Domain.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> ObterTodos();
        Task Adicionar(TEntity entity);
        Task<int> SaveChanges();
    }
}

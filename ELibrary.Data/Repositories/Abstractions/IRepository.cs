using System.Linq;

namespace ELibrary.Data.Repositories.Abstractions
{
    public interface IRepository<T>
    {
        T Get(int id);
        IQueryable<T> Get();
        T Save(T model);
        T Update(T model);
        IQueryable<T> Delete(T model);
    }
}
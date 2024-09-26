using SharedKernel.Domain.Entities;
using SharedKernel.Shared.ResultPattern;

namespace SharedKernel.Persistence.RepositroyPattern;

public interface IRepository<TEntity>
        where TEntity : Entity
{
    // CRUD operations

    #region Create operation
    public Result<TEntity> Create(TEntity entity);
    #endregion

    #region Read operations
    public Result<TEntity> GetById(Guid id);
    public Result<ICollection<TEntity>> GetAll();
    #endregion

    #region Update oprtation
    public Result Update(TEntity entity);
    #endregion

    #region Delete operation
    public Result Delete(TEntity entity);
    #endregion
}
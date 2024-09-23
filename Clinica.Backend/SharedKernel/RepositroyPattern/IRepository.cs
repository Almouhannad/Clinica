using SharedKernel.Entities;
using SharedKernel.ResultPattern;

namespace SharedKernel.RepositroyPattern;

public interface IRepository<TEntity>
        where TEntity : Entity
{
    // CRUD operations

    #region Create operation

    public Task<Result<TEntity>> CreateAsync(TEntity entity);

    #endregion

    #region Read operations

    public Result<TEntity> GetById(Guid id);

    public Result<ICollection<TEntity>> GetAll();

    #endregion

    #region Update oprtation

    public Task<Result> UpdateAsync(TEntity entity);

    #endregion

    #region Delete operation

    public Task<Result> DeleteAsync(TEntity entity);

    #endregion
}
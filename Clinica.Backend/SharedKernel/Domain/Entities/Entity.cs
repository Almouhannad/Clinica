namespace SharedKernel.Domain.Entities;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
    }

    #region Properties
    // Init is to ensure that Id is unchangable
    public Guid Id { get; private init; }
    #endregion

    #region Equality by matching Id
    public override bool Equals(object? obj)
    {
        if (InvalidType(obj))
        {
            return false;
        }

        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }

    public bool Equals(Entity other)
    {
        if (InvalidType(other))
        {
            return false;
        }
        return other.Id == Id;
    }

    public static bool operator ==(Entity? first, Entity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity? first, Entity? second)
    {
        return !(first == second);
    }

    private bool InvalidType(object? obj)
    {
        return obj is null || obj.GetType() != GetType();
    }

    #endregion

    #region Custom hash code for collections

    // For dealing with collections
    public override int GetHashCode()
    {
        // It's a best practice to mult by prime number when defining custom hash code
        return Id.GetHashCode() * 41;
    }

    #endregion
}
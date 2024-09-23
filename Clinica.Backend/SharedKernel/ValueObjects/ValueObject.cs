namespace SharedKernel.ValueObjects;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();

    #region Equality by value
    public bool Equals(ValueObject? other)
    {
        return other is not null && ValuesAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        return obj is ValueObject other && ValuesAreEqual(other);
    }

    private bool ValuesAreEqual(ValueObject other)
    {
        return GetAtomicValues().SequenceEqual(other.GetAtomicValues());
    }
    #endregion

    #region Custom hash code
    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(
            default(int),
            HashCode.Combine);
    }

    #endregion

}

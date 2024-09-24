using Domain.ValueObjects.PersonalData;
using SharedKernel.Entities;

namespace Domain.Entities.People.Base;

public abstract class Person : Entity
{
    #region Private ctor
    internal Person(Guid id) : base(id)
    {
    }
    internal Person(Guid id, Data personalData) : base(id)
    {
        PersonalData = personalData;
    }
    #endregion

    #region Properties
    public Data PersonalData { get; private set; } = null!;
    #endregion
}

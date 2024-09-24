using Domain.ValueObjects.PersonalData;
using Domain.ValueObjects.PersonalData.Genders;
using SharedKernel.Entities;
using SharedKernel.ResultPattern;

namespace Domain.Entities.People.Patients;

public class Patient : Entity
{

    #region Private ctor
    private Patient(Guid id) : base(id)
    {
    }

    private Patient(Guid id, Data personalData) : base(id)
    {
        PersonalData = personalData;
    }
    #endregion

    #region Properties
    public Data PersonalData { get; set; } = null!;
    #endregion

    #region Factory
    public static Result<Patient> Create(string firstName, string middleName, string lastName,
        Gender gender, DateOnly dateOfBirth)
    {
        #region 1. Create data
        var createDataResult = Data.Create(firstName, middleName, lastName,
            gender, dateOfBirth);
        if (createDataResult.IsFailure)
            return Result.Failure<Patient>(createDataResult.Error);
        var data = createDataResult.Value;
        #endregion

        #region 2. Create new patient
        var patient = new Patient(Guid.NewGuid(), data);
        return patient;
        #endregion
    }
    #endregion
}

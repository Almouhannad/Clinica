using Domain.Entities.People.Base;
using Domain.ValueObjects.PersonalData;
using Domain.ValueObjects.PersonalData.Genders;
using SharedKernel.ResultPattern;

namespace Domain.Entities.People.Patients;

public class Patient : Person
{
    #region Private ctor
    private Patient(Guid id) : base(id)
    {
    }

    private Patient(Guid id, Data personalData) : base(id, personalData)
    {
    }
    #endregion

    #region Factory
    public static Result<Patient> Create(string firstName, string middleName, string lastName,
        Gender gender, DateOnly dateOfBirth)
    {
        #region 1. Create personal data
        var createPersonalDataResult = Data.Create(firstName, middleName, lastName,
            gender, dateOfBirth);
        if (createPersonalDataResult.IsFailure)
            return Result.Failure<Patient>(createPersonalDataResult.Error);
        var data = createPersonalDataResult.Value;
        #endregion

        #region 2. Create new patient
        var patient = new Patient(Guid.NewGuid(), data);
        #endregion

        return patient;
    }
    #endregion
}

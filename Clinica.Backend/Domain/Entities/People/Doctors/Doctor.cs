using Domain.ValueObjects.PersonalData.Genders;
using Domain.ValueObjects.PersonalData;
using SharedKernel.ResultPattern;
using Domain.Entities.People.Base;

namespace Domain.Entities.People.Doctors;

public class Doctor : Person
{
    #region Private ctor
    private Doctor(Guid id) : base(id)
    {
    }

    private Doctor(Guid id, Data personalData) : base(id, personalData)
    {
    }
    #endregion

    #region Factory
    public static Result<Doctor> Create(string firstName, string middleName, string lastName,
        Gender gender, DateOnly dateOfBirth)
    {
        #region 1. Create personal data
        var createPersonalDataResult = Data.Create(firstName, middleName, lastName,
            gender, dateOfBirth);
        if (createPersonalDataResult.IsFailure)
            return Result.Failure<Doctor>(createPersonalDataResult.Error);
        var data = createPersonalDataResult.Value;
        #endregion

        #region 2. Create new doctor
        var doctor = new Doctor(Guid.NewGuid(), data);
        #endregion

        return doctor;
    }
    #endregion
}

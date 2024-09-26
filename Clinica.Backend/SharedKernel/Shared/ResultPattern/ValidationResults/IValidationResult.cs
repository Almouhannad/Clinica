namespace SharedKernel.Shared.ResultPattern.ValidationResults;

public interface IValidationResult
{
    public static readonly Error ValidationError
        = new("ValidationError", "القيم المدخلة غير صالحة");

    #region Properties
    Error[] Errors { get; }
    #endregion
}
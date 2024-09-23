namespace SharedKernel.ResultPattern;

public class Result
{

    #region Ctor
    private Result(bool isSuccess, Error error)
    {
        IsSuccess = isSuccess;
        Error = error;
    }
    #endregion

    #region Properties
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }
    #endregion

    #region Methods

    #region Static factory
    public static Result Create(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException("Successful result can't have error.");
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException("Failure result must have error.");
        }

        return new Result(isSuccess, error);
    }
    #endregion

    #endregion

    #region Statics
    public static Result Success() => new(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => Result<TValue>.Create(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    public static Result<TValue> Failure<TValue>(Error error) => Result<TValue>.Create(default, false, error);

    public static Result<TValue> Create<TValue>(TValue? value) => value is not null ? Success(value) : Failure<TValue>(Error.NullValue);
    #endregion
}
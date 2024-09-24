using SharedKernel.ResultPattern;

namespace Domain.Errors;

public static class DomainErrors
{
    private readonly static Error _invalidInputValues = new("Domain.InvalidInputValues", "القيم المدخلة غير صالحة");
    public static Error InvalidInputValues => _invalidInputValues;
}

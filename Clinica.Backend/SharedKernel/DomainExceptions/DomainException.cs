namespace SharedKernel.DomainExceptions;

public abstract class DomainException : Exception
{
    protected DomainException(string message) :
        base("(Domain exception) " + message)
    {
    }
}
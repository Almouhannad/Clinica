using MediatR;
using SharedKernel.ResultPattern;

namespace SharedKernel.CQRSPattern.Commands;

// No response
public interface ICommand : IRequest<Result>
{
}

// With response
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
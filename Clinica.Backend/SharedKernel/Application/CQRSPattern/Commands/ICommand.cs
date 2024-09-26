using MediatR;
using SharedKernel.Shared.ResultPattern;

namespace SharedKernel.Application.CQRSPattern.Commands;

// No response
public interface ICommand : IRequest<Result>
{
}

// With response
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
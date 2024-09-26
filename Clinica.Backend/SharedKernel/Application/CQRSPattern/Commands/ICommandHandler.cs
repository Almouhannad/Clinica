using MediatR;
using SharedKernel.Shared.ResultPattern;

namespace SharedKernel.Application.CQRSPattern.Commands;

// No response
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

// With response
public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{
}
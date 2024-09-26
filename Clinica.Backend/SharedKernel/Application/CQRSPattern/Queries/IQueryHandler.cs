using MediatR;
using SharedKernel.Shared.ResultPattern;

namespace SharedKernel.Application.CQRSPattern.Queries;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
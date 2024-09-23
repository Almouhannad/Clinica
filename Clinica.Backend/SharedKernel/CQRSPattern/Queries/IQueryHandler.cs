using MediatR;
using SharedKernel.ResultPattern;

namespace SharedKernel.CQRSPattern.Queries;

public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
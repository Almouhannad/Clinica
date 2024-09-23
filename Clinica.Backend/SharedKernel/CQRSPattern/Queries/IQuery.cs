using MediatR;
using SharedKernel.ResultPattern;

namespace SharedKernel.CQRSPattern.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
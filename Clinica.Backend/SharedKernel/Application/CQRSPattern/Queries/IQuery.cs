using MediatR;
using SharedKernel.Shared.ResultPattern;

namespace SharedKernel.Application.CQRSPattern.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
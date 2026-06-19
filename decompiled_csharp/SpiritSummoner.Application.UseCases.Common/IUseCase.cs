using System.Threading.Tasks;

namespace SpiritSummoner.Application.UseCases.Common;

public interface IUseCase<TRequest, TResponse>
{
	global::System.Threading.Tasks.Task<Result<TResponse>> ExecuteAsync(TRequest request);
}
public interface IUseCase<TResponse>
{
	global::System.Threading.Tasks.Task<Result<TResponse>> ExecuteAsync();
}

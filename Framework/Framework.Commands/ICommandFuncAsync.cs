using System.Threading.Tasks;

namespace Framework.Commands
{
    public interface ICommandFuncAsync<TInput, TOutput> where TOutput: class, new()
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }
}
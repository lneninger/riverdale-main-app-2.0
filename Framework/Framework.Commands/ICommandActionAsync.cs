
using System.Threading.Tasks;

namespace Framework.Commands
{
    public interface ICommandActionAsync<TOutput>: ICommand
    {
        Task<TOutput> ExecuteAsync();
    }

}
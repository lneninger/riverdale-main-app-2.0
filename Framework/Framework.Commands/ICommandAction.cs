
namespace Framework.Commands
{
    public interface ICommandAction<TOutput>: ICommand
    {
        TOutput Execute();
    }

}
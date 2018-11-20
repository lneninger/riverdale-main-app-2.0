using FocusApplication.Business.Commands;

namespace FocusServices.Business.Commands
{
    public interface ICommandAction<TOutput>: ICommand
    {
        TOutput Execute();
    }

}
namespace FocusServices.Business.Commands
{
    public interface ICommandFunc<TInput, TOutput> where TInput: new() where TOutput: class, new()
    {
        TOutput Execute(TInput input);
    }
}
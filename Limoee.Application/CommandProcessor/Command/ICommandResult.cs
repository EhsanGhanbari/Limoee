namespace Limoee.Application.CommandProcessor.Command
{
    public interface ICommandResult
    {
        string Message { get; }
        bool Success { get; }
    }
}
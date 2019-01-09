namespace Limoee.Application.CommandProcessor.Command
{
    public abstract class CommandResult : ICommandResult
    {
        public string Message { get; protected set; }
        public bool Success { get; protected set; }
    }

    public class FailureResult : CommandResult
    {
        public FailureResult(string message)
        {
            Success = false;
            Message = message;
        }
    }
    public class SuccessResult : CommandResult
    {
        public SuccessResult(string message)
        {
            Success = true;
            Message = message;
        }
    }
}
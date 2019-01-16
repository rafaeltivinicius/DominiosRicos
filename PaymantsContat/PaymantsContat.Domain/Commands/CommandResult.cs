using PaymantsContat.Shared.Commands;

namespace PaymantsContat.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; private set; }

        public CommandResult(){}
        public CommandResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

    } 
}   
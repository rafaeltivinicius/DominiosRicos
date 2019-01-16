using PaymantsContat.Shared.Commands;

namespace PaymantsContat.Shared.Handlers
{
 public interface IHandler<T> where T : ICommand 
 {
     ICommandResult Handle(T commad);
 }
}
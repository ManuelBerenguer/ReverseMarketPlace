using ReverseMarketPlace.Common.Types.Messages;
using ReverseMarketPlace.Common.Types.MessageBroker;
using System.Threading.Tasks;

namespace ReverseMarketPlace.Common.Types.Handlers
{
    /// <summary>
    /// Prototype for any command handler built following the Command Query Responsability Segregation (CQRS).
    /// </summary>
    /// <typeparam name="T">Command to handle</typeparam>
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}

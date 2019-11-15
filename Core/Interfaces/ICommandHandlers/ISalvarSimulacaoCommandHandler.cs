using Core.DTOs;

namespace Core.Interfaces.ICommandHandlers
{
    public interface ISalvarSimulacaoCommandHandler
    {
        bool Handle(CompraDTO command);
    }
}

using Core.Commands;
using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces.IServices
{
    public interface ICompraService
    {
        bool Salvar(CompraCommand compra);
        IEnumerable<Compra> GetAll();
    }
}

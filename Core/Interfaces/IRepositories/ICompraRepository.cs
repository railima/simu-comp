using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICompraRepository
    {
        void Salvar(Compra compra);
        IEnumerable<Compra> GetAll();
    }
}

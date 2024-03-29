﻿using Core.DTOs;
using Core.Entities;
using System.Collections.Generic;

namespace Core.Interfaces.IServices
{
    public interface ICompraService
    {
        bool Salvar(CompraDTO compra);
        IEnumerable<CompraDTO> GetAll();
        CompraDTO Simular(double valor, double juros, int quantidadeParcela, System.DateTime data);
    }
}

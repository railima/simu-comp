using Core.Entities;
using Core.Interfaces;
using Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class CompraRepository : ICompraRepository
    {
        private readonly CompraContext _db;

        public CompraRepository(CompraContext db)
        {
            _db = db;
        }

        public IEnumerable<Compra> GetAll()
        {
            return _db.Compras.ToList();
        }

        public void Salvar(Compra compra)
        {
            _db.Compras.Add(compra);
            _db.SaveChanges();
        }
    }
}

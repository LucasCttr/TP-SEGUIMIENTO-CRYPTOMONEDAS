﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICryptoCurrencyRepository CryptosFavoritas { get; private set; }
        public IUserRepository Usuarios { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CryptosFavoritas = new CryptoCurrencyRepository(_context);
            Usuarios = new UserRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

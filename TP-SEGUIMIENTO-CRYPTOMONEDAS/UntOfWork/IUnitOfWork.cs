using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICryptosFavoritasRepository CryptosFavoritas { get; }
        IUserRepository Usuarios { get; }
        IAlertaRepository Alerta { get; }

        void Save();
    }
}

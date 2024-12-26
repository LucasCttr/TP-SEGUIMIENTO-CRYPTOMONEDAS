using Microsoft.Extensions.DependencyInjection;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using System.Configuration;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Controllers;


namespace TP_SEGUIMIENTO_CRYPTOMONEDAS
{
        static class Program
        {
        [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Configuraci�n de opciones para el DbContext
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                // Cadena de conexi�n a la base de datos
                optionsBuilder.UseSqlServer("server=MARTIN\\SQLEXPRESS; database=CryptoApp; integrated security=true;TrustServerCertificate = True");
                //optionsBuilder.UseSqlServer("server=LUCAS\\SQLEXPRESS; database=CryptoApp; integrated security=true;TrustServerCertificate = True");

                // Crear el contexto pasando las opciones
                using (var context = new AppDbContext(optionsBuilder.Options))
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    AlertaController _alertaController = new AlertaController(unitOfWork);
                    CryptosFavoritasController _cryptosFavoritasController = new CryptosFavoritasController(unitOfWork);
                    UsuarioController _usuarioController = new UsuarioController(unitOfWork);

                    Application.Run(new LoginForm(_alertaController,_cryptosFavoritasController, _usuarioController));
                }
            }
        }

    
}
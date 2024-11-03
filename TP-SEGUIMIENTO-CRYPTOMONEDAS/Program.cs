using Microsoft.Extensions.DependencyInjection;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using System.Configuration;


namespace TP_SEGUIMIENTO_CRYPTOMONEDAS
{
        static class Program
        {
        [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Configuración de opciones para el DbContext
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                // Aquí asegúrate de utilizar tu cadena de conexión real
                optionsBuilder.UseSqlServer("server=LUCAS\\SQLEXPRESS; database=Seguimiento_Cryptos; integrated security=true;TrustServerCertificate = True");

                // Crear el contexto pasando las opciones
                using (var context = new AppDbContext(optionsBuilder.Options))
                {
                    IUnitOfWork unitOfWork = new UnitOfWork(context);
                    Application.Run(new LoginForm(unitOfWork));
                }
            }
        }

    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs; // Importa la capa de DTOs para manejar datos entre capas.
using Microsoft.EntityFrameworkCore; // Necesario para trabajar con Entity Framework Core.
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio; // Importa las entidades del dominio.

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Data
{
    // Clase que define el contexto para Entity Framework.
    public class AppDbContext : DbContext
    {
        // Constructor que recibe opciones de configuración (como la cadena de conexión).
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet representa las tablas en la base de datos.
        public DbSet<CryptoDTO> CryptosFavoritas { get; set; } // Tabla para las criptomonedas favoritas.
        public DbSet<Usuario> Usuarios { get; set; } // Tabla para los usuarios.
        public DbSet<Favoritas> UsuariosCryptos { get; set; } // Relación entre usuarios y sus criptomonedas favoritas.
        public DbSet<Alerta> Alertas { get; set; } // Tabla para las alertas configuradas.

        // Configuración adicional de las entidades usando Fluent API.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Llama a la configuración base.
            base.OnModelCreating(modelBuilder);

            // Configuración de la tabla Usuarios.
            modelBuilder.Entity<Usuario>().ToTable("Usuarios"); // Nombre de la tabla en la base de datos.
            modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioID); // Clave primaria.
            modelBuilder.Entity<Usuario>().Property(u => u.Nombre)
                .IsRequired() // Campo obligatorio.
                .HasMaxLength(20); // Longitud máxima de 20 caracteres.
            modelBuilder.Entity<Usuario>().Property(u => u.Contraseña)
                .IsRequired()
                .HasMaxLength(100); // Longitud máxima de 100 caracteres.
            modelBuilder.Entity<Usuario>().Property(u => u.Correo)
                .IsRequired()
                .HasMaxLength(50); // Longitud máxima de 50 caracteres.

            // Configuración de la tabla Favoritas (CryptomonedasFavoritas).
            modelBuilder.Entity<Favoritas>().ToTable("CryptomonedasFavoritas");
            modelBuilder.Entity<Favoritas>().HasKey(f => f.FavoritoID); // Clave primaria.
            modelBuilder.Entity<Favoritas>().Property(f => f.CryptomonedaID)
                .IsRequired()
                .HasMaxLength(50); // Campo obligatorio y con longitud máxima.
            modelBuilder.Entity<Favoritas>().Property(f => f.UsuarioID)
                .IsRequired()
                .HasMaxLength(50); // Campo obligatorio y con longitud máxima.

            // Configuración de la tabla Alertas.
            modelBuilder.Entity<Alerta>().ToTable("Alertas");
            modelBuilder.Entity<Alerta>().HasKey(a => a.AlertaID); // Clave primaria.
            modelBuilder.Entity<Alerta>().Property(a => a.UsuarioID)
                .IsRequired()
                .HasMaxLength(100); // Campo obligatorio.
            modelBuilder.Entity<Alerta>().Property(a => a.CambioPorcentual)
                .HasColumnType("decimal(5,2)"); // Tipo de dato decimal con 5 dígitos y 2 decimales.
            modelBuilder.Entity<Alerta>().Property(a => a.FechaActivasion)
                .HasColumnType("DateTime"); // Define el tipo de dato DateTime.
            modelBuilder.Entity<Alerta>().Property(a => a.TipoCambio)
                .HasMaxLength(20); // Define la longitud máxima de 20 caracteres para el campo TipoCambio.
            modelBuilder.Entity<Alerta>().Property(a => a.CryptomonedaID)
                .HasMaxLength(50); // Define la longitud máxima de 50 caracteres para el campo CryptomonedaID.
        }
    }
}
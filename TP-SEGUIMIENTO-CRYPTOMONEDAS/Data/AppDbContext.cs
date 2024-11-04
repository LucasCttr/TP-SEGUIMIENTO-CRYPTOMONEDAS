using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using Microsoft.EntityFrameworkCore;


    namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Data
    {
        public class AppDbContext : DbContext
        {
            // Constructor que recibe opciones de configuración
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            // DbSet para cada entidad
            public DbSet<CryptoCurrencyDTO> CryptosFavoritas { get; set; }
            public DbSet<UserDTO> Usuarios { get; set; }
            public DbSet<UsuarioCryptoDTO> UsuariosCryptos { get; set; }

            // Configuración adicional de las entidades
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configuración de la tabla para CryptoCurrencyDTO
                modelBuilder.Entity<CryptoCurrencyDTO>().ToTable("CryptosFavoritass");
                modelBuilder.Entity<CryptoCurrencyDTO>().HasKey(c => c.id);
                modelBuilder.Entity<CryptoCurrencyDTO>().Property(c => c.name).IsRequired().HasMaxLength(50);  // Nombre obligatorio, máx. 50 caracteres
                modelBuilder.Entity<CryptoCurrencyDTO>().Property(c => c.symbol).IsRequired().HasMaxLength(10);  // Símbolo obligatorio, máx. 10 caracteres
                modelBuilder.Entity<CryptoCurrencyDTO>().Property(c => c.priceUsd).HasColumnType("decimal(18,2)");
                modelBuilder.Entity<CryptoCurrencyDTO>().Property(c => c.changePercent24Hr).HasMaxLength(10);

                // Configuración de la tabla para UserDTO
                modelBuilder.Entity<UserDTO>().ToTable("Usuarios");
                modelBuilder.Entity<UserDTO>().HasKey(u => u.Id);
                modelBuilder.Entity<UserDTO>().Property(u => u.NombreUsuario).IsRequired().HasMaxLength(20);  // Nombre de usuario obligatorio, máx. 20 caracteres
                modelBuilder.Entity<UserDTO>().Property(u => u.Contrasena).IsRequired().HasMaxLength(100);  // Contraseña obligatoria, máx. 100 caracteres
                modelBuilder.Entity<UserDTO>().Property(u => u.Mail).IsRequired().HasMaxLength(50);  // Correo obligatorio, máx. 50 caracteres

            // Configuración de la tabla para UserDTO
                modelBuilder.Entity<UsuarioCryptoDTO>().ToTable("CryptosFavoritas");
                modelBuilder.Entity<UsuarioCryptoDTO>().HasKey(u => u.FavoritoID);
                modelBuilder.Entity<UsuarioCryptoDTO>().Property(u => u.CryptoID).IsRequired().HasMaxLength(100);  
                modelBuilder.Entity<UsuarioCryptoDTO>().Property(u => u.UsuarioID).IsRequired().HasMaxLength(100);  
                modelBuilder.Entity<UsuarioCryptoDTO>().Property(u => u.ValorAlerta).HasColumnType("decimal(18,2)"); 
            }
        }
    }

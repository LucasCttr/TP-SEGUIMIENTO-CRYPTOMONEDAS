using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using Microsoft.EntityFrameworkCore;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;


    namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Data
    {
        public class AppDbContext : DbContext
        {
            // Constructor que recibe opciones de configuración
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            // DbSet para cada entidad
            public DbSet<CryptoDTO> CryptosFavoritas { get; set; }
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<UsuarioCryptoDTO> UsuariosCryptos { get; set; }
            public DbSet<AlertaDTO> Alertas { get; set; }
            

            // Configuración adicional de las entidades
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                //// Configuración de la tabla para CryptoCurrencyDTO
                //modelBuilder.Entity<CryptoDTO>().ToTable("Cryptos");
                //modelBuilder.Entity<CryptoDTO>().HasKey(c => c.id);
                //modelBuilder.Entity<CryptoDTO>().Property(c => c.name).IsRequired().HasMaxLength(50);  // Nombre obligatorio, máx. 50 caracteres
                //modelBuilder.Entity<CryptoDTO>().Property(c => c.symbol).IsRequired().HasMaxLength(10);  // Símbolo obligatorio, máx. 10 caracteres
                //modelBuilder.Entity<CryptoDTO>().Property(c => c.priceUsd).HasColumnType("decimal(18,2)");
                //modelBuilder.Entity<CryptoDTO>().Property(c => c.changePercent24Hr).HasColumnType("decimal(18,2)");
                //modelBuilder.Entity<CryptoDTO>().Property(c => c.maxSupply).HasColumnType("decimal(18,2)");
                //modelBuilder.Entity<CryptoDTO>().Property(c => c.vwap24Hr).HasColumnType("decimal(18,2)");

            // Configuración de la tabla para UserDTO
                modelBuilder.Entity<Usuario>().ToTable("Usuarios");
                modelBuilder.Entity<Usuario>().HasKey(u => u.UsuarioID);
                modelBuilder.Entity<Usuario>().Property(u => u.Nombre).IsRequired().HasMaxLength(20);  // Nombre de usuario obligatorio, máx. 20 caracteres
                modelBuilder.Entity<Usuario>().Property(u => u.Contraseña).IsRequired().HasMaxLength(100);  // Contraseña obligatoria, máx. 100 caracteres
                modelBuilder.Entity<Usuario>().Property(u => u.Correo).IsRequired().HasMaxLength(50);  // Correo obligatorio, máx. 50 caracteres

            // Configuración de la tabla para UserDTO
                modelBuilder.Entity<UsuarioCryptoDTO>().ToTable("CryptomonedasFavoritas");
                modelBuilder.Entity<UsuarioCryptoDTO>().HasKey(u => u.FavoritoID);
                modelBuilder.Entity<UsuarioCryptoDTO>().Property(u => u.CryptomonedaID).IsRequired().HasMaxLength(50);  
                modelBuilder.Entity<UsuarioCryptoDTO>().Property(u => u.UsuarioID).IsRequired().HasMaxLength(50);  


                modelBuilder.Entity<AlertaDTO>().ToTable("Alertas");
                modelBuilder.Entity<AlertaDTO>().HasKey(u => u.AlertaID);
                modelBuilder.Entity<AlertaDTO>().Property(u => u.UsuarioID).IsRequired().HasMaxLength(100);  
                modelBuilder.Entity<AlertaDTO>().Property(u => u.CambioPorcentual).HasColumnType("decimal(5,2)");
                modelBuilder.Entity<AlertaDTO>().Property(u => u.FechaActivasion).HasColumnType("DateTime");
                modelBuilder.Entity<AlertaDTO>().Property(u => u.TipoCambio).HasColumnType("HasMaxLength(20)");
                modelBuilder.Entity<AlertaDTO>().Property(u => u.CryptomonedaID).HasColumnType("HasMaxLength(50)"); 
        }
        }
    }

﻿using System;
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
            public DbSet<CryptoDTO> CryptosFavoritas { get; set; }
            public DbSet<UserDTO> Usuarios { get; set; }
            public DbSet<UsuarioCryptoDTO> UsuariosCryptos { get; set; }
            public DbSet<AlertaDTO> AlertasCrypto { get; set; }
            

            // Configuración adicional de las entidades
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                // Configuración de la tabla para CryptoCurrencyDTO
                modelBuilder.Entity<CryptoDTO>().ToTable("CryptosFavoritass");
                modelBuilder.Entity<CryptoDTO>().HasKey(c => c.id);
                modelBuilder.Entity<CryptoDTO>().Property(c => c.name).IsRequired().HasMaxLength(50);  // Nombre obligatorio, máx. 50 caracteres
                modelBuilder.Entity<CryptoDTO>().Property(c => c.symbol).IsRequired().HasMaxLength(10);  // Símbolo obligatorio, máx. 10 caracteres
                modelBuilder.Entity<CryptoDTO>().Property(c => c.priceUsd).HasColumnType("decimal(18,2)");
                modelBuilder.Entity<CryptoDTO>().Property(c => c.changePercent24Hr).HasMaxLength(10);

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
                modelBuilder.Entity<UsuarioCryptoDTO>().Property(u => u.ValorPositivo).HasColumnType("decimal(5,2)");
                modelBuilder.Entity<UsuarioCryptoDTO>().Property(u => u.ValorNegativo).HasColumnType("decimal(5,2)");
                modelBuilder.Entity<UsuarioCryptoDTO>().Property(u => u.CryptoNombre).HasMaxLength(50);


                modelBuilder.Entity<AlertaDTO>().ToTable("AlertasCrypto");
                modelBuilder.Entity<AlertaDTO>().HasKey(u => u.Id);
                modelBuilder.Entity<AlertaDTO>().Property(u => u.UsuarioID).IsRequired().HasMaxLength(100);  
                modelBuilder.Entity<AlertaDTO>().Property(u => u.CryptoID).IsRequired().HasColumnType("HasMaxLength(20)");  
                modelBuilder.Entity<AlertaDTO>().Property(u => u.CambioPorcentual).HasColumnType("decimal(5,2)");
                modelBuilder.Entity<AlertaDTO>().Property(u => u.FechaAlerta).HasColumnType("DateTime");
                modelBuilder.Entity<AlertaDTO>().Property(u => u.TipoCambio).HasColumnType("HasMaxLength(20)");
                modelBuilder.Entity<AlertaDTO>().Property(u => u.CryptoNombre).HasColumnType("HasMaxLength(50)");
        }
        }
    }

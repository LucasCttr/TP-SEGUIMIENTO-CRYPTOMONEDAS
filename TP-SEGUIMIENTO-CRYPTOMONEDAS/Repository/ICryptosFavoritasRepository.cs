﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using System.Collections.Generic;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public interface ICryptosFavoritasRepository
    {
        Task<List<CryptoDTO>> MostrarCryptos(); // Definición del método asíncrono
        CryptoDTO BuscarCryptoMedianteId(string IdCrypto);
        List<PuntoHistorial> ObtenerHistorialDeCrypto(string idCrypto, string intervalo);
        void EliminarFavorito(string nombreCrypto);
        void AgregarFavorito(string nombreCrypto, string idCrypto);
        bool VerificarSiEsFavorito(string idCrypto);
        //IEnumerable<CryptoCurrencyDTO> GetAll();
        // CryptoCurrencyDTO GetById(string id);
        //  void Add(CryptoCurrencyDTO cryptoCurrency);
        //   void Update(CryptoCurrencyDTO cryptoCurrency);
        //  void Delete(string id);
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using System.Collections.Generic;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public interface ICryptoCurrencyRepository
    {
        Task<List<CryptoCurrencyDTO>> MostrarCryptos(); // Definición del método asíncrono
        CryptoCurrencyDTO BuscarCryptoMedianteId(string IdCrypto);

        void EliminarFavorito(ListViewItem Crypto);
        void AgregarFavorito(ListViewItem Crypto);
        bool VerificarSiEsFavorito(string idCrypto);
        //IEnumerable<CryptoCurrencyDTO> GetAll();
        // CryptoCurrencyDTO GetById(string id);
        //  void Add(CryptoCurrencyDTO cryptoCurrency);
        //   void Update(CryptoCurrencyDTO cryptoCurrency);
        //  void Delete(string id);
    }
}

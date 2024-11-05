using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using RestSharp;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;
using Microsoft.EntityFrameworkCore;

//UTILIZO RESTSHARP
namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public class CryptoCurrencyRepository : ICryptoCurrencyRepository
    {
        private readonly AppDbContext _context;
        private readonly RestClient _client;
        // Constructor que acepta un DbContext
        public CryptoCurrencyRepository(AppDbContext context)
        {
            _client = new RestClient("https://api.coincap.io/v2/");
            _context = context;
        }

        public async Task<List<CryptoCurrencyDTO>> MostrarCryptos()
        {
            var request = new RestRequest("assets", Method.Get);
            var response = await _client.ExecuteAsync<CryptoResponse>(request);

            if (response.IsSuccessful)
            {
                return response.Data.Data; // Accede a la propiedad 'Data'
            }

            return new List<CryptoCurrencyDTO>(); // Retorna una lista vacía en caso de error
        }

        private class CryptoResponse
        {
            public List<CryptoCurrencyDTO> Data { get; set; }
        }
        private class SingleCryptoResponse
        {
            public CryptoCurrencyDTO Data { get; set; }
        }

        public CryptoCurrencyDTO BuscarCryptoMedianteId(string IdCrypto)
        {
            var request = new RestRequest($"assets/{IdCrypto}", Method.Get);
            var response = _client.Execute<SingleCryptoResponse>(request);

            if (response.IsSuccessful && response.Data?.Data != null)
            {
                return response.Data.Data; // Devuelve el objeto de criptomoneda
            }

            return null;
        }

        public void EliminarCryptoDeFavorito(string idCrypto)
        {


        }

        public void AgregarCryptoAFavorito(string idCrypto)
        {
            int userId = SessionManager.CurrentUserId;

            // Crear una nueva instancia del modelo de favorito
            var nuevoFavorito = new UsuarioCryptoDTO
            {
                UsuarioID = userId,
                ValorAlerta = 0,
                CryptoID = idCrypto
            };
            // Agregar el nuevo favorito a la base de datos
            _context.UsuariosCryptos.Add(nuevoFavorito); // Agregar la entidad

            // Mensaje de éxito
            MessageBox.Show("Criptomoneda agregada a favoritos.");
        }

        public bool VerificarSiEsFavorito(string idCrypto)
        {
            int userId = SessionManager.CurrentUserId;

            // Usar LINQ para hacer la comparación correctamente
            var crypto = _context.UsuariosCryptos
                .FirstOrDefault(u => u.UsuarioID == userId && u.CryptoID == idCrypto);

            // Devolver true si se encontró, false en caso contrario
            return crypto != null; // Devuelve true si existe, false si no
        }
    }
}


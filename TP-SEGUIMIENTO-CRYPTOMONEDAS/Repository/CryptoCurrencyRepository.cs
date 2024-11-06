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
using Newtonsoft.Json; // Necesitas importar esta librería

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

        private class CryptoResponse       //uTILIZAR librerias (otro metodo) para remplazar estas clases.
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

        public void EliminarFavorito(ListViewItem CryptoSeleccionada)
        {
            var cryptoFavorita = _context.UsuariosCryptos.FirstOrDefault(c => c.CryptoID == CryptoSeleccionada.SubItems[0].Text && c.UsuarioID == SessionManager.CurrentUserId);
            if (cryptoFavorita != null)
            {
                _context.UsuariosCryptos.Remove(cryptoFavorita);
                _context.SaveChanges();
            }
        }

        public void AgregarFavorito(ListViewItem CryptoSeleccionada)
        {
            int userId = SessionManager.CurrentUserId;

            // Crear una nueva instancia del modelo de favorito
            var nuevoFavorito = new UsuarioCryptoDTO
            {
                UsuarioID = userId,
                ValorAlerta = 0,
                CryptoID = CryptoSeleccionada.SubItems[0].Text
            };
            // Agregar el nuevo favorito a la base de datos
            _context.UsuariosCryptos.Add(nuevoFavorito); // Agregar la entidad
            _context.SaveChanges(); // Guardar los cambios en la base de datos
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


        // Método para obtener el historial de precios

        public List<PuntoHistorial> ObtenerHistorialDeCrypto(string cryptoId, string intervalo)
        {
            var request = new RestRequest($"assets/{cryptoId}/history?interval={intervalo}", Method.Get);
            var response = _client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserializar el JSON directamente a un objeto de tipo List<Dictionary<string, object>>
                var data = response.Content;

                var historial = new List<PuntoHistorial>();

                // Puedes usar RestSharp para hacer el parseo manual si prefieres
                dynamic resultado = Newtonsoft.Json.JsonConvert.DeserializeObject(data);
                foreach (var item in resultado.data)
                {
                    historial.Add(new PuntoHistorial
                    {
                        Fecha = DateTimeOffset.FromUnixTimeMilliseconds((long)item.time).DateTime,
                        Precio = Convert.ToDouble(item.priceUsd)
                    });
                }

                return historial;
            }
            else
            {
                Console.WriteLine("Error al obtener datos del historial: " + response.ErrorMessage);
                return new List<PuntoHistorial>();
            }


        }

    }
}


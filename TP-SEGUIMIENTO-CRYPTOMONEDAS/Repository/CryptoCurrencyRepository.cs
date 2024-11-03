using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;
using RestSharp;

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
        //public IEnumerable<CryptoCurrencyDTO> GetAll() { /* Lógica para obtener todos */ }
        //public CryptoCurrencyDTO GetById(string id) { /* Lógica para obtener por ID */ }
        //public void Add(CryptoCurrencyDTO cryptoCurrency) { /* Lógica para agregar */ }
        // public void Update(CryptoCurrencyDTO cryptoCurrency) { /* Lógica para actualizar */ }
        // public void Delete(string id) { /* Lógica para eliminar */ }
    }
}

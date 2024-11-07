using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Data;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public class AlertaRepository : IAlertaRepository
    {
        private readonly AppDbContext _context;
        private readonly RestClient _client;
        public AlertaRepository(AppDbContext context) 
        { 
            _context = context;
            _client = new RestClient("https://api.coincap.io/v2/");  //BORRAR?
        }

        public List<AlertaDTO> ObtenerAlertas()
        {
            // Accede al userId desde la sesión (suponiendo que tienes una forma de acceder a la sesión)
            int userId = SessionManager.CurrentUserId; // Cambia esto según tu implementación de sesión

            // Obtiene las criptomonedas favoritas del usuario especificado de manera síncrona
            var favoriteCryptos = _context.AlertasCrypto
                .Where(fc => fc.UsuarioID == userId)
                .AsEnumerable() // Mueve la consulta a memoria
                .Where(fc => (DateTime.Now.Date - fc.FechaAlerta).Days < 7) // Ahora puedes comparar en memoria
                .Select(fc => new AlertaDTO // Mapea a AlertaDTO
        {
                    CryptoID = fc.CryptoID,
                    CambioPorcentual = fc.CambioPorcentual,
                    FechaAlerta = fc.FechaAlerta,
                    TipoCambio = fc.TipoCambio,
                })
                .ToList(); // Usa ToList() para una operación síncrona

            return favoriteCryptos; // Retorna la lista de criptomonedas favoritas
        }
    }
}

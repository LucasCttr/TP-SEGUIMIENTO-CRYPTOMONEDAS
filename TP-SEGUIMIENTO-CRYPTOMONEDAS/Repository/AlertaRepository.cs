using RestSharp;
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

        public List<AlertaDTO> ObtenerAlertasHistorial()
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
                    CryptoNombre = fc.CryptoNombre,
                    CambioPorcentual = fc.CambioPorcentual,
                    FechaAlerta = fc.FechaAlerta,
                    TipoCambio = fc.TipoCambio,
                })
                .ToList(); // Usa ToList() para una operación síncrona

            return favoriteCryptos; // Retorna la lista de criptomonedas favoritas
        }

        public List<UsuarioCryptoDTO> ObtenerAlertasActivas()
        {
            int userId = SessionManager.CurrentUserId;

            var alertasActivas = _context.UsuariosCryptos
                .Where(fc => fc.UsuarioID == userId && (fc.ValorPositivo != 0 || fc.ValorNegativo != 0))
                .Select(fc => new UsuarioCryptoDTO
                {

                    ValorPositivo = fc.ValorPositivo,
                    ValorNegativo = fc.ValorNegativo,
                    CryptoNombre = fc.CryptoNombre
                }).ToList();
            return alertasActivas;
        }

        public UsuarioCryptoDTO ObtenerUnaAlerta(string nombreCrypto)
        {
            int userId = SessionManager.CurrentUserId;
            var alerta = _context.UsuariosCryptos.Where(fc => fc.UsuarioID == userId && fc.CryptoNombre == nombreCrypto)
                .Select(fc => new UsuarioCryptoDTO
                {
                    ValorPositivo = fc.ValorPositivo,
                    ValorNegativo = fc.ValorNegativo
                }).FirstOrDefault();

            return alerta;
        }

        public void GuardarValoresAlerta(string nobreCrypto, decimal valorPositivo, decimal valorNegativo)
        {
            int userId = SessionManager.CurrentUserId;
            var alerta = _context.UsuariosCryptos.Where(fc => fc.UsuarioID == userId && fc.CryptoNombre == nobreCrypto)
                .FirstOrDefault();
            // Sobrescribir las propiedades directamente
            alerta.ValorPositivo = valorPositivo;
            alerta.ValorNegativo = valorNegativo;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
        }

        public void EliminarAlerta(string nombreCrypto)
        {
            GuardarValoresAlerta(nombreCrypto, 0, 0);
        }
    }
}

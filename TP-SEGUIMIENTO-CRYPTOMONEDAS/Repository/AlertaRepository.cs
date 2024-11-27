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

        //public List<AlertaDTO> ObtenerAlertasHistorial()
        //{
        //   Accede al userId desde la sesión (suponiendo que tienes una forma de acceder a la sesión)
        //    int userId = SessionManager.CurrentUserId; // Cambia esto según tu implementación de sesión

        //   Obtiene las criptomonedas favoritas del usuario especificado de manera síncrona
        //  var favoriteCryptos = _context.AlertasCrypto
        //        .Where(fc => fc.UsuarioID == userId)
        //        .AsEnumerable() // Mueve la consulta a memoria
        //        .Where(fc => (DateTime.Now.Date - fc.FechaAlerta).Days < 7) // Ahora puedes comparar en memoria
        //        .Select(fc => new AlertaDTO // Mapea a AlertaDTO
        //        {
        //            CryptoNombre = fc.CryptoNombre,
        //            CambioPorcentual = fc.CambioPorcentual,
        //            FechaAlerta = fc.FechaAlerta,
        //            TipoCambio = fc.TipoCambio,
        //        })
        //        .ToList(); // Usa ToList() para una operación síncrona

        //    return favoriteCryptos; // Retorna la lista de criptomonedas favoritas
        //}

        public List<AlertaDTO> ObtenerAlertasActivas()
        {
            int userId = SessionManager.CurrentUserId;

            var alertasActivas = _context.Alertas
                .Where(fc => fc.UsuarioID == userId && (fc.FechaActivasion == null))
                .Select(fc => new AlertaDTO
                {
                    CambioPorcentual = fc.CambioPorcentual,
                    TipoCambio = fc.TipoCambio,
                    CryptomonedaID = fc.CryptomonedaID, 
                    AlertaID = fc.AlertaID
                    
                }).ToList();
            return alertasActivas;
        }

        //public UsuarioCryptoDTO ObtenerUnaAlerta(string nombreCrypto)
        //{
        //    int userId = SessionManager.CurrentUserId;
        //    var alerta = _context.UsuariosCryptos.Where(fc => fc.UsuarioID == userId && fc.CryptoNombre == nombreCrypto)
        //        .Select(fc => new UsuarioCryptoDTO
        //        {
        //            ValorPositivo = fc.ValorPositivo,
        //            ValorNegativo = fc.ValorNegativo
        //        }).FirstOrDefault();

        //    return alerta;
        //}

        public void GuardarValoresAlerta(int idCrypto, decimal valorAlerta, string tipoAlerta)
        {
            int userId = SessionManager.CurrentUserId;
            var alerta = _context.Alertas.Where(fc => fc.UsuarioID == userId && fc.AlertaID == idCrypto)
                .FirstOrDefault();
            // Sobrescribir las propiedades directamente
            alerta.CambioPorcentual = valorAlerta;
            alerta.TipoCambio = tipoAlerta;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
        }

        public void EliminarAlerta(int idAlerta)
        {
            int userId = SessionManager.CurrentUserId;

            // Busca la alerta específica por ID
            var alertaAEliminar = _context.Alertas.FirstOrDefault(fc => fc.AlertaID == idAlerta);

            if (alertaAEliminar != null)
            {
                // Elimina la alerta
                _context.Alertas.Remove(alertaAEliminar);

                // Guarda los cambios en la base de datos
                _context.SaveChanges();
            }
        }

        public int CrearAlerta(string nombreCrypto, decimal umbralSuperado, string tipo)
        {
            int userId = SessionManager.CurrentUserId;

            var nuevaAlerta = new AlertaDTO
            {
                UsuarioID = userId,
                CryptomonedaID = nombreCrypto,
                CambioPorcentual = umbralSuperado,
                TipoCambio = tipo,
            };

            // Agregar la alerta a la base de datos
            _context.Alertas.Add(nuevaAlerta);

            // Guardar los cambios en la base de datos
            _context.SaveChanges();

            // Obtener el Id de la alerta recién creada
            int nuevaAlertaId = nuevaAlerta.AlertaID; // Suponiendo que "AlertaID" es la clave primaria

            return nuevaAlertaId;
        }

        public void MarcarActivacionAlerta(int idCrypto)
        {
            // Busca la alerta específica por ID
            var alerta = _context.Alertas.Where(fc => fc.AlertaID == idCrypto)
                .FirstOrDefault();

            // Sobrescribir la fecha
            alerta.FechaActivasion = DateTime.Now;

            // Guardar los cambios en la base de datos
            _context.SaveChanges();
        }
    }
 }


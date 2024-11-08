﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.DTOs;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Repository
{
    public interface IUserRepository
    {
        UserDTO ValidarUsuario(string mail, string contrasena);
        List<UsuarioCryptoDTO> ObtenerCryptosFavoritas();
    }
}

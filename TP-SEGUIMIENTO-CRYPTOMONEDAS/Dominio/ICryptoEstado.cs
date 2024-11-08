﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Dominio
{
    //PAtron estado para el cambio de logica en caso de que una crpyto sea favorita o no
    public interface ICryptoState
    {
        void Handle(OpcionesCrypto opcionesCrypto);
    }

    public class AgregarState : ICryptoState
    {
        public void Handle(OpcionesCrypto opcionesCrypto)
        {
            opcionesCrypto._unitOfWork.CryptosFavoritas.AgregarFavorito(opcionesCrypto.Crypto);
            opcionesCrypto.InicioForm.CargarUnaCrypto(opcionesCrypto.Crypto);
            opcionesCrypto.CambiarEstado(new EliminarState());
            opcionesCrypto.ActualizarBoton("Eliminar");
        }
    }

    public class EliminarState : ICryptoState
    {
        public void Handle(OpcionesCrypto opcionesCrypto)
        {
            opcionesCrypto.InicioForm.EliminarUnaCrypto(opcionesCrypto.Crypto.SubItems[0].Text);
            opcionesCrypto._unitOfWork.CryptosFavoritas.EliminarFavorito(opcionesCrypto.Crypto);
            opcionesCrypto.CambiarEstado(new AgregarState());
            opcionesCrypto.ActualizarBoton("Agregar");
        }
    }
}

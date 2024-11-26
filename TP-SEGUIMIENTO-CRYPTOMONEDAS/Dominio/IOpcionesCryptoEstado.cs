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
            opcionesCrypto._unitOfWork.CryptosFavoritas.AgregarFavorito(opcionesCrypto.cryptoNombre, opcionesCrypto.cryptoId);
            opcionesCrypto.InicioForm.CargarUnaCryptoAlView(opcionesCrypto.cryptoId);
            opcionesCrypto.CambiarEstado(new EliminarState());
            opcionesCrypto.ActualizarBotones("Eliminar",true);
        }
    }

    public class EliminarState : ICryptoState
    {
        public void Handle(OpcionesCrypto opcionesCrypto)
        {
            opcionesCrypto.InicioForm.EliminarUnaCryptoDelView(opcionesCrypto.cryptoId);
            opcionesCrypto._unitOfWork.CryptosFavoritas.EliminarFavorito(opcionesCrypto.cryptoId);
            opcionesCrypto.CambiarEstado(new AgregarState());
            opcionesCrypto.ActualizarBotones("Agregar",false);
        }
    }
}

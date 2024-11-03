using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_SEGUIMIENTO_CRYPTOMONEDAS.UntOfWork;

namespace TP_SEGUIMIENTO_CRYPTOMONEDAS.Vistas
{
    public partial class InicioForm : Form
    {
        private IUnitOfWork _unitOfWork;
        public InicioForm(IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _unitOfWork = unitOfWork;
        }

        private void InicioForm_Load(object sender, EventArgs e)
        {

        }

        private void MercadoBoton_Click(object sender, EventArgs e)
        {
            var MercadoForm = new MercadoForm(_unitOfWork); // Cambia esto al nombre de tu formulario principal
            MercadoForm.Show();
        }
    }
}

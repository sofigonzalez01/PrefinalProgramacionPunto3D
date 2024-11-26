using PrefinalProgramacionPunto3D.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrefinalProgramacionPunto3D.Windows
{
    public partial class frmPunto3DAe : Form
    {

        private Punto3D? puntoForm;
        public frmPunto3DAe()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if(ValidarDatos())
            {

                if(puntoForm is null)
                {
                    puntoForm = new Punto3D();
                }

                puntoForm.X = int.Parse(txtX.Text);
                puntoForm.Y = int.Parse(txtY.Text);
                puntoForm.Z = int.Parse(txtZ.Text);
                puntoForm.Color = txtColor.Text;

                DialogResult = DialogResult.OK;

            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if(string.IsNullOrEmpty(txtX.Text) || !int.TryParse(txtX.Text, out int valorX) || valorX <= 0)
            {
                errorProvider1.SetError(txtX, "Ingrese un valor valido");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtY.Text) || !int.TryParse(txtY.Text, out int valorY) || valorY <= 0)
            {
                errorProvider1.SetError(txtY, "Ingrese un valor valido");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtZ.Text) || !int.TryParse(txtZ.Text, out int valorZ) || valorZ <= 0)
            {
                errorProvider1.SetError(txtZ, "Ingrese un valor valido");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtColor.Text))
            {
                errorProvider1.SetError(txtColor, "Ingrese un valor valido");
                valido = false;
            }

            return valido;

        }

        public Punto3D GetPunto()
        {
            return puntoForm;
        }

    }
}

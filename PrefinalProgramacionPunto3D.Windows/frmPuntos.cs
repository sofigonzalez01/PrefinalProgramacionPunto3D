using PrefinalProgramacionPunto3D.Datos;
using PrefinalProgramacionPunto3D.Entidades;

namespace PrefinalProgramacionPunto3D.Windows
{
    public partial class frmPuntos : Form
    {

        private RepositorioPuntos3D repositorio;
        private int cantidadPuntos;
        private List<Punto3D> puntos;

        public frmPuntos()
        {
            InitializeComponent();
            repositorio = new RepositorioPuntos3D();
            puntos = repositorio.GetLista();
        }

        public void MostrarDatosGrilla()
        {
            LimpiarGrilla(dgvDatos);
            foreach (var item in puntos)
            {
                var r = ConstruirFila(dgvDatos);
                SetearFila(r, item);
                AgregarFila(r, dgvDatos);
            }
            MostrarCantidadRegistros();
        }

        public void AgregarFila(DataGridViewRow row, DataGridView dgv)
        {
            dgv.Rows.Add(row);
        }

        public void SetearFila(DataGridViewRow row, Punto3D obj)
        {

            row.Cells[colX.Index].Value = obj.X;
            row.Cells[colY.Index].Value = obj.Y;
            row.Cells[colZ.Index].Value = obj.Z;
            row.Cells[colColor.Index].Value = obj.Color;
            row.Cells[colDistancia.Index].Value = obj.GetDistanciaOrigen().ToString("N2");

            row.Tag = obj;

        }

        public DataGridViewRow ConstruirFila(DataGridView dgv)
        {
            var r = new DataGridViewRow();
            r.CreateCells(dgv);
            return r;
        }

        public void LimpiarGrilla(DataGridView dgv)
        {
            dgv.Rows.Clear();
        }

        public void MostrarCantidadRegistros()
        {
            cantidadPuntos = repositorio.GetCantidad();
            txtCantidad.Text = cantidadPuntos.ToString();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmPunto3DAe form = new frmPunto3DAe() { Text = "Agregar Punto 3D" };
            DialogResult dr = form.ShowDialog(this);

            if (dr == DialogResult.Cancel) return;

            Punto3D? punto = form.GetPunto();

            if (!repositorio.Existe(punto))
            {

                repositorio.AgregarPunto(punto);
                MostrarDatosGrilla();

                MessageBox.Show($"Agregado {punto.MostrarTexto()}\nDistancia al origen: {punto.GetDistanciaOrigen().ToString("N2")}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show("Ya existe ese punto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {

            if (dgvDatos.SelectedRows.Count == 0) return;

            DialogResult dr = MessageBox.Show("¿Estas seguro de esto?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            var pBorrar = dgvDatos.SelectedRows[0];
            var punto = pBorrar.Tag as Punto3D;

            repositorio.EliminarPunto(punto);
            puntos = repositorio.GetLista();
            MostrarDatosGrilla();

            MessageBox.Show("Punto Eliminado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void lado09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            puntos = repositorio.OrdernarPorDistanciaOrigen();
            MostrarDatosGrilla();
        }

        private void lado90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            puntos = repositorio.OrdernarPorDistanciaOrigenDesendiente();
            MostrarDatosGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            puntos = repositorio.GetLista();
            MostrarDatosGrilla();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

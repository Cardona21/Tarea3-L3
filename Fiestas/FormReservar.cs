using BL_Fiestas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BL_Fiestas.ReservaBL;

namespace Fiestas
{
    public partial class FormReservar : Form
    {
        ReservaBL _Reservas;
        CategoriasBL _categorias;

        public FormReservar()
        {
            InitializeComponent();

            _Reservas = new ReservaBL();

            listaReservaBindingSource.DataSource = _Reservas.ObtenerReservas();

            _categorias = new CategoriasBL();
            listaCategoriaBindingSource.DataSource = _categorias.ObtenerCategorias();


        }

        private void listaReservaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaReservaBindingSource.EndEdit();
            var reserva = (ReservaBL.Reserva) listaReservaBindingSource.Current;

            if (fotoPictureBox.Image != null)
            {
                reserva.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                reserva.Foto = null;
            }

            var resultado = _Reservas.GuardarResrva(reserva);


            if (resultado.Exitoso == true)
            {
                listaReservaBindingSource.ResetBindings(false);
                DesHabilitarHabilitarBotones(true);
                MessageBox.Show("Mensaje Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
          
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _Reservas.AgregarReserva();
            listaReservaBindingSource.MoveFirst();

            DesHabilitarHabilitarBotones(false );

        }

            private void DesHabilitarHabilitarBotones(bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;
            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButtonCancelar.Visible = !valor;


        }
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

           
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar esta registro", "Eliminado", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }

            }
        }

        private void Eliminar(int id)
        {
          
            var resultado = _Reservas.EliminarResrva(id);

            if (resultado == true)
            {
                listaReservaBindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Ocurio un ERROR al eliminar el producto");
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DesHabilitarHabilitarBotones(true);
            Eliminar(0);

        }

        private void FormReservar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var reserva = (ReservaBL.Reserva)listaReservaBindingSource.Current;

            if (reserva != null)
            {

            }

            openFileDialog1.ShowDialog();
            var archivo = openFileDialog1.FileName;

            if (archivo != "")
            {
                var FileInfo = new FileInfo(archivo);
                var fileStream = FileInfo.OpenRead();

                fotoPictureBox.Image = Image.FromStream(fileStream);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }
    }
}

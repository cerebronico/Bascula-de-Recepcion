using Báscula_de_Recepción.Properties;
using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

namespace Báscula_de_Recepción
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataDataSet.Transac' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dataDataSet.Transac' table. You can move, or remove it, as needed.

            
            try
            {
                serialPort1.Open();
                staValores.Text = @"Connected";
                staValores.BackColor = Color.DarkGreen;
                staValores.Image = Resources.connected;
            }
            catch (Exception)
            {
                staValores.Text = @"Can't connect";
                staValores.BackColor = Color.FromArgb(239, 46, 15);
                staValores.Image = Resources.disconnected;
            }

            txtNoOrden.Text = Settings.Default.buque;
            txtCantidadDeclarada.Text = Settings.Default.cantidad;
            txtChofer.Text = Settings.Default.descarga;
            txtPlaca.Text = Settings.Default.documento;

            txtProducto.Text = Settings.Default.producto;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            serialPort1.Close();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            
        }


        private void BorrarAcumuladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirma = MessageBox.Show(@"¿Está seguro?, ¡esto borrará el acumulador de peso!", @"Confirmación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirma == DialogResult.Yes)
                try
                {
                    serialPort1.Write("80.1P=0%o\r");
                    serialPort1.Write("80.4P=0%o\r");
                    serialPort1.Write("80.5P=0%o\r");
                    serialPort1.Write("80.10P=0%o\r");
                }
                catch (Exception)
                {
                    MessageBox.Show(@"No se puedo enviar la información", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
        }


        private void SalirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var confirma = MessageBox.Show(@"¿Está seguro?", @"Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (confirma == DialogResult.Yes)
                Application.Exit();
        }


        private void MnuConsulta_click(object sender, EventArgs e)
        {
            var consulta = new FrmConsulta();
            AddOwnedForm(consulta);
            consulta.Show();
        }

        private void MnuNuevo_Click(object sender, EventArgs e)
        {
            txtNoOrden.Enabled = true;
            txtPlaca.Enabled = true;
            txtChofer.Enabled = true;
            txtCantidadDeclarada.Enabled = true;
            txtProducto.Enabled = true;
            dtpFecha.Enabled = true;
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var datoRx = serialPort1.ReadLine();
            var parms = datoRx.Split(',');
            Console.WriteLine(@"{0} words in text:", parms.Length);
            Console.WriteLine(parms[0]);

            if (parms.Length != 7) return;
            lblPeso.Text = parms[0];
            lblDescarga.Text = parms[1];
            //lblFlujo.Text = parms[4];
            var tiempoVolteo = float.Parse(parms[5]);
        }

        private void transacBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }

        private void txtCantidadDeclarada_TextChanged(object sender, EventArgs e)
        {
        }

        private void label20_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void textCompraKg_TextChanged(object sender, EventArgs e)
        {
        }

        private void textCompraLb_TextChanged(object sender, EventArgs e)
        {
        }

        private void label22_Click(object sender, EventArgs e)
        {
        }

        private void textPesoCartones_TextChanged(object sender, EventArgs e)
        {
        }

        private void textCompraCajas_TextChanged(object sender, EventArgs e)
        {
        }

        private void maskedTextBoxCantidad2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
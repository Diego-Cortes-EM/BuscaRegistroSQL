using System;
using System.Windows.Forms;

namespace ControleEntreDoisBanco
{
    public partial class RegistroCatraca : Form
    {
        private int UltimoRegistro;
        public RegistroCatraca()
        {
            InitializeComponent();
            UltimoRegistro = new MapeadorDadosSql().BuscaUltimoRegistro().Id + 1;
            textBoxid.Text = UltimoRegistro.ToString();
            textBoxid.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!PodeAcessar())
            {
                return;
            }
            var registroEntrada = new RegistroEntrada();
            registroEntrada.Id = Convert.ToInt32(textBoxid.Text);
            registroEntrada.Matricula = Convert.ToInt32(textBoxMatricula.Text);
            registroEntrada.Horario = DateTime.Now;
            if (checkBox1.Checked)
            {
                registroEntrada.Sentido = 1;
            }
            else
            {
                registroEntrada.Sentido = 2;
            }
            var mapeador = new MapeadorDadosSql();
            mapeador.InserirRegistros(registroEntrada);
            UltimoRegistro++;
            textBoxid.Text = UltimoRegistro.ToString();
            textBoxMatricula.Text = string.Empty; 
        }

        

        private bool PodeAcessar()
        {
            if(checkBox1.Checked || checkBox2.Checked)
            {
                return true;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegracaoBancos
{
    public partial class ConfiguraçãoSistema : Form
    {
        public ConfiguraçãoSistema()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ofdArquivo.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            textBoxBDEM.Text = ofdArquivo.FileName;
            
        }
    }
}

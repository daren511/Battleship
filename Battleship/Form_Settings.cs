using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form_Settings : Form
    {
        // ---------- VARIABLES
        public string ip = "172.17.104.126";
        public int port = 8888;


        public Form_Settings()
        {
            InitializeComponent();
        }

        // Remplit les TextBox selon l'IP et le port du moment
        private void Form_Settings_Load(object sender, EventArgs e)
        {
            TB_IP.Text = ip;
            TB_Port.Text = port.ToString();
        }

        // Change l'IP et le port selon ce que l'utilisateur a entré
        private void BTN_Ok_Click(object sender, EventArgs e)
        {
            ip = TB_IP.Text.ToString();
            port = Int32.Parse(TB_Port.Text.ToString());
        }
    }
}

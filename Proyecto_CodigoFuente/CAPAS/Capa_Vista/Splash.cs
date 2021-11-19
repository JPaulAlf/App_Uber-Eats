using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capa_Vista
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 120)
                timer1.Stop();

            label2.Text = progressBar1.Value + ("% Cargando . . .");
        }
    }
}

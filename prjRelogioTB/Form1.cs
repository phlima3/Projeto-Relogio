using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjRelogioTB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string caminho = Environment.CurrentDirectory +
            "\\fundo.png";
        Image fundo;
        Graphics g;
        int hora;
        int min;
        int seg;
        int xseg = 0, yseg = 0;
        int xmin = 0, ymin = 0;
        int xhora = 0, yhora = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            fundo = Image.FromFile(caminho);
            pbRelogio.Image = fundo;
            g = pbRelogio.CreateGraphics();
            pbRelogio.Width = fundo.Width;
            pbRelogio.Height = fundo.Height;
        }

        private void relogio_Tick(object sender, EventArgs e)
        {
            DateTime bios = DateTime.Now;
            hora = bios.Hour;
            min = bios.Minute;
            seg = bios.Second;
            DesenharPonteiroSegundo();
        }

        private void DesenharPonteiroSegundo()
        {
            int cx = pbRelogio.Width / 2;
            int cy = pbRelogio.Height / 2;
            int raio = 110;
            double angulo = -90 + (seg * 6);
            Pen caneta = new Pen(Color.White, 4);
            g.DrawLine(caneta, cx, cy, cx + xseg,
                cy + yseg);

        }
    }
}

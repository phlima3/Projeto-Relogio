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
        Bitmap fundo;
        Graphics g;
        Color ponteiro = Color.Red;
        int hora;
        int min;
        int seg;
        int xseg = 0, yseg = 0;
        int xmin = 0, ymin = 0;
        int xhora = 0, yhora = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            fundo = new Bitmap(pbRelogio.Width, pbRelogio.Height);
            g = Graphics.FromImage(fundo);
        }

        private void relogio_Tick(object sender, EventArgs e)
        {
            DateTime bios = DateTime.Now;
            hora = bios.Hour;
            min = bios.Minute;
            seg = bios.Second;
            desenharFundo();
            DesenharPonteiroSegundo();
            DesenharPontieroMinuto();
            DesenharPonteiroHora();
            DesenharCentro();
            pbRelogio.CreateGraphics().DrawImage(fundo, 0, 0);
            GC.Collect();
        }

        private void desenharFundo()
        {
            g.DrawImage(Image.FromFile(caminho), 0, 0, pbRelogio.Width, pbRelogio.Height);
        }

        private void DesenharCentro()
        {
            SolidBrush corSolida = new SolidBrush(ponteiro);
            int cx = pbRelogio.Width / 2;
            int cy = pbRelogio.Height / 2;
            g.FillEllipse(corSolida, cx - 10, cy - 10, 20, 20);
            corSolida.Color = Color.White;
            g.FillEllipse(corSolida, cx - 8, cy - 8, 16, 16);
        }

        private void DesenharPonteiroHora()
        {
            {
                int cx = pbRelogio.Width / 2;
                int cy = pbRelogio.Height / 2;
                int raio = 70;
                if (hora > 12) hora = hora - 12;
                double angulo = -90 + (hora * 30);
                Pen caneta = new Pen(Color.White, 8);
                caneta.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                g.DrawLine(caneta, cx, cy, cx + xhora,
                   cy + yhora);
                double rad = Math.PI * angulo / 180;
                xhora = (int)(raio * Math.Cos(rad));
                yhora = (int)(raio * Math.Sin(rad));
                caneta.Color = ponteiro;
                g.DrawLine(caneta, cx, cy, cx + xhora,
                  cy + yhora);
            }
        }
        
        

        private void DesenharPontieroMinuto()
        {
            int cx = pbRelogio.Width / 2;
            int cy = pbRelogio.Height / 2;
            int raio = 90;
            double angulo = -90 + (min * 6);
            Pen caneta = new Pen(Color.White, 4);
            caneta.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(caneta, cx, cy, cx + xmin,
               cy + ymin);
            double rad = Math.PI * angulo / 180;
            xmin = (int)(raio * Math.Cos(rad));
            ymin = (int)(raio * Math.Sin(rad));
            caneta.Color = ponteiro;
            g.DrawLine(caneta, cx, cy, cx + xmin,
              cy + ymin);
        }

        private void DesenharPonteiroSegundo()
        {
            int cx = pbRelogio.Width / 2;
            int cy = pbRelogio.Height / 2;
            int raio = 110;
            double angulo = -90 + (seg * 6);
            Pen caneta = new Pen(Color.Black, 4);
            caneta.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(caneta, cx, cy, cx + xseg,
                cy + yseg);
            double rad = Math.PI * angulo / 180;
            xseg = (int)(raio * Math.Cos(rad));
            yseg = (int)(raio * Math.Sin(rad));
            caneta.Color = ponteiro;
            g.DrawLine(caneta, cx, cy, cx + xseg,
               cy + yseg);

        }

        private void mnFundo_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "imagens | *.jpg; *.png;";
            relogio.Stop();
            openFileDialog1.ShowDialog();
            if (File.Exists(openFileDialog1.FileName))
            {
                File.Delete(caminho);
                File.Copy(openFileDialog1.FileName, caminho);
            }
            relogio.Start();
        }

        private void mnPonteiro_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ponteiro = colorDialog1.Color;


        }
    }
}

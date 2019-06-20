using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projTeatro
{
    public partial class Form1 : Form
    {

        private Button[,] btnLugar;
        private Teatro teatro;

        public void clicouNoBotao(object sender, EventArgs e)
        {
            int f;
            int p;
            f = int.Parse(((Button)sender).Tag.ToString().Substring(0, 2));
            p = int.Parse(((Button)sender).Tag.ToString().Substring(3, 2));
            this.teatro.reservar(f + 1, p + 1, chkMeia.Checked);
            ((Button)sender).BackColor = Color.DarkRed;
            ((Button)sender).Enabled = false;
            atualizaTeatro();
        }

        public void atualizaTeatro()
        {
            this.Text = "Ocupados: " + this.teatro.qtdeOcupados() +
                " | Bilheteria: R$ " + this.teatro.valorBilheteria();
        }


        public void inicializaComponentes()
        {
            int coluna;
            this.btnLugar = new Button[15, 40];
            for (int fila = 0; fila < 15; ++fila)
            {
                coluna = 20;
                for (int polt = 0; polt < 40; ++polt)
                {
                    this.btnLugar[fila, polt] = new Button();
                    this.btnLugar[fila, polt].Parent = this;
                    this.btnLugar[fila, polt].Width = 20;
                    this.btnLugar[fila, polt].Left = coluna;
                    this.btnLugar[fila, polt].Top = 20 * (fila + 1);
                    this.btnLugar[fila, polt].Text = ".";
                    this.btnLugar[fila, polt].BackColor = Color.Green;
                    this.btnLugar[fila, polt].Tag = fila.ToString("00") + "," + polt.ToString("00");
                    this.btnLugar[fila, polt].Click += new EventHandler(clicouNoBotao);
                    coluna += 20;
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
            inicializaComponentes();
            this.teatro = new Teatro(50, 40, 30);
            atualizaTeatro();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

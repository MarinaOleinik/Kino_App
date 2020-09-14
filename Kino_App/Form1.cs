using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kino_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Label[,] _arr = new Label[4, 4];
        Label[] read = new Label[4];
        Button osta;
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                read[i] = new Label();
                read[i].Text = "Rida " + (i+1);
                read[i].Size = new Size(50, 50);
                read[i].Location = new Point(1, i * 50);
                this.Controls.Add(read[i]);
                for (int j = 0; j < 4; j++)
                {     
                    _arr[i, j] = new Label();
                    _arr[i, j].Text =  " Koht" + (j+1);//"Rida " + i +
                    _arr[i, j].Size = new Size(50, 50);
                    _arr[i, j].BackColor = Color.Green;
                    _arr[i, j].BorderStyle= BorderStyle.Fixed3D;
                    _arr[i, j].Location = new Point(j * 50 + 50, i * 50);                
                    this.Controls.Add(_arr[i, j]);
                    _arr[i, j].Tag = new int[] { i, j };
                    _arr[i, j].Click += new System.EventHandler(Form1_Click);
                }
            }
            osta = new Button();
            osta.Text = "Osta";
            osta.Location = new Point(200, 200);
            this.Controls.Add(osta);
            osta.Click += Osta_Click;
        }

        private void Osta_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (_arr[i, j].BackColor==Color.Yellow)
                    {
                        _arr[i, j].BackColor = Color.Red;
                    }
                }
            }
        }

        void Form1_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;//запомникли на какую надпись нажали
            var tag = (int[])label.Tag;//определили координаты надписи
            //MessageBox.Show("Kas oled kindel?", "Appolo küsib", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            _arr[tag[0], tag[1]].Text = "Kinni";
            _arr[tag[0], tag[1]].BackColor = Color.Yellow;
        }
    }
}

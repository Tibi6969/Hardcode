using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tibimon
{
    public partial class tibimonValasztas : Form
    {
        private Bitmap teszt;

        public tibimonValasztas()
        {
            InitializeComponent();
        }

        private void tibimonValasztas_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.lista.Count; i++)
            {
                listBox1.Items.Add(Form1.lista[i].nev);
            }

            if(Form1.nehez == "nehez")
            {
                richTextBox1.Text = "Nehézre állítottad a nehézséget, válassz 6 Tibimont!";
            }
            else if(Form1.nehez == "kozepes")
            {
                richTextBox1.Text = "Közepesre állítottad a nehézséget, válassz 4 Tibimont!";
            }
            else
            {
                richTextBox1.Text = "Könnyűre állítottad a nehézséget, válassz 2 Tibimont!";
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;

            groupBox1.Text = Form1.lista[listBox1.SelectedIndex].nev;
            richTextBox1.Text = Form1.lista[listBox1.SelectedIndex].leiras;

            label1.Text = "HP: " + Form1.lista[listBox1.SelectedIndex].hp;
            label2.Text = "Támadás: " + Form1.lista[listBox1.SelectedIndex].tamadas;
            label3.Text = "Védekezés: " + Form1.lista[listBox1.SelectedIndex].vedekezes;
            label4.Text = "Sebesség: " + Form1.lista[listBox1.SelectedIndex].gyorsasag;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            teszt = new Bitmap(@"../pokemon/" + (listBox1.SelectedIndex + 1).ToString() + ".png");
            pictureBox1.Image = (Image)teszt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            richTextBox1.Text = listBox1.SelectedItem + ", téged választalak!";

            if (Form1.nehez == "nehez")
            {
                if(Form1.valasztottTibimonok.Count < 6)
                {
                    Form1.valasztottTibimonok.Add(Form1.lista[listBox1.SelectedIndex]);
                    Form1.ellenfelTibimonok.Add(Form1.lista[r.Next(0, 151)]);
                }
                
                if(Form1.valasztottTibimonok.Count == 6)
                {
                    this.Close();
                }
            }
            else if (Form1.nehez == "kozepes")
            {
                if (Form1.valasztottTibimonok.Count < 4)
                {
                    Form1.valasztottTibimonok.Add(Form1.lista[listBox1.SelectedIndex]);
                    Form1.ellenfelTibimonok.Add(Form1.lista[r.Next(0, 151)]);
                }

                if (Form1.valasztottTibimonok.Count == 4)
                {
                    this.Close();
                }
            }
            else
            {
                if (Form1.valasztottTibimonok.Count < 2)
                {
                    Form1.valasztottTibimonok.Add(Form1.lista[listBox1.SelectedIndex]);
                    Form1.ellenfelTibimonok.Add(Form1.lista[r.Next(0, 151)]);
                }

                if (Form1.valasztottTibimonok.Count == 2)
                {
                    this.Close();
                }
            }
        }
    }
}

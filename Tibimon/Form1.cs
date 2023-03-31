using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tibimon
{
    public partial class Form1 : Form
    {
        public static List<tibimonok> valasztottTibimonok = new List<tibimonok>();
        public static List<tibimonok> ellenfelTibimonok = new List<tibimonok>();
        public static string nehez = "";
        public static List<tibimonok> lista = new List<tibimonok>();

        public Form1()
        {
            InitializeComponent();

            int i = 1;

            using(FileStream f = new FileStream("keszTibimon.txt", FileMode.Open))
            using(StreamReader sr = new StreamReader(f))
            {
                while(!sr.EndOfStream)
                {
                    lista.Add(new tibimonok(sr.ReadLine(), i));

                    i++;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nehezseg nehezsegMenu = new nehezseg();
            this.Hide();
            nehezsegMenu.ShowDialog();
            this.Show();

            if (nehez == "nehez" || nehez == "kozepes" || nehez == "konnyu")
            {
                button2.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tibimonValasztas valasztas = new tibimonValasztas();
            this.Hide();
            valasztas.ShowDialog();
            this.Show();

            for (int i = 0; i < valasztottTibimonok.Count; i++)
            {
                listBox1.Items.Add(valasztottTibimonok[i].nev);
                listBox2.Items.Add(ellenfelTibimonok[i].nev);
            }

            button2.Enabled = false;
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            csata aHarc = new csata();
            this.Hide();
            aHarc.ShowDialog();
            this.Show();
            valasztottTibimonok.Clear();
            ellenfelTibimonok.Clear();
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

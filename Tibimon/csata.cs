using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Tibimon
{
    public partial class csata : Form
    {
        private Bitmap kepek;
        static Bitmap karmok;
        static int jelenlegiValasztottIndex = 0;
        static Random r = new Random();

        public csata()
        {
            InitializeComponent();
        }
        
        public void listaRendezes()
        {
            for (int i = 0; i < Form1.ellenfelTibimonok.Count; i++)
            {
                for (int k = 0; k < Form1.ellenfelTibimonok[i].tipusok.Count; k++)
                {
                    if (Form1.valasztottTibimonok[jelenlegiValasztottIndex].gyengesegek.Contains(Form1.ellenfelTibimonok[i].tipusok[k]))
                    {
                        Form1.ellenfelTibimonok.Add(Form1.ellenfelTibimonok[i]);
                        Form1.ellenfelTibimonok.RemoveAt(i);
                    }
                } 
            }
        }

        public bool sebzes(string tamado)
        {
            bool kuldjed = false;

            if(tamado == "jatekos")
            {
                for (int i = 0; i < Form1.valasztottTibimonok[jelenlegiValasztottIndex].tipusok.Count; i++)
                {
                    if (Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].gyengesegek.Contains(Form1.valasztottTibimonok[jelenlegiValasztottIndex].tipusok[i]))
                    {
                        kuldjed = true;
                        break;
                    }
                }
            }
            else if(tamado == "ellenfel")
            {
                for (int i = 0; i < Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tipusok.Count; i++)
                {
                    if (Form1.valasztottTibimonok[jelenlegiValasztottIndex].gyengesegek.Contains(Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tipusok[i]))
                    {
                        kuldjed = true;
                        break;
                    }
                }
            }
            return kuldjed;

        }

        private void csata_Load(object sender, EventArgs e)
        {

            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            kepek = new Bitmap(@"../back/" + Form1.valasztottTibimonok[jelenlegiValasztottIndex].kepId + ".png");
            pictureBox1.BackgroundImage = (Image)kepek;
            groupBox1.Text = Form1.valasztottTibimonok[jelenlegiValasztottIndex].nev;
            label1.Text = "HP: " + Form1.valasztottTibimonok[jelenlegiValasztottIndex].hp + "/" + Form1.valasztottTibimonok[0].hp;
            
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            kepek = new Bitmap(@"../front/" + Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].kepId + ".png");
            pictureBox2.BackgroundImage = (Image)kepek;

            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            kepek = new Bitmap(@"../ellenfelPadlo.png");
            pictureBox3.BackgroundImage = (Image)kepek;

            groupBox2.Text = Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].nev;
            label2.Text = "HP: " + Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp + "/" + Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp;

            progressBar1.Value = 100;
            progressBar2.Value = 100;
        }

        public void Shake(PictureBox kep)
        {
            var original = kep.Location;
            var rnd = new Random(1337);
            const int shake_amplitude = 10;

            for (int i = 0; i < 4; i++)
            {
                karmok = new Bitmap(@"../karmok/" + i + ".png");
                kep.Image = (Image)karmok;
                Application.DoEvents();
                Thread.Sleep(100);
            }

            kep.Image = null;

            for (int i = 0; i < 10; i++)
            {
                kep.Location = new Point(original.X + rnd.Next(-shake_amplitude, shake_amplitude), original.Y + rnd.Next(-shake_amplitude, shake_amplitude));
                Application.DoEvents();
                Thread.Sleep(20);
            }
            kep.Location = original;
        }

        public void jatekosTamadas()
        {
            richTextBox1.Clear();
            Shake(pictureBox2);

            int damage = 0;
            string uzenet = "";
            if (sebzes("jatekos"))
            {
                damage = r.Next((int)Math.Floor((Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1) * 2, (int)Math.Floor((Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1) * 2 + 11);
                if (damage <= Math.Round(((int)Math.Floor((Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1) * 2 + 11) * 0.33, 0))
                {
                    uzenet = Form1.valasztottTibimonok[jelenlegiValasztottIndex].nev + " támadásnak indult! Nem volt túl effektiv!";
                }
                else if (damage > Math.Round(((int)Math.Floor((Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1) * 2 + 11) * 0.33, 0) && damage <= Math.Round(((int)Math.Floor((Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1) * 2 + 11) * 0.66, 0))
                {
                    uzenet = Form1.valasztottTibimonok[jelenlegiValasztottIndex].nev + " támadásnak indult! Nem volt különösebben effektiv!";
                }
                else
                {
                    uzenet = Form1.valasztottTibimonok[jelenlegiValasztottIndex].nev + " támadásnak indult! Nagyon effektiv volt!";
                }

                //Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp -= (int)Math.Floor(Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1 * 2;
            }
            else
            {
                damage = r.Next((int)Math.Floor(Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1, (int)Math.Floor(Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1 + 11);
                if (damage <= Math.Round(((int)Math.Floor((Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1) + 11) * 0.33, 0))
                {
                    uzenet = Form1.valasztottTibimonok[jelenlegiValasztottIndex].nev + " támadásnak indult! Nem volt túl effektiv!";
                }
                else if (damage > Math.Round(((int)Math.Floor((Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1) + 11) * 0.33, 0) && damage <= Math.Round(((int)Math.Floor((Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1) + 11) * 0.66, 0))
                {
                    uzenet = Form1.valasztottTibimonok[jelenlegiValasztottIndex].nev + " támadásnak indult! Nem volt különösebben effektiv!";
                }
                else
                {
                    uzenet = Form1.valasztottTibimonok[jelenlegiValasztottIndex].nev + " támadásnak indult! Nagyon effektiv volt!";
                }
            }

            for (int i = 0; i < uzenet.Length; i++)
            {
                if (uzenet[i] != '!')
                {
                    richTextBox1.Text += uzenet[i];
                    Application.DoEvents();
                    Thread.Sleep(20);
                }
                else
                {
                    richTextBox1.Text += uzenet[i];
                    break;
                }
            }

            Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp -= damage;
            //label3.Text = (Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].kezdoElet).ToString();

            if ((int)Math.Round((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].kezdoElet) * 100, 0) < 0)
            {
                for (int i = progressBar2.Value; i >= 0; i--)
                {
                    progressBar2.Value = i;
                    Application.DoEvents();
                    Thread.Sleep(20);
                }

            }
            else
            {
                for (int i = progressBar2.Value; i >= (int)Math.Round((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].kezdoElet) * 100, 0); i--)
                {
                    progressBar2.Value = i;
                    Application.DoEvents();
                    Thread.Sleep(20);
                }
            }

            label2.Text = "HP: " + Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp + "/" + Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].kezdoElet;

            Application.DoEvents();
            Thread.Sleep(100);

            bool mehet = false;

            for (int i = 0; i < uzenet.Length; i++)
            {
                if (uzenet[i] == '!')
                {
                    mehet = true;
                }

                if (i == uzenet.Length - 1)
                {
                    richTextBox1.Text += '!';
                }

                if (mehet != false && uzenet[i] != '!' && i != uzenet.Length - 1)
                {
                    richTextBox1.Text += uzenet[i];
                    Application.DoEvents();
                    Thread.Sleep(20);
                }
            }

            if (Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp <= 0)
            {
                Form1.ellenfelTibimonok.RemoveAt(Form1.ellenfelTibimonok.Count - 1);
                listaRendezes();

                for (int i = 0; i < Form1.ellenfelTibimonok.Count; i++)
                {
                    listBox1.Items.Add(Form1.ellenfelTibimonok[i].nev);
                }

                if (Form1.ellenfelTibimonok.Count == 0)
                {
                    MessageBox.Show("Nyertél!");
                    Form1.ellenfelTibimonok.Clear();
                    Form1.valasztottTibimonok.Clear();
                    this.Close();

                }
                else
                {
                    kepek = new Bitmap(@"../front/" + Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].kepId + ".png");
                    pictureBox2.BackgroundImage = (Image)kepek;
                    groupBox2.Text = Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].nev;
                    label2.Text = "HP: " + Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp + "/" + Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].kezdoElet;
                    progressBar2.Value = 100;
                }
            }

        }

        public void ellenfelTamadas()
        {
            Shake(pictureBox1);

            int damage = 0;
            string uzenet = "";
            if (sebzes("ellenfel"))
            {
                damage = r.Next((int)Math.Floor((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1) * 2, (int)Math.Floor((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1) * 2 + 11);

                if (damage <= Math.Round(((int)Math.Floor((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count-1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1) * 2 + 11) * 0.33, 0))
                {
                    uzenet = Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].nev + " támadásnak indult! Nem volt túl effektiv!";
                }
                else if (damage > Math.Round(((int)Math.Floor((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1) * 2 + 11) * 0.33, 0) && damage <= Math.Round(((int)Math.Floor((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1) * 2 + 11) * 0.66, 0))
                {
                    uzenet = Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].nev + " támadásnak indult! Nem volt különösebben effektiv!";
                }
                else
                {
                    uzenet = Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].nev + " támadásnak indult! Nagyon effektiv volt!";
                }

                //Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp -= (int)Math.Floor(Form1.valasztottTibimonok[jelenlegiValasztottIndex].tamadas / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].vedekezes) + 1 * 2;
            }
            else
            {
                damage = r.Next((int)Math.Floor(Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1, (int)Math.Floor(Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1 + 11);
                if (damage <= Math.Round(((int)Math.Floor((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1) + 11) * 0.33, 0))
                {
                    uzenet = Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].nev + " támadásnak indult! Nem volt túl effektiv!";
                }
                else if (damage > Math.Round(((int)Math.Floor((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1) + 11) * 0.33, 0) && damage <= Math.Round(((int)Math.Floor((Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].tamadas / Form1.valasztottTibimonok[jelenlegiValasztottIndex].vedekezes) + 1) + 11) * 0.66, 0))
                {
                    uzenet = Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].nev + " támadásnak indult! Nem volt különösebben effektiv!";
                }
                else
                {
                    uzenet = Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].nev + " támadásnak indult! Nagyon effektiv volt!";
                }
            }

            for (int i = 0; i < uzenet.Length; i++)
            {
                if (uzenet[i] != '!')
                {
                    richTextBox1.Text += uzenet[i];
                    Application.DoEvents();
                    Thread.Sleep(20);
                }
                else
                {
                    richTextBox1.Text += uzenet[i];
                    break;
                }
            }

            Form1.valasztottTibimonok[jelenlegiValasztottIndex].hp -= damage;
            //label3.Text = (Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].hp / Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].kezdoElet).ToString();

            if ((int)Math.Round((Form1.valasztottTibimonok[jelenlegiValasztottIndex].hp / Form1.valasztottTibimonok[jelenlegiValasztottIndex].kezdoElet) * 100, 0) < 0)
            {
                for (int i = progressBar1.Value; i >= 0; i--)
                {
                    progressBar1.Value = i;
                    Application.DoEvents();
                    Thread.Sleep(20);
                }

            }
            else
            {
                for (int i = progressBar1.Value; i >= (int)Math.Round((Form1.valasztottTibimonok[jelenlegiValasztottIndex].hp / Form1.valasztottTibimonok[jelenlegiValasztottIndex].kezdoElet) * 100, 0); i--)
                {
                    progressBar1.Value = i;
                    Application.DoEvents();
                    Thread.Sleep(20);
                }
            }

            label1.Text = "HP: " + Form1.valasztottTibimonok[jelenlegiValasztottIndex].hp + "/" + Form1.valasztottTibimonok[jelenlegiValasztottIndex].kezdoElet;

            Application.DoEvents();
            Thread.Sleep(100);

            bool mehet = false;

            for (int i = 0; i < uzenet.Length; i++)
            {
                if (uzenet[i] == '!')
                {
                    mehet = true;
                }

                if (i == uzenet.Length - 1)
                {
                    richTextBox1.Text += '!';
                }

                if (mehet != false && uzenet[i] != '!' && i != uzenet.Length - 1)
                {
                    richTextBox1.Text += uzenet[i];
                    Application.DoEvents();
                    Thread.Sleep(20);
                }
            }

            if (Form1.valasztottTibimonok[jelenlegiValasztottIndex].hp <= 0)
            {
                int vegeVan = 0;

                for (int i = 0; i < Form1.valasztottTibimonok.Count; i++)
                {
                    if(Form1.valasztottTibimonok[i].leiras == "halott")
                    {
                        vegeVan++;
                    }
                }


                if(vegeVan == Form1.valasztottTibimonok.Count)
                {
                    MessageBox.Show("Vesztettél!");
                }
                else
                {
                    Form1.valasztottTibimonok[jelenlegiValasztottIndex].leiras = "halott";
                    listBox1.Show();
                    button2.Enabled = false;
                    button1.Enabled = false;
                }     
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();

            if (Form1.ellenfelTibimonok[Form1.ellenfelTibimonok.Count - 1].gyorsasag > Form1.valasztottTibimonok[jelenlegiValasztottIndex].gyorsasag)
            {
                ellenfelTamadas();
                Application.DoEvents();
                Thread.Sleep(500);
                richTextBox1.Clear();
                if(Form1.valasztottTibimonok[jelenlegiValasztottIndex].hp > 0)
                {
                    jatekosTamadas();
                }
            }
            else
            {
                jatekosTamadas();
                Application.DoEvents();
                Thread.Sleep(500);
                richTextBox1.Clear();
                ellenfelTamadas();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = false;
            listBox1.Visible = true;

            listBox1.Items.Clear();

            for (int i = 0; i < Form1.valasztottTibimonok.Count; i++)
            {
                listBox1.Items.Add(Form1.valasztottTibimonok[i].nev);
            }
        }

        public bool tibimonValasztas(int beindex)
        {
            bool eredmeny = false;

            if(Form1.valasztottTibimonok[beindex].leiras != "halott")
            {
                eredmeny = true;
            }

            return eredmeny;
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(tibimonValasztas(listBox1.SelectedIndex))
            {
                listBox1.Hide();
                int csuszkaErtek = progressBar1.Value;

                kepek = new Bitmap(@"../back/" + Form1.valasztottTibimonok[listBox1.SelectedIndex].kepId + ".png");
                pictureBox1.BackgroundImage = (Image)kepek;
                groupBox1.Text = Form1.valasztottTibimonok[listBox1.SelectedIndex].nev;
                label1.Text = "HP: " + Form1.valasztottTibimonok[listBox1.SelectedIndex].hp + "/" + Form1.valasztottTibimonok[listBox1.SelectedIndex].kezdoElet;

                if ((int)Math.Round((Form1.valasztottTibimonok[listBox1.SelectedIndex].hp / Form1.valasztottTibimonok[listBox1.SelectedIndex].kezdoElet) * 100, 0) > csuszkaErtek)
                {
                    for (int i = csuszkaErtek; i <= (int)Math.Round((Form1.valasztottTibimonok[listBox1.SelectedIndex].hp / Form1.valasztottTibimonok[listBox1.SelectedIndex].kezdoElet) * 100, 0); i++)
                    {
                        progressBar1.Value = i;
                        Application.DoEvents();
                        Thread.Sleep(20);
                    }

                }
                else if ((int)Math.Round((Form1.valasztottTibimonok[listBox1.SelectedIndex].hp / Form1.valasztottTibimonok[listBox1.SelectedIndex].kezdoElet) * 100, 0) < csuszkaErtek)
                {
                    for (int i = csuszkaErtek; i >= (int)Math.Round((Form1.valasztottTibimonok[listBox1.SelectedIndex].hp / Form1.valasztottTibimonok[listBox1.SelectedIndex].kezdoElet) * 100, 0); i--)
                    {
                        progressBar1.Value = i;
                        Application.DoEvents();
                        Thread.Sleep(20);
                    }
                }


                jelenlegiValasztottIndex = listBox1.SelectedIndex;

                listBox1.Visible = false;
                button2.Enabled = true;
                button1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Ezt a Tibimont már nem használhatod!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1.valasztottTibimonok.Clear();
            Form1.ellenfelTibimonok.Clear();
            jelenlegiValasztottIndex = 0;
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

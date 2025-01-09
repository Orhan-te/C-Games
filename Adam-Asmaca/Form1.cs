using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdamAsmaca
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, 1);
                // İmleci metnin sonuna taşı
                textBox1.SelectionStart = textBox1.Text.Length;
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLower(e.KeyChar))
            {
                e.KeyChar = char.ToUpper(e.KeyChar);
            }

            // Eğer girilen karakter harf değilse ve geri silme (Backspace) değilse, girişe izin verme
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        string kelime;
        int uzunluk;
        string[] harfler;
        string harf;
        int bharf;
        int hak = 7;
        private void Form1_Load(object sender, EventArgs e)
        {
            String[] sehirler = {"ADANA", "ADIYAMAN", "AFYONKARAHİSAR", "AĞRI", "AKSARAY", "AMASYA", "ANKARA", "ANTALYA", "ARDAHAN", "ARTVİN",
         "AYDIN", "BALIKESİR", "BARTIN", "BATMAN", "BAYBURT", "BİLECİK", "BİNGÖL", "BİTLİS", "BOLU", "BURDUR",
         "BURSA", "ÇANAKKALE", "ÇANKIRI", "ÇORUM", "DENİZLİ", "DİYARBAKIR", "DÜZCE", "EDİRNE", "ELAZIĞ", "ERZİNCAN",
         };

            Random rnd = new Random();
            kelime = sehirler[rnd.Next(0, sehirler.Length)];
            uzunluk = kelime.Length;
            harfler = new string[uzunluk];

            sehrilabeleaktar();
            diziyeaktar();

        }
        void sehrilabeleaktar()
        {
            label3.Text = "";
            for (int i = 0; i <uzunluk; i++)
            {
                label3.Text += "-";
            }
        }
        void diziyeaktar()
        {
            for (int i = 0; i < uzunluk; i++)
            {
                harfler[i] = kelime.Substring(i, 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text!="")
            {
                harf = textBox1.Text;
                textBox1.Clear();
                label7.Text += harf + ",";
                int check = 0;
                for (int i = 0; i < uzunluk; i++)
                {
                    if (harf == harfler[i])
                    {
                        string gharf = label3.Text;
                        label3.Text= yazdır(gharf, i, harf);
                        bharf++;
                        check = 1;
                    }
                }
                if (check == 0)
                {
                    hak--;
                    label5.Text = hak.ToString();
                    if (hak == 6)
                    {
                        pictureBox1.Visible = true;
                    }
                    else if (hak == 5)
                    {
                        pictureBox2.Visible = true;
                    }
                    else if (hak == 4)
                    {
                        pictureBox3.Visible = true;
                    }
                    else if (hak == 3)
                    {
                        pictureBox4.Visible = true;
                    }
                    else if (hak == 2)
                    {
                        pictureBox5.Visible = true;
                    }
                    else if (hak == 1)
                    {
                        pictureBox6.Visible = true;
                    }
                    else if (hak == 0)
                    {
                        pictureBox7.Visible = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Harf giriniz !");
            }
            if (bharf == uzunluk)
            {
                MessageBox.Show("Kelminenin tamamı bulundu Kazandınız !");
                this.Close();
            }
            else if (hak == 0)
            {
                MessageBox.Show("Adam Asıldı !!! Oyunu Kaybettiniz. ");
                this.Close();
            }
        }
        
        static string yazdır(string metin,int indis,string yenideger)
        {
            metin = metin.Remove(indis, 1);
            return metin.Insert(indis, yenideger);
        }
    }
}

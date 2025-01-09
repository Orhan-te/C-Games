using ArabaOyunu.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ArabaOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int serit = 1; // Başlangıçta araba orta şeritte.
        int yol = 0; // Yol hareketi için değişken.
        int hız = 70; // Oyunun başlangıç hızı.
        bool serithareket = false; // Şeritlerin yukarı-aşağı hareketini kontrol eden değişken.
        Random rnd = new Random(); // Rastgele sayı üretmek için Random sınıfı.

        // Rastgele araba bilgilerini tutacak sınıf.
        class rndaraba
        {
            public bool fake = false; // Arabayı oluşturup oluşturmadığını kontrol eder.
            public PictureBox fakearaba; // Oluşturulan arabanın PictureBox'ını tutar.
            public bool vakit = false; // O arabanın oyunda hareket edip etmeyeceğini kontrol eder.
        }

        rndaraba[] rnda = new rndaraba[2]; // Maksimum iki rastgele araba tutacak bir dizi.

        // Rastgele bir araba oluşturma fonksiyonu.
        void arabaolustur(PictureBox pb)
        {
            int rndresim = rnd.Next(0, 4); // 0 ile 3 arasında rastgele bir sayı üret.
            switch (rndresim)
            {
                case 0:
                    pb.Image = Properties.Resources.car0; break;
                case 1:
                    pb.Image = Properties.Resources.car1; break;
                case 2:
                    pb.Image = Properties.Resources.car2; break;
                case 3:
                    pb.Image = Properties.Resources.car3; break;
            }
            pb.SizeMode = PictureBoxSizeMode.StretchImage; // Arabanın görüntüsünü PictureBox'a uyacak şekilde ayarla.
        }

        // Arabanın bulunduğu şeridi değiştirir.
        private void yerdegıs()
        {
            if (serit == 1) // Orta şerit
            {
                car.Location = new Point(289, 457);
            }
            else if (serit == 0) // Sol şerit
            {
                car.Location = new Point(59, 457);
            }
            else if (serit == 2) // Sağ şerit
            {
                car.Location = new Point(530, 457);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Rastgele araba dizisini başlat.
            for (int i = 0; i < rnda.Length; i++)
            {
                rnda[i] = new rndaraba();
            }
            rnda[0].vakit = true; // İlk araba için hareket izni ver.
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Sağ ok tuşuna basıldığında arabayı sağ şeride kaydır.
            if (e.KeyCode == Keys.Right)
            {
                if (serit < 2)
                {
                    serit++;
                }
            }
            // Sol ok tuşuna basıldığında arabayı sol şeride kaydır.
            else if (e.KeyCode == Keys.Left)
            {
                if (serit > 0)
                {
                    serit--;
                }
            }

            yerdegıs(); // Yeni şeride geçir.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Yolun yukarı-aşağı hareketini sağla.
            if (serithareket == false)
            {
                for (int i = 1; i < 7; i++)
                {
                    this.Controls.Find("sol" + i.ToString(), true)[0].Top -= 25;
                    this.Controls.Find("sag" + i.ToString(), true)[0].Top -= 25;
                    serithareket = true;
                }
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    this.Controls.Find("sol" + i.ToString(), true)[0].Top += 25;
                    this.Controls.Find("sag" + i.ToString(), true)[0].Top += 25;
                    serithareket = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < rnda.Length; i++)
            {
                // Yeni araba oluşturulmamışsa ve vakti gelmişse araba oluştur.
                if (!rnda[i].fake && rnda[i].vakit)
                {
                    rnda[i].fakearaba = new PictureBox();
                    arabaolustur(rnda[i].fakearaba);
                    rnda[i].fakearaba.Size = new Size(90, 150); // Arabanın boyutunu ayarla.
                    rnda[i].fakearaba.Top = -rnda[i].fakearaba.Height; // Ekranın üstünden başlat.
                    int serityerlestır = rnd.Next(0, 3); // Hangi şeritte başlayacağını belirle.
                    if (serityerlestır == 0)
                    {
                        rnda[i].fakearaba.Left = 59; // Sol şerit.
                    }
                    else if (serityerlestır == 1)
                    {
                        rnda[i].fakearaba.Left = 289; // Orta şerit.
                    }
                    else if (serityerlestır == 2)
                    {
                        rnda[i].fakearaba.Left = 530; // Sağ şerit.
                    }
                    this.Controls.Add(rnda[i].fakearaba);
                    rnda[i].fake = true;
                }
                else
                {
                    // Eğer araba hareket ediyorsa pozisyonunu güncelle.
                    if (rnda[i].vakit)
                    {
                        rnda[i].fakearaba.Top += 20; // Arabayı aşağı kaydır.
                        if (rnda[i].fakearaba.Top >= 154) // Belirli bir pozisyona ulaştığında diğer arabayı başlat.
                        {
                            for (int j = 0; j < rnda.Length; j++)
                            {
                                if (!rnda[j].vakit)
                                {
                                    rnda[j].vakit = true;
                                    break;
                                }
                            }
                        }
                        if (rnda[i].fakearaba.Top >= this.Height - 20) // Ekrandan çıkınca arabayı kaldır.
                        {
                            rnda[i].fakearaba.Dispose();
                            rnda[i].fake = false;
                            rnda[i].vakit = false;
                        }
                    }
                }
                // Çarpışma kontrolü.
                if (rnda[i].vakit)
                {
                    float mutlakX = Math.Abs((car.Left + (car.Width / 2)) - (rnda[i].fakearaba.Left + (rnda[i].fakearaba.Width / 2)));
                    float mutlakY = Math.Abs((car.Top + (car.Height / 2)) - (rnda[i].fakearaba.Top + (rnda[i].fakearaba.Height / 2)));
                    float FarkGenislik = (car.Width / 2) + (rnda[i].fakearaba.Width / 2);
                    float FarkYukseklik = (car.Height / 2) + (rnda[i].fakearaba.Height / 2);

                    if ((FarkGenislik > mutlakX) && (FarkYukseklik > mutlakY))
                    {
                        timer2.Enabled = false; // Zamanlayıcıyı durdur.
                        timer1.Enabled = false;

                        // Oyuncuya mesaj göster ve yeniden başlatma isteyip istemediğini sor.
                        DialogResult dr = MessageBox.Show("Kaza Yaptınız yeniden başlasın mı ?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            yerdegıs(); // Arabayı başlangıç pozisyonuna al.

                            for (int j = 0; j < rnda.Length; j++)
                            {
                                rnda[j].fakearaba.Dispose();
                                rnda[j].fake = false;
                                rnda[j].vakit = false;
                            }

                            rnda[0].vakit = true;
                            timer2.Enabled = true; // Zamanlayıcıyı yeniden başlat.
                            timer2.Interval = 200;

                            timer1.Interval = 200;
                            timer1.Enabled = true;
                        }
                        else
                        {
                            this.Close(); // Oyunu kapat.
                        }
                    }
                }
            }
        }
    }
}


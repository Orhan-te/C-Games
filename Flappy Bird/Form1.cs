using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool oyunbıtı = false; 
        int boruhızı = 8; 
        int yercekimi = 10;
        int skor = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            pictureBox_kus.Top += yercekimi; // kusun sürekli aşağı düşmesi için 
            pictureBox_altbarıyer.Left -= boruhızı; // boruların sağa kayması 
            pictureBox_ustbarıyer.Left -= boruhızı;
            label_skor.Text = "SKOR : " + skor;

            if (pictureBox_altbarıyer.Left < -150)
            {
                pictureBox_altbarıyer.Left = 800;
                skor++;
            }
            // bariyerler yenilenmesi için ve her bariyer geçişinde skoru bir artırır
            if (pictureBox_ustbarıyer.Left < -150 )
            {
                pictureBox_ustbarıyer.Left = 800;
                skor++;
            }
             
            if (pictureBox_kus.Bounds.IntersectsWith(pictureBox_altbarıyer.Bounds) || // bariyerler ve zemine çarptığını kontrol eden if bloğu ve üst tarafta herhangi bir picturbox olmadığı için top -25 geçince tekiklensin 
                pictureBox_kus.Bounds.IntersectsWith(pictureBox_ustbarıyer.Bounds) ||
                pictureBox_kus.Bounds.IntersectsWith(pictureBox_zemın.Bounds) ||
                pictureBox_kus.Top<-25)
            {
                OyunBıttı();
            }
             
            

        }
        public void OyunBıttı() // timer durur ve skor belirir 
        {
            timer1.Stop();
            label_skor.Text = " Oyun Bitti ! Skorunuz : " + skor;
            oyunbıtı = true;
            label1.Visible = true;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox_kus.SendToBack(); // kusun en arkada olmasının sebebi üste olunca kötü bir görüntü olması
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) // space tusana basılı tutulduğunda kus 10 pixel yukar çıkar
            {
                yercekimi = -10;
            }
            if(oyunbıtı==true && e.KeyCode == Keys.Enter)
            {
                Application.Restart(); // oyun biter programı yeniden başlatır
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) // space tusunu bırakdığında 10 pixel asağı iner
            {
                yercekimi = 10;
            }
        }
    }
}

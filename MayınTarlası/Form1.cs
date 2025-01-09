using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayınTarlası
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> mayinlar = new List<int>();

       
        int hak = 40;
        int bulunanmayın = 0;
        private void mayınolustur() // mayın listesi oluşturur ve 20 tane sayı oluşur ve oluşan sayıları listeye ekler 
        {
            Random rnd = new Random();           
            for (int i = 1; i <= 20; i++)
            {
                int sayı = rnd.Next(1, 61);
                if (!mayinlar.Contains(sayı))
                {
                    mayinlar.Add(sayı);
                }
            }
        }
        private void buttonuret()
        {
            for (int i = 1; i <= 60; i++)
            {
                Button btn = new Button();
                btn.Size = new System.Drawing.Size(85, 85); // buttonu oluştur 60 adet boyutları belirlendikten sonra zaten flowlayoutpanel sayesinde locationları otomatik oluşur.
                btn.Text = i.ToString();
              
                if (mayinlar.Contains(i)) // button listeteki sayı ile otomatik hangi sayı ile eşleşiyorsa o button içine mayın atılır
                {
                    btn.Tag= "1";
                    
                }
                else
                {
                    btn.Tag="0";
                }
                btn.Click += Btn_Click;
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {

          
            hak--;           
            label4.Text = hak.ToString();
            Button basilanbutton = (Button) sender;
            if (basilanbutton.Tag=="1") // button içinde mayın varsa kırmızı yapılır ve bulunan mayın sayısı 1 artrılır eğer bulamazsa hakk 1 azalatılır sonunda hak biterse kabeder 
                                        // ama istenilen mayın bulma sayısına ulaşırsa oyunu kazanır.
            {
                basilanbutton.BackColor = Color.Red;
                bulunanmayın++;
               
            }
            label6.Text = bulunanmayın.ToString(); 
            basilanbutton.Enabled = false;
            if (hak==0)
            {
                MessageBox.Show("Hakkınız Bitti!!! Oyunu Kaybettiniz. ");
                this.Close();
            }
            if (bulunanmayın==12)
            {
                MessageBox.Show("Tebrikler!!! Oyunu Kazandınız. ");
                this.Close();
            }
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mayınolustur();
            buttonuret();
            
        }
    }
}

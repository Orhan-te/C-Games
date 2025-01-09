using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TicTacToeGame
{
    public partial class Form : System.Windows.Forms.Form
    {
        bool x_sıra=false;
        bool o_sıra=false;
        int xpuan = 0;
        int opuan = 0;
        int count;
        public Form()
        {
            InitializeComponent();
        }


        public void X_Sorgula()
        {
            // Yatay Sorgula
            if (b1.Text=="X" && b2.Text=="X" && b3.Text=="X")
            {
                xpuan++;
                temizleme();
                MessageBox.Show("1.Oyuncu (X) 1 Puan Aldı.");
            }
            if (b4.Text == "X" && b5.Text == "X" && b6.Text == "X")
            {
                xpuan++;
                temizleme();
                MessageBox.Show("1.Oyuncu (X) 1 Puan Aldı.");
            }
            if (b7.Text == "X" && b8.Text == "X" && b9.Text == "X")
            {
                xpuan++;
                temizleme();
                MessageBox.Show("1.Oyuncu (X) 1 Puan Aldı.");
            }


            // Dikey Sorgula
            if (b1.Text == "X" && b4.Text == "X" && b7.Text == "X")
            {
                xpuan++;
                temizleme();
                MessageBox.Show("1.Oyuncu (X) 1 Puan Aldı.");
            }
            if (b2.Text == "X" && b5.Text == "X" && b8.Text == "X")
            {
                xpuan++;
                temizleme();
                MessageBox.Show("1.Oyuncu (X) 1 Puan Aldı.");
            }
            if (b3.Text == "X" && b6.Text == "X" && b9.Text == "X")
            {
                xpuan++;
                temizleme();
                MessageBox.Show("1.Oyuncu (X) 1 Puan Aldı.");
            }

            // Çapraz Sorgula
            if (b1.Text == "X" && b5.Text == "X" && b9.Text == "X")
            {
                xpuan++;
                temizleme();
                MessageBox.Show("1.Oyuncu (X) 1 Puan Aldı.");
            }
            if (b3.Text == "X" && b5.Text == "X" && b7.Text == "X")
            {
                xpuan++;
                temizleme();
                MessageBox.Show("1.Oyuncu (X) 1 Puan Aldı.");
            }
           
        }
        public void O_Sorgula()
        {
            // Yatay Sorgula
            if (b1.Text == "O" && b2.Text == "O" && b3.Text == "O")
            {
                opuan++;
                temizleme();
                MessageBox.Show("2.Oyuncu (O) 1 Puan Aldı.");
            }
            if (b4.Text == "O" && b5.Text == "O" && b6.Text == "O")
            {
                opuan++;
                temizleme();
                MessageBox.Show("2.Oyuncu (O) 1 Puan Aldı.");
            }
            if (b7.Text == "O" && b8.Text == "O" && b9.Text == "O")
            {
                opuan++;
                temizleme();
                MessageBox.Show("2.Oyuncu (O) 1 Puan Aldı.");
            }


            // Dikey Sorgula
            if (b1.Text == "O" && b4.Text == "O" && b7.Text == "O")
            {
                opuan++;
                temizleme();
                MessageBox.Show("2.Oyuncu (O) 1 Puan Aldı.");
            }
            if (b2.Text == "O" && b5.Text == "O" && b8.Text == "O")
            {
                opuan++;
                temizleme();
                MessageBox.Show("2.Oyuncu (O) 1 Puan Aldı.");
            }
            if (b3.Text == "O" && b6.Text == "O" && b9.Text == "O")
            {
                opuan++;
                temizleme();
                MessageBox.Show("2.Oyuncu (O) 1 Puan Aldı.");
            }

            // Çapraz Sorgula
            if (b1.Text == "O" && b5.Text == "O" && b9.Text == "O")
            {
                opuan++;
                temizleme();
                MessageBox.Show("2.Oyuncu (O) 1 Puan Aldı.");
            }
            if (b3.Text == "O" && b5.Text == "O" && b7.Text == "O")
            {
                opuan++;
                temizleme();
                MessageBox.Show("2.Oyuncu (O) 1 Puan Aldı.");
            }

        }
        public void temizleme() // her puan alınınca çalışacak 
        {
            

            Thread.Sleep(500); // Oyunda kafa karışıklığı olmaması için yarım saniye bekler.
            label4.Text = xpuan.ToString();
            label6.Text = opuan.ToString();

            // kimin 3 puanı varsa oyunu bitirme 
            if (xpuan == 3)
            {
                Thread.Sleep(500);
                MessageBox.Show("1.Oyuncu(X) Kazandı Tebrikler !!! ");               
                this.Close();
            }
            if (opuan == 3)
            {
                Thread.Sleep(500);
                MessageBox.Show("2.Oyuncu(O) Kazandı Tebrikler !!! ");
                this.Close();
            }

            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            b8.Text = "";
            b9.Text = "";

            b1.Enabled = true;
            b2.Enabled = true;
            b3.Enabled = true;
            b4.Enabled = true;
            b5.Enabled = true;
            b6.Enabled = true;
            b7.Enabled = true;
            b8.Enabled = true;
            b9.Enabled = true;

            count = 0;
            label2.Text = "1.Oyuncu (X)";
        }
        public void Beraberlik() // beraberlik kontrolu 
        {
            if (count==9)
            {
                temizleme();
                MessageBox.Show("Berabere Bitti Kimse Puan Alamadı.");
            }
        }
        private void ButonaTıklama(object sender, EventArgs e)
        {
            
            this.ActiveControl = null; // sürekli butonun mavi gölgesi kafa karıştırdığı için devredışı bırakılmıştır ve diğer işlemler.
            count++; 
            Button button = (Button)sender;
            button.BackColor = System.Drawing.Color.LightGray;
            button.ForeColor = System.Drawing.Color.Black;
           
            if (x_sıra) // sıra x'da ise sıranın o'ya geçmesine sağlamak ve diğer işlemler
            {
                
                x_sıra = false;
                o_sıra = true;
                button.Text = "X";
                button.Enabled = false;
                X_Sorgula();
                Beraberlik();
            }
            else if (o_sıra) // sıra o'da ise sıranın x'e geçmesine sağlamak ve diğer işlemler
            {
                
                x_sıra = true;
                o_sıra = false;
                button.Text = "O";
                button.Enabled = false;
                O_Sorgula();
                Beraberlik();
            }

            if (o_sıra) // hangisine sıra geçmişse labela yazdırır
            {
                label2.Text = "2.Oyuncu (O)"; 

            }
            else
            {
                label2.Text = "1.Oyuncu (X)";
            }


        }

        private void Form_Load(object sender, EventArgs e)
        {
            // ilk başlangıç işlemleri
            x_sıra = true;
            label2.Text = "1.Oyuncu (X)";

            b1.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold); // butonun sizeını büyütmeden fontunu büyütme 
            b2.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold);
            b3.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold);
            b4.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold);
            b5.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold);
            b6.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold);
            b7.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold);
            b8.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold);
            b9.Font = new Font(b1.Font.FontFamily, 40, FontStyle.Bold);

        }
    }
}

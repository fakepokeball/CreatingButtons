using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuntimeControlOlusturma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sayac = 1;
        Dictionary<int, int> xyler = new Dictionary<int, int>();
        private void btnUret_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Width = 50;
            btn.Height = 20;

            btn.Text = sayac.ToString();
            //btn.BringToFront();



            int donguSayisi = 0;
            int x=0, y=0;
            Random rnd = new Random();
            bool uygunMu = false;

            while (uygunMu == false)
            {
                do
                {

                x = rnd.Next(0, this.ClientSize.Width - btn.Width);
                }
                while(xyler.ContainsKey(x));

                do
                {
                y = rnd.Next(0, this.ClientSize.Height - btn.Height);
                }
                while (xyler.ContainsKey(y));

                uygunMu = true;

                foreach (var item in xyler)
                {
                    if (((x < item.Key && x + 50 > item.Key) || (x > item.Key && x < item.Key + 50) || (x == item.Key)) && ((y < item.Value && y + 20 > item.Value) || (y > item.Value && y < item.Value + 20) || (y == item.Value)))
                    {
                        donguSayisi++;
                        uygunMu = false;
                        break;
                    }


                }
                if(donguSayisi > 500000)
                {
                    MessageBox.Show("yer kalmadı");
                    break;
                }

            }


            btn.Left = x;
            btn.Top = y;

            btn.Click += Btn_Click;

            btn.MouseHover += Btn_MouseHover;

            btn.MouseLeave += Btn_MouseLeave;

            if (uygunMu)
            {
                xyler.Add(x, y);

                sayac++;


                this.Controls.Add(btn);
            }

        }

        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btnTiklanan = (Button)sender;
            btnTiklanan.BackColor = Color.WhiteSmoke;
        }

        private void Btn_MouseHover(object sender, EventArgs e)
        {
            Button btnTiklanan = (Button)sender;
            btnTiklanan.BackColor = Color.Red;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnTiklanan=(Button)sender;

            MessageBox.Show("merhaba" + btnTiklanan.Text);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if(item is Button)
                {
                    xyler.Add(item.Location.X, item.Location.Y);
                }
            }
        }
    }
}

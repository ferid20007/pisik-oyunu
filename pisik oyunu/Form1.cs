namespace pisik_oyunu
{
    using System;
    using System.Windows.Forms;
    using System.Media;

    public partial class Form1 : Form
    {
        int xal = 0;
        int bombaYeri;
        Random random = new Random();
        bool oyunBitdi = false;

        SoundPlayer bombaSesi;

        public Form1()
        {
            InitializeComponent();

            bombaSesi = new SoundPlayer(Properties.Resources.bomba_wav);

            YeniOyun();
        }

        private void YeniOyun()
        {
            xal = 0;
            label2.Text = "0";

            oyunBitdi = false;
            bombaYeri = random.Next(0, 6);

            pictureBox1.Image = Properties.Resources.bagli_xana;
            pictureBox2.Image = Properties.Resources.bagli_xana;
            pictureBox3.Image = Properties.Resources.bagli_xana;
            pictureBox4.Image = Properties.Resources.bagli_xana;
            pictureBox5.Image = Properties.Resources.bagli_xana;
            pictureBox6.Image = Properties.Resources.bagli_xana;

            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
            pictureBox3.Enabled = true;
            pictureBox4.Enabled = true;
            pictureBox5.Enabled = true;
            pictureBox6.Enabled = true;


        }
        private void XanaYoxla(int index, PictureBox pb)
        {
            if (oyunBitdi)
                return;

            if (index == bombaYeri)
            {
                pb.Image = Properties.Resources.bomba;

                bombaSesi.Play();

                oyunBitdi = true;

                pictureBox1.Enabled = false;
                pictureBox2.Enabled = false;
                pictureBox3.Enabled = false;
                pictureBox4.Enabled = false;
                pictureBox5.Enabled = false;
                pictureBox6.Enabled = false;

                MessageBox.Show("Oyun bitdi!");
            }
            else
            {
                pb.Image = Properties.Resources.pisik;
                pb.Enabled = false;

                xal++;
                label2.Text = xal.ToString();

                if (xal == 5)
                {
                    oyunBitdi = true;

                    MessageBox.Show("Oyunu qazandınız!");

                    YeniOyun();
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            XanaYoxla(0, pictureBox1);
        }
    }
}


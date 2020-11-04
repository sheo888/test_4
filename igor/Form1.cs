using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace igor
{
    public partial class Cupcha_ : Form
    {
        public Cupcha_()
        {
            InitializeComponent();
        }

        private string text = String.Empty;

        readonly Color red = Color.Red;

        readonly Color black = Color.Black;

        //private string text = String.Empty;

        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = rnd.Next(0, Width - 50);
            int Ypos = rnd.Next(15, Height - 15);

            //Добавим различные цвета
            Brush[] colors = { Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 15),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));
            
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txtBox = ((TextBox)sender);
            if (txtBox.Text == (String)txtBox.Tag)
            {
                txtBox.Text = String.Empty;
                txtBox.ForeColor = black;
                txtBox.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == this.text)
            {
                textBox1.Text = "";
                    MessageBox.Show("правильно", "Ура", MessageBoxButtons.OK);

            }
            else
            {
                pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
                MessageBox.Show("ошибка", "ERROR", MessageBoxButtons.OK);

            }
        }
    }
}

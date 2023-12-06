using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MandelbrotSet();
        }
        private void MandelbrotSet()
        {
            int width = pictureBox1.Width;
            int heigh = pictureBox1.Height;
            Bitmap bmp = new Bitmap(width, heigh);

            for (int xc = 0; xc < heigh; xc++)
            {
                for (int yc = 0; yc < width; yc++)
                {
                    double nReal = (yc - width / 3.0) * 4.0 / (width * 7.0);
                    double nImaginario = (xc - heigh / -1.0) * 4.0 / (heigh * 7.0);
                    int iteracion = 0;
                    double x = 0, y = 0;

                    while (iteracion < 1000 && ((x * x) + (y * y)) <= 4)
                    {
                        double x_temp = (x * x) - (y * y) + nReal;
                        y = 2 * x * y + nImaginario;
                        x = x_temp;
                        iteracion++;
                    }

                    if (iteracion < 1000)
                        bmp.SetPixel(yc, xc, Color.FromArgb(iteracion % 128, iteracion % 50 * 5, iteracion % 10));
                    else
                        bmp.SetPixel(yc, xc, Color.Black);
                }
            }

            pictureBox1.Image = bmp;

        }
    }
}

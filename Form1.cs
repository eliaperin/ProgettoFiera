using System.Runtime.Intrinsics.X86;

namespace ProgettoFiera
{
    public partial class Form1 : Form
    {
        Bitmap immagine;

        Bitmap resized;
        int R ;
        int G ;
        int B ;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.jpg; *.bmp, *jpeg)|*.jpg; *.bmp; *.jpeg";
            file.ShowDialog();


            try
            {
                immagine = new Bitmap(file.FileName);
                float formfactor = (float)immagine.Width / immagine.Height;

                resized = new Bitmap    (immagine, new Size((int)(pictureBox1.Height * formfactor), pictureBox1.Height));
                pictureBox1.Image = resized;

            }
            catch(Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap rotate = new Bitmap(resized.Height, resized.Width);
            int x, y;

            for(x = 0; x < resized.Width; x++)
            {
                for(y= 0; y < resized.Height; y++)
                {
                    Color pixel= resized.GetPixel(x, y);

                    rotate.SetPixel(resized.Height - y - 1, x, pixel);

                }
                float formfactor = (float)resized.Width / resized.Height;
                Bitmap rotate2 = new Bitmap(rotate, new Size((int)(pictureBox1.Height * formfactor), pictureBox1.Height));

                pictureBox1.Image = rotate2;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap rotate = new Bitmap(resized.Height, resized.Width);
            int x, y;

            for (x = 0; x < resized.Width; x++)
            {
                for (y = 0; y < resized.Height; y++)
                {
                    Color pixel = resized.GetPixel(x, y);

                    rotate.SetPixel(y, resized.Width - x - 1, pixel);

                }
                float formfactor = (float)resized.Width / resized.Height;
                Bitmap rotate2 = new Bitmap(rotate, new Size((int)(pictureBox1.Height * formfactor), pictureBox1.Height));

                pictureBox1.Image = rotate2;

            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Bitmap NewImage = new Bitmap(resized, resized.Width, resized.Height);
            for (int y = 0; y < NewImage.Height; y++)
            {
                for (int x = 0; x < NewImage.Width; x++)
                {
                    Color pixel = NewImage.GetPixel(x, y);
                    R = pixel.R + (trbRed.Value - 255);

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    Color newpixel = Color.FromArgb(R, G, B);
                    NewImage.SetPixel(x, y, newpixel);

                }
            }
            label2.Text = trbRed.Value.ToString();
            pictureBox1.Image = NewImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trbRed.Value = 255;
            trbGreen.Value = 255;
            trbBlue.Value = 255;


        }

        private void trackBar1_Scroll_1(object sender, EventArgs e)
        {
            Bitmap NewImage = new Bitmap(resized, resized.Width, resized.Height);
            for (int y = 0; y < NewImage.Height; y++)
            {
                for (int x = 0; x < NewImage.Width; x++)
                {
                    Color pixel = NewImage.GetPixel(x, y);
                    G = pixel.G + (trbGreen.Value - 255);

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    Color newpixel = Color.FromArgb(R, G, B);
                    NewImage.SetPixel(x, y, newpixel);

                }
            }
            label4.Text = trbGreen.Value.ToString();
            pictureBox1.Image = NewImage;
        }

        private void trbBlue_Scroll(object sender, EventArgs e)
        {
            Bitmap NewImage = new Bitmap(resized, resized.Width, resized.Height);
            for (int y = 0; y < NewImage.Height; y++)
            {
                for (int x = 0; x < NewImage.Width; x++)
                {
                    Color pixel = NewImage.GetPixel(x, y);
                    B = pixel.B + (trbBlue.Value - 255);

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;

                    Color newpixel = Color.FromArgb(R, G, B);
                    NewImage.SetPixel(x, y, newpixel);

                }
            }
            label6.Text = trbGreen.Value.ToString();
            pictureBox1.Image = NewImage;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap NewImage = new Bitmap(resized.Width, resized.Height);
            int x, y;



            for (x = 0; x < resized.Width; x++)
            {
                for (y = 0; y < resized.Height; y++)
                {

                    Color pixel = resized.GetPixel(x, y);
                    int R;
                    int G;
                    int B;

                    R = (pixel.R + pixel.G + pixel.B) / 3;
                    G = (pixel.R + pixel.G + pixel.B) / 3;
                    B = (pixel.R + pixel.G + pixel.B) / 3;



                    Color newpixel = Color.FromArgb(R, G, B);
                    NewImage.SetPixel(x, y, newpixel);
                }
            }
            pictureBox1.Image = NewImage;
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap NewImage = new Bitmap(resized.Width, resized.Height);
            int x, y;

            for (x = 0; x < resized.Width; x++)
            {
                for (y = 0; y < resized.Height; y++)
                {

                    Color pixel = resized.GetPixel(x, y);
                    int R;
                    int G;
                    int B;

                    R = (pixel.R + pixel.G + pixel.B) / 3;
                    G = (pixel.R + pixel.G + pixel.B) / 3;
                    B = (pixel.R + pixel.G + pixel.B) / 3;

                    if (R < 127 && G < 127 && B < 127)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                    }
                    else
                    {
                        R = 255;
                        G = 255;
                        B = 255;
                    }


                    Color newpixel = Color.FromArgb(R, G, B);
                    NewImage.SetPixel(x, y, newpixel);
                }
            }
            pictureBox1.Image = NewImage;
        }

        private void trackBar1_Scroll_2(object sender, EventArgs e)
        {
            Bitmap NewImage = new Bitmap(resized.Width, resized.Height);
            int x, y;

            int valore = 0;
            valore = trackBar1.Value;


            for (x = 0; x < resized.Width; x++)
            {
                for (y = 0; y < resized.Height; y++)
                {

                    Color pixel = resized.GetPixel(x, y);
                    int R;
                    int G;
                    int B;

                    R = (pixel.R + pixel.G + pixel.B) / 3;
                    G = (pixel.R + pixel.G + pixel.B) / 3;
                    B = (pixel.R + pixel.G + pixel.B) / 3;

                    if (R < valore && G < valore && B < valore)
                    {
                        R = 0;
                        G = 0;
                        B = 0;
                    }
                    else
                    {
                        R = 255;
                        G = 255;
                        B = 255;
                    }


                    Color newpixel = Color.FromArgb(R, G, B);
                    NewImage.SetPixel(x, y, newpixel);
                }
            }
            pictureBox1.Image = NewImage;
           
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label7.Text = trackBar2.Value.ToString();

            float fatform = (float)immagine.Width / (float)pictureBox1.Width;
            float highform = (float)immagine.Height / (float)pictureBox1.Height;
            Bitmap Lorenzo = new Bitmap(immagine, new Size((int)(immagine.Width / fatform), (int)(immagine.Height / highform)));
            Bitmap NewImage = new Bitmap(Lorenzo.Width, Lorenzo.Height);

            int x, y;

            for (x = 0; x < Lorenzo.Width; x++)
            {
                for (y = 0; y < Lorenzo.Height; y++)
                {

                    Color pixel = Lorenzo.GetPixel(x, y);

                    int R = pixel.R + trackBar2.Value - 255;
                    int G = pixel.G + trackBar2.Value - 255;
                    int B = pixel.B + trackBar2.Value - 255;

                    if (R < 0) R = 0;
                    if (R > 255) R = 255;

                    if (G < 0) G = 0;
                    if (G > 255) G = 255;

                    if (B < 0) B = 0;
                    if (B > 255) B = 255;

                    Color newpixel = Color.FromArgb(R, G, B);
                    NewImage.SetPixel(x, y, newpixel);
                }
            }
            pictureBox1.Image = NewImage;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }
    }
}
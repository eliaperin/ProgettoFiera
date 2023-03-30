namespace ProgettoFiera
{
    public partial class Form1 : Form
    {
        Bitmap immagine;
        Bitmap resized;
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

                    rotate.SetPixel( y, x, pixel);

                }
                float formfactor = (float)resized.Width / resized.Height;
                Bitmap rotate2 = new Bitmap(rotate, new Size((int)(pictureBox1.Height * formfactor), pictureBox1.Height));

                pictureBox1.Image = rotate2;
            }
        }
    }
}
using System.Windows.Forms;

namespace FormForExcercise
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    class LineChart
    {

        private Point mouseDownLocation;
        private bool isDragging = false;
        private PictureBox pictureBox1 { get; set; }

        private Bitmap graphBitmap;

        public LineChart(PictureBox pictureBox)
        {

            this.pictureBox1 = pictureBox;

            // move Box
            // Register mouse events
            pictureBox1.MouseUp += (sender, args) =>
            {
                var c = sender as PictureBox;
                if (null == c) return;
                isDragging = false;
            };

            pictureBox1.MouseDown += (sender, args) =>
            {
                if (args.Button != MouseButtons.Left) return;
                isDragging = true;
                mouseDownLocation.X = args.X;
                mouseDownLocation.Y = args.Y;
            };

            pictureBox1.MouseMove += (sender, args) =>
            {
                var c = sender as PictureBox;
                if (!isDragging || null == c) return;
                c.Top = args.Y + c.Top - mouseDownLocation.Y;
                c.Left = args.X + c.Left - mouseDownLocation.X;
            };
            graphBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = graphBitmap;


        }

        public void Draw(Font font)
        {
            using (Graphics g = Graphics.FromImage(graphBitmap))
            {
                int padding = 100;
                int width = graphBitmap.Width - 2 * padding;
                int height = graphBitmap.Height - 2 * padding;
                int xMin = 0;
                int xMax = 10;
                int yMin = 0;
                int yMax = 10;

                Pen axisPen = new Pen(Color.Black, 2);
                Brush pointBrush = new SolidBrush(Color.Red);

                g.DrawLine(axisPen, padding, padding + height, padding + width, padding + height);
                g.DrawLine(axisPen, padding, padding + height, padding, padding);

                for (int i = xMin; i <= xMax; i++)
                {
                    int x = padding + (i - xMin) * width / (xMax - xMin);
                    g.DrawLine(axisPen, x, padding + height - 5, x, padding + height + 5);
                    g.DrawString(i.ToString(), font, Brushes.Black, x - 10, padding + height + 10);
                }

                for (int i = yMin; i <= yMax; i++)
                {
                    int y = padding + height - (i - yMin) * height / (yMax - yMin);
                    g.DrawLine(axisPen, padding - 5, y, padding + 5, y);
                    g.DrawString(i.ToString(), font, Brushes.Black, padding - 30, y - 10);
                }

                axisPen = new Pen(Color.Red, 2);

                //         Pen        x1          y1                  x2                  y2
                //g.DrawLine(axisPen, padding, padding + height , padding + width + 6, padding + height + 6);
                g.DrawLine(axisPen, padding, padding + height ,  6, 6);
            }

            pictureBox1.Invalidate();
        }
    }
}
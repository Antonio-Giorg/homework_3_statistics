using System.Drawing;
using System.Windows.Forms;

namespace LineChartNameSpace
{
    class LineChart
    {

        private Point mouseDownLocation;
        private bool isDragging = false;
        private PictureBox pictureBox1 { get; set; }

        private Bitmap graphBitmap;

        public LineChart(Form form, PictureBox pictureBox)
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

            DrawAxies(form);

            pictureBox1.Invalidate();
        }

        public void DrawAxies(Form form)
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
                    g.DrawString(i.ToString(), form.Font, Brushes.Black, x - 10, padding + height + 10);
                }

                for (int i = yMin; i <= yMax; i++)
                {
                    int y = padding + height - (i - yMin) * height / (yMax - yMin);
                    g.DrawLine(axisPen, padding - 5, y, padding + 5, y);
                    g.DrawString(i.ToString(), form.Font, Brushes.Black, padding - 30, y - 10);
                }

                Pen axisPen2 = new Pen(Color.Red, 2);
                int y2 = padding + height - (0 - yMin) * height / (yMax - yMin);
                g.DrawLine(axisPen2, padding - 5, y2, padding + 5, y2);
            }

        }
        public void DrawCharth()
        {
            using (Graphics g = Graphics.FromImage(graphBitmap))
            {
                
                
            }
        }
    }
}
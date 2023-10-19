using System.Windows.Forms;

namespace FormForExcercise

{
    public partial class Form1 : Form
    {

        private Point mouseDownLocation;
        private bool isDragging = false;


        private Bitmap graphBitmap;

        public Form1()
        {
            InitializeComponent();

            LineChart chart = new LineChart(pictureBox1);

            chart.Draw(this.Font);



        }

        

    }
}
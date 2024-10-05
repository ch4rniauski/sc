namespace laba12
{
    public partial class Form1 : Form
    {
        private bool isMouseDowned = false;
        private ArrayPoints _arrayPoints = new(2);
        private Bitmap _map;
        private Graphics _graphics;
        private Pen _pen = new(color:Color.Black, width: 3f);

        public Form1()
        {
            InitializeComponent();
            SetSize();
        }

        private class ArrayPoints
        {
            private int _index = 0;
            public Point[] points {  get; }

            public ArrayPoints(int size)
            {
                points = new Point[size];
            }

            public void SetPoint(int x, int y)
            {
                if (_index >= points.Length)
                    _index = 0;

                points[_index] = new Point(x, y);
                _index++;
            }

            public void ResetPoints()
            {
                _index = 0;
            }

            public int GetAmountOfPoint()
            {
                return _index;
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDowned = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDowned = false;
            _arrayPoints.ResetPoints();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMouseDowned)
                return;

            _arrayPoints.SetPoint(e.X, e.Y);

            if (_arrayPoints.GetAmountOfPoint() >= 2)
            {
                _graphics.DrawLines(_pen, _arrayPoints.points);
                pictureBox1.Image = _map;
                _arrayPoints.SetPoint(e.X, e.Y);
            }
        }

        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            _map = new(rectangle.Width, rectangle.Height);
            _graphics = Graphics.FromImage(_map);

            _pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            _pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }
    }
}

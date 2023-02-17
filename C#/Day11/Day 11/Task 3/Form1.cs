using System.Windows.Forms;

namespace Task_3
{
    public partial class Form1 : Form
    {
        Rectangle rect;
        bool isPressed = false;
        public Form1()
        {
            InitializeComponent();
            rect = new Rectangle(150, 150, 50, 50);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), rect);
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed= true;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed) 
            {
                rect.X = e.X;
                rect.Y = e.Y;
                if (rect.Top < 0)
                    rect.Y = 0;
                if (rect.Right > ClientSize.Width)
                    rect.X = ClientSize.Width - rect.Width;
                if (rect.Left < 0)
                    rect.X = 0;
                if (rect.Bottom > ClientSize.Height)
                    rect.Y = ClientSize.Height - rect.Height;
                Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed= false;
        }
    }
}
namespace Task_2
{
    public partial class Form1 : Form
    {
        Pen pen;
        Graphics G;
        int x;
        int y;
        bool isPressed = false;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 5);
            G = this.CreateGraphics();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                pen.Color = dlgColor.Color;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                pen.Color = this.BackColor;
            G.DrawLine(pen, e.Location, e.Location);
            isPressed= true;
            x = e.X; y = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isPressed)
            {
                G.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X; y = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
            pen.Color = dlgColor.Color;
        }
    }
}
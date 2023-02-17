using System.Drawing.Drawing2D;

namespace Task_4
{
    public partial class Form1 : Form
    {
        bool isPressed = false;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            path.AddEllipse(0, 0, 150, 150);
            path.AddEllipse(630, 0, 150, 150);

            path.FillMode = FillMode.Winding;

            this.Region = new Region(path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if(isPressed)
            {
                this.Location = e.Location;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed=false;
        }
    }
}
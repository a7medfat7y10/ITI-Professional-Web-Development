using System.Diagnostics.Metrics;
using System.Reflection;

namespace Task_5
{
    public partial class Form1 : Form
    {
        Pen pen;
        int ball_xpos;
        bool isAtLeft = false;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Brushes.Black, 5);
            ball_xpos = 155;
            timer1.Enabled = true;
            timer1.Interval = 10;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(pen, 110, 150, 50, 50);
            e.Graphics.DrawLine(pen, 135, 200, 135, 300);
            e.Graphics.DrawLine(pen, 135, 230, 110, 270);
            e.Graphics.DrawLine(pen, 135, 230, 155, 270);
            e.Graphics.DrawLine(pen, 135, 300, 110, 350);
            e.Graphics.DrawLine(pen, 135, 300, 155, 350);
            e.Graphics.DrawEllipse(pen, 610, 150, 50, 50);
            e.Graphics.DrawLine(pen, 635, 200, 635, 300);
            e.Graphics.DrawLine(pen, 635, 230, 610, 270);
            e.Graphics.DrawLine(pen, 635, 230, 655, 270);
            e.Graphics.DrawLine(pen, 635, 300, 610, 350);
            e.Graphics.DrawLine(pen, 635, 300, 655, 350);

            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball_xpos > 560)
                isAtLeft = false;
            if (ball_xpos < 155)
                isAtLeft = true;

            if (isAtLeft == true)
            {
                ball_xpos++;
                this.CreateGraphics().FillEllipse(new SolidBrush(this.BackColor), ball_xpos - 1, 300, 50, 50);
                this.CreateGraphics().FillEllipse(Brushes.Black, ball_xpos, 300, 50, 50);
            }
            else
            {
                this.CreateGraphics().FillEllipse(new SolidBrush(this.BackColor), ball_xpos +1, 300, 50, 50);
                this.CreateGraphics().FillEllipse(Brushes.Black, ball_xpos, 300, 50, 50);
                ball_xpos--;
            }
        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D; 
using System.Windows.Forms;

namespace Lab_1_Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.DeepSkyBlue; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button closeBtn = new Button();
            closeBtn.Text = "Закрыть";
            closeBtn.Location = new Point(this.Width / 2 - 40, this.Height / 2 - 15);
            closeBtn.Click += (s, ev) => this.Close();
            this.Controls.Add(closeBtn);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath myPath = new GraphicsPath())
            {
                myPath.AddEllipse(0, 0, this.Width, this.Height);
                this.Region = new Region(myPath);
            }
        }

   
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                this.Capture = false;
                Message m = Message.Create(this.Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref m);
            }
        }
    }
}

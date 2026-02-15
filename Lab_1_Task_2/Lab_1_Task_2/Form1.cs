using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Lab_1_Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Убираем рамки
            this.BackColor = Color.Green;               // Зеленый цвет
            this.Width = 400;
            this.Height = 400;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создаем кнопку GREENPEACE
            Button btnClose = new Button();
            btnClose.Text = "GREENPEACE";
            btnClose.AutoSize = true;
            btnClose.BackColor = Color.White;
            // Центрируем кнопку
            btnClose.Location = new Point((this.Width - btnClose.Width) / 2,
                                          (this.Height - btnClose.Height) / 2);
            btnClose.Click += (s, ev) => this.Close();
            this.Controls.Add(btnClose);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                // Определяем 4 точки ромба (середины сторон прямоугольника)
                Point[] points = {
                    new Point(this.Width / 2, 0),          // Верх
                    new Point(this.Width, this.Height / 2), // Право
                    new Point(this.Width / 2, this.Height), // Низ
                    new Point(0, this.Height / 2)           // Лево
                };

                path.AddPolygon(points);
                this.Region = new Region(path);
            }
        }

        // Позволяет перетаскивать ромб за любое место
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

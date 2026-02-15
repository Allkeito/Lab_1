using System;
using System.Windows.Forms;

namespace Lab_1_Task_2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            // Разворачиваем форму на весь экран при запуске
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Стартовая форма";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Button btnOpen = new Button();
            btnOpen.Text = "Открыть ромб";
            btnOpen.Size = new System.Drawing.Size(150, 40);
            btnOpen.Location = new System.Drawing.Point(50, 50); // Или в центре
            btnOpen.Click += (s, ev) => {
                Form1 frm1 = new Form1();
                frm1.Show();
            };
            this.Controls.Add(btnOpen);
        }
    }
}

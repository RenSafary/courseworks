using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Rex
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PictureBox Cube = new PictureBox();
        int start = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (start == 0)
            {
                cube();
            }
        }
        string move = "run";
        public void cube()
        {
            Cube.Size = new Size(30, 30);
            Cube.BackColor = Color.Gray;
            Cube.Location = new Point(70, 158);
            Controls.Add(Cube);

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Space":
                    move = "jump";
                    restart();
                    break;
                case "Up":
                    move = "jump";
                    break;
            }
            start++;
        }
        int k = 0;
        int t = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (start > 0)
            {
                if (move == "jump")
                {
                    int g = 0;
                    if (k < 25)
                    {
                        timer1.Interval = 1;
                        Cube.Location = new Point(Cube.Location.X, Cube.Location.Y - 5);
                        k++;
                    }
                    if (k >= 25)
                    {
                        Cube.Location = new Point(Cube.Location.X, Cube.Location.Y + 5);
                        k++;
                        if (k == 50) g++;
                    }
                    if (g == 1)
                    {
                        move = "run";
                        k = 0;
                        timer1.Interval = 200;
                    }
                }
                t++;
            }
        }
        PictureBox c = new PictureBox();
        PictureBox c1 = new PictureBox();
        int x = 800;
        int x1 = 800;
        public void CubeC_disappear()
        {
            if (c.Location.X == -30) x = 800;
            if (c1.Location.X == -30) x1 = 800;
        }
        public void CubeC()
        {
            c.BackColor = Color.Pink;
            c.Location = new Point(x, 138);
            c.Size = new Size(30, 50);
            Controls.Add(c);

            c1.BackColor = Color.Brown;
            c1.Location = new Point(x1 + 400, 138);
            c1.Size = new Size(30, 50);
            Controls.Add(c1);
        }
        int t1 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (start > 0)
            {
                collision();
                CubeC();
                CubeC_disappear();
                if (t1 % 2 == 0 || t1 % 2 == 1)
                {
                    x -= 5;
                    x1 -= 5;
                    t1++;
                }
            }
        }
        int game = 0;
        public void collision()
        {
            for (int h = -30; h <= 30; h++)
            {
                for (int j = -20; j <= 30; j++)
                {
                    if (Cube.Location.X == c.Location.X - h && Cube.Location.Y == c.Location.Y - j ||
                        Cube.Location.X == c1.Location.X - h && Cube.Location.Y == c1.Location.Y - j)
                    {
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();
                        game++;
                    }

                }
            }
        }
        int t2 = 2;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (start > 0) t2++; this.Text = t2.ToString();
        }

        public void restart()
        {
            if (game == 1)
            {
                game = 0;
                Application.Restart();
            }
        }

    }
}

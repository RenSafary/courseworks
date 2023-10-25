using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Snake_
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
            head.Location = new Point(150, 165);
            head.Size = new Size(15, 15);
            head.BackColor = Color.DarkGreen;
            Controls.Add(head);
        }
        PictureBox food = new PictureBox();
        PictureBox[] tails = new PictureBox[300];
        PictureBox head = new PictureBox();
        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(button1);
            c_tails();
            Food();
            panel1.Show();
            sc.Show();
            sc.BringToFront();
        }
        string Key;
        int K = 0;
        int k = 0; // очки
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Up":
                    if (head.Location.Y == tails[0].Location.Y + 15) Key = "Down";
                    else Key = "Up";
                    K++;
                    break;
                case "Down":
                    if (head.Location.Y == tails[0].Location.Y - 15) Key = "Up";
                    else Key = "Down";
                    K++;
                    break;
                case "Right":
                    if (K == 0) ;
                    else
                    {
                        if (head.Location.X == tails[0].Location.X - 15) Key = "Left";
                        else Key = "Right";
                    }
                    break;
                case "Left":
                    if (head.Location.X == tails[0].Location.X + 15) Key = "Right";
                    else Key = "Left";
                    K++;
                    break;
            }
        }
        int f = 0; // количество хвостов
        void c_tails()
        {
            for (int i = f; i < k + 2; i++)
            {
                PictureBox t = new PictureBox();
                if (i == 0) t.Location = new Point(head.Location.X + 15, head.Location.Y);
                else t.Location = new Point(tails[i - 1].Location.X + 15, tails[i - 1].Location.Y);
                t.Size = new Size(15, 15);
                t.BackColor = Color.Green;
                Controls.Add(tails[i] = t);
                f++;
            }
        }
        int ticks;
        void Move()
        {
            for (int i = k + 1; i >= 0; i--)
            {
                if (i != 0) tails[i].Location = new Point(tails[i - 1].Location.X, tails[i - 1].Location.Y);
                else
                {
                    if (Key == "Up") tails[i].Location = new Point(head.Location.X, head.Location.Y + 15);
                    if (Key == "Down") tails[i].Location = new Point(head.Location.X, head.Location.Y - 15);
                    if (Key == "Right") tails[i].Location = new Point(head.Location.X - 15, head.Location.Y);
                    if (Key == "Left") tails[i].Location = new Point(head.Location.X + 15, head.Location.Y);
                }
            }
        }
        void Up()
        {
            head.Location = new Point(head.Location.X, head.Location.Y - 15);
        }
        void Down()
        {
            head.Location = new Point(head.Location.X, head.Location.Y + 15);
        }
        void Right()
        {
            head.Location = new Point(head.Location.X + 15, head.Location.Y);
        }
        void Left()
        {
            head.Location = new Point(head.Location.X - 15, head.Location.Y);
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (K > 0)
            {
                if (ticks % 2 == 0 || ticks % 2 == 1)
                {
                    eat();
                    lose();
                    if (Key == "Up") Up();
                    if (Key == "Down") Down();
                    if (Key == "Right") Right();
                    if (Key == "Left") Left();
                    Move();
                }
                ticks++;
            }
        }
        void Form1_Load(object sender, EventArgs e)
        {
        }
        void Food()
        {
            Random rn = new Random();
            int x = rn.Next(360);
            int y = rn.Next(345);
            while (x % 15 != 0) x = rn.Next(360);
            while (y % 15 != 0) y = rn.Next(345);
            food.Location = new Point(x, y);
            food.BackColor = Color.Yellow;
            food.Size = new Size(15, 15);
            Controls.Add(food);
        }
        void eat()
        {
            if (head.Location == food.Location)
            {
                Controls.Remove(food);
                Food();
                k++;
                sc.Text = "Счёт: " + k.ToString();
                c_tails();
            }
        }
        void lose()
        {
            for (int i = 1; i < k + 2; i++)
            {
                if (head.Location.X > 360 || head.Location.X < 0 ||
                    head.Location.Y > 345 || head.Location.Y < 0 ||
                    head.Location == tails[i].Location)
                {
                    timer1.Stop();
                    gameover.Show();
                    button2.Show();
                    Controls.Remove(food);
                    List<int> score = new List<int>();
                    if (k != 0) score.Add(k);
                    for (int g = 0; g < k + 2; g++)
                    {
                        Controls.Remove(tails[g]);
                    }
                    Controls.Remove(head);
                    Close.Show();
                    Restart.Show();
                    StreamReader sr = new StreamReader(@"C:\Users\ilyae\source\repos\Snake!\Snake!\bin\Debug\Record.txt");
                    int st;
                    while (!sr.EndOfStream)
                    {
                        st = Convert.ToInt32(sr.ReadLine());
                        score.Add(st);
                    }
                    sr.Close();
                    for (int f = 0; f < score.Count; f++)
                    {
                        for (int f1 = f + 1; f1 < score.Count; f1++)
                        {
                            if (score[f] < score[f1])
                            {
                                int swap = score[f];
                                score[f] = score[f1];
                                score[f1] = swap;
                            }
                            if (score[f] == score[f1]) score.RemoveAt(f);
                        }
                    }
                    StreamWriter sw = new StreamWriter(@"C:\Users\ilyae\source\repos\Snake!\Snake!\bin\Debug\Record.txt");
                    for (int f = 0; f < score.Count; f++)
                    {
                        sw.WriteLine(score[f]);
                    }
                    sw.Close();
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ScoreBox.Show();
            ScoreBox.BringToFront();
            StreamReader sr = new StreamReader(@"C:\Users\ilyae\source\repos\Snake!\Snake!\bin\Debug\Record.txt");
            int st;
            int k = 1;
            while (!sr.EndOfStream)
            {
                st = Convert.ToInt32(sr.ReadLine());
                ScoreBox.Items.Add(k + "." + " " + st);
                k++;
            }
            sr.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ScoreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScoreBox.SelectedIndexChanged += ScoreBox_SelectedIndexChanged;
        }
    }
}

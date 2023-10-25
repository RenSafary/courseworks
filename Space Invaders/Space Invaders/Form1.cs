using System;
using System.Drawing;
using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        PictureBox hero = new PictureBox(); // объёкт для космолёта
        int es = 0; // счётчик для врага1
        PictureBox enemy1 = new PictureBox(); // объёкт для врага1
        public void e_spawn1() 
        {
            if (es == 0)
            {
                enemy1.Size = new Size(50, 50); // задаем размер врагу
                enemy1.Image = new Bitmap(@"C:\Users\ilyae\source\repos\Space Invaders\Space Invaders\obj\enemy.png"); // задаем объёкту изображение
                enemy1.Location = new Point(55, 15); // задаем расположение для врага
                Controls.Add(enemy1); // добавляем его на форму
                enemy1.BringToFront(); // делаем отображение объекта приоритетным
                es = 1; // один враг
                death++; // если враг умер, то счётчик убийств увеличивается
            }
        }
        int es1 = 0; // счётчик для врага2
        PictureBox enemy2 = new PictureBox(); // объёкт для врага2
        public void e_spawn2()
        {
            if (es1 == 0)
            {
                enemy2.Size = new Size(50, 50); // задаем размер врагу
                enemy2.Image = new Bitmap(@"C:\Users\ilyae\source\repos\Space Invaders\Space Invaders\obj\enemy.png");// задаем объёкту изображение
                enemy2.Location = new Point(550, 15);// задаем расположение для врага
                Controls.Add(enemy2);// добавляем его на форму
                enemy2.BringToFront(); // делаем отображение объекта приоритетным
                es1 = 1; // один враг
                death++; // если враг умер, то счётчик убийств увеличивается
            }
        }
        int c = 0; // счётчик для сердечек
        int death = -2;// счётчик смертей
        Label s = new Label(); // объёкт текст
        public void score()
        {
            s.Text = "Счёт: "; // текст объёкта
            s.Location = new Point(95, 425); // расположение текста
            s.Font = new Font("Microsoft Sans Serif", 16); // шрифт и размер
            s.ForeColor = Color.White; // цвет шрифта
            s.BackColor = Color.Black; // фон шрифта
            Controls.Add(s); // добавляем объёкт на форму
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Controls.Remove(button1); // удаляем кнопку с формы
            hero.Size = new Size(50, 50); // задаем размер космолёта
            hero.Location = new Point(285, 360); // задаем положение 
            hero.Image = new Bitmap(@"C:\Users\ilyae\source\repos\Space Invaders\Space Invaders\obj\hero0.png"); // добавляем изорбажение космолёта
            Controls.Add(hero); // добавляем объект на форму
            hero.BringToFront(); // делаем отображение объекта приоритетным
            e_spawn1(); // генерируем врага1
            e_spawn2();  // генерируем врага2
            e_movements.Start(); // запускаем таймер движений врагов
            h_bullet.Start(); // запускаем таймер движений пуль космолёта
            if (c == 0)
            {
                c = 1; // отключаем if
                i_hearts(); // добавляем сердечки
            }
            score();// выводим счёт
        }
        PictureBox bullet = new PictureBox(); // объёкт пуля
        public void h_bullets() 
        {
            if (b > 0) // если пули нет, то она создается...
            {
                bullet.Location = new Point(hero.Location.X + 23, hero.Location.Y - 2); // положение пули
                bullet.BackColor = Color.White; // цвет пули
                bullet.Size = new Size(5, 11); // размер пули
            }
            b = 0; // счётчик обнуляется
            Controls.Add(bullet); // объёкт пуля добавляется на форму
        }
        PictureBox ebullet1 = new PictureBox(); // объёкт пуля врага1
        int eb = 0; // счётчик пуль
        public void e_bullets1()
        {
            if (c == 1 && eb == 0) // если пули нет, то она создается
            {
                ebullet1.Location = new Point(enemy1.Location.X + 23, enemy1.Location.Y + 46); // положение пули врага1
                ebullet1.BackColor = Color.Red;  // цвет пули
                ebullet1.Size = new Size(5, 14); // размер пули
                Controls.Add(ebullet1); // объёкт пуля добавляется на форму
                eb = 1; // счётчик
            }
            ebullet1.BringToFront(); // делаем отображение объекта приоритетным
        }
        int eb1 = 0;// счётчик пуль
        PictureBox ebullet2 = new PictureBox();
        public void e_bullets2() 
        {
            if (c == 1 && eb1 == 0)// если пули нет, то она создается
            {
                ebullet2.Location = new Point(enemy2.Location.X + 23, enemy2.Location.Y + 46);// положение пули врага1
                ebullet2.BackColor = Color.Red;  // цвет пули
                ebullet2.Size = new Size(5, 14); // размер пули
                Controls.Add(ebullet2); // объёкт пуля добавляется на форму
                eb1 = 1; // счётчик
            }
            ebullet1.BringToFront(); // делаем отображение объекта приоритетным
        }
        int b = 1; // счётчик пуль космолёта
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString()) // управление кнопками
            {
                case "Left": // если срабатывает левая, то 
                    if (hero.Location.X > 4) hero.Location = new Point(hero.Location.X - 20, hero.Location.Y); // космолёт смещается влево
                    break; // ломает переключатель
                case "Right": // если срабатывает правая, то 
                    if (hero.Location.X < 580) hero.Location = new Point(hero.Location.X + 20, hero.Location.Y); // космолёт смещается вправо
                    break; // ломает переключатель
                case "Space": // если срабатывает пробел, то 
                    h_bullets(); // спавнится пуля космолёта
                    break; // ломает переключатель
            }
        }
        PictureBox[] hearts = new PictureBox[4]; // объёкт сердце
        int kheart = 2; // счётчик сердец
        public void i_hearts()
        {
            for (int i = kheart+1; i >= 0; i--) // счётчик для массива
            {
                PictureBox heart = new PictureBox(); // объёкт сердце
                heart.Size = new Size(25, 25); // задаем размер сердца
                heart.Image = new Bitmap(@"C:\Users\ilyae\source\repos\Space Invaders\Space Invaders\obj\heart.png"); // открываем изображение
                if (i == 2) heart.Location = new Point(10, 425); // положение 3 сердца
                if (i == 1) heart.Location = new Point(35, 425); // положение 3 сердца
                if (i == 0) heart.Location = new Point(60, 425); // положение 3 сердца
                Controls.Add(hearts[i] = heart); // добавляем сердце на форму
                heart.BringToFront(); // делаем отображение объекта приоритетным
            }
        }
        int t = 0; // счётчик для таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t % 2 == 0 || t % 2 == 1) // если число четное или нечетное, то
            {
                s.Text = "Счёт: " + death.ToString(); // счётчик выводит число убийств
            }
            t++; // счётчик таймера увеличивается
        }
        int t1 = 0; // счётчик для таймера

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int t2 = 0; // счётчик для таймера
        private void bullets_e_Tick(object sender, EventArgs e)
        {
            if (c == 1 && (t2 % 2 == 0 || t2 % 2 == 1)) // если число четное или нечетное, то
            {
                ebullet1.Location = new Point(ebullet1.Location.X, ebullet1.Location.Y + 6); // передвижение пули врага1
                ebullet2.Location = new Point(ebullet2.Location.X, ebullet2.Location.Y + 6); // передвижение пули врага2
                for (int i = 0; i <= 50; i++) // счётчик 
                {
                    for (int j = 35; j <= 45; j++) // счётчик
                    {
                        if ((ebullet1.Location.X == hero.Location.X + i) && (ebullet1.Location.Y == hero.Location.Y + j)) // если пуля врага1 попала космолёт, то
                        {
                            Controls.Remove(ebullet1); // она удаляется
                            eb = 0; // счётчик обнуляется
                        }
                    }
                }
                for (int i = 0; i <= 50; i++) // счётчик
                {
                    for (int j = 35; j <= 45; j++) // счётчик
                    {
                        if ((ebullet2.Location.X == hero.Location.X + i) && (ebullet2.Location.Y == hero.Location.Y + j)) // если пуля врага2 попала космолёт, то
                        {
                            Controls.Remove(ebullet2); // она удаляется
                            eb1 = 0; // счётчик обнуляется
                        }
                    }
                }

                if (eb==0 || eb1 == 0)
                {
                    for (int i=kheart+1; i>=0; i--) // счётчик для сердец
                    {
                        Controls.Remove(hearts[i]); // сердце удаляется, если пуля врага попала в космолёт
                        kheart--; // количество сердец уменьшается
                        break; // счётчик ломается
                    }
                }
                if (ebullet1.Location.Y > 500) // если пуля за пределами формы, то 
                {
                    Controls.Remove(ebullet1); // она удаляется
                    eb = 0; // счётчик обнуляется
                }

                if (ebullet2.Location.Y > 500)  // если пуля за пределами формы, то 
                {
                    Controls.Remove(ebullet2); // она удаляется
                    eb1 = 0; // счётчик обнуляется
                }
            }
            t2++; // счётчик таймера увеличивается
            e_bullets1(); // создаем пулю врага1
            e_bullets2(); // создаем пулю врага2
            lost(); // проверяем количество сердец, если их 0, то игра заканчивается
        }
        int t3 = 0; // счётчик для таймера
        int k1, k2 = 0; // счётчик для переключения движения врагов
        private void e_movements_Tick(object sender, EventArgs e)
        {
            if (t3 % 2 == 0 || t3 % 2 == 1) // если число четное или нечетное
            {
                if (enemy1.Location.Y == 15 && es > 0) // если координата врага1 по Y равна 15 и он сам существует, то 
                {
                    if (enemy1.Location.X == 550) k1 = 1; // если координата по X равна 550, то переключаем движение
                    if (enemy1.Location.X == 55) k1 = 0; // если координата по X равна 55, то переключаем движение

                    if (enemy1.Location.X < 550 && k1 == 0) // если координата врага1 по X меньше 550 и счётчик равен 0
                    {
                        enemy1.Location = new Point(enemy1.Location.X + 5, 15); // то враг1 движется вправо
                    }
                    if (enemy1.Location.X > 55 && k1 == 1) // если координата врага1 по X больше 55 и счётчик равен 1
                    {
                        enemy1.Location = new Point(enemy1.Location.X - 5, 15);// то враг1 движется влево
                    }
                }
               
                if (enemy2.Location.Y == 15 && es1 > 0) // если координата врага2 равна 15 и он сам существует, то 
                {
                    if (enemy2.Location.X == 55) k2 = 1; // если координата по X равна 55, то переключаем движение
                    if (enemy2.Location.X == 550) k2 = 0; // если координата по X равна 550, то переключаем движение

                    if (enemy2.Location.X > 55 && k2 == 0) // если координата врага2 по X больше 55 и счётчик равен 0
                    {
                        enemy2.Location = new Point(enemy2.Location.X - 5, 15);  // то враг2 движется влево
                    }
                    if (enemy2.Location.X < 550 && k2 == 1) // если координата врага2 по X больше 55 и счётчик равен 1
                    {
                        enemy2.Location = new Point(enemy2.Location.X + 5, 15);  // то враг2 движется вправо
                    }
                }
            }
            t3++; // счётчик увеличивается
        }
        private void h_bullet_Tick(object sender, EventArgs e)
        {
            if (t1 % 2 == 0 || t1 % 2 == 1) bullet.Location = new Point(bullet.Location.X, bullet.Location.Y - 6); // если число четное или нечетное, то пуля движется вверх

            for (int j = 0; j <= 50; j++) // счётчик
            {
                for (int i = 0; i < 40; i++) // счётчик
                {
                    if ((bullet.Location.X == enemy1.Location.X + j) && (bullet.Location.Y == enemy1.Location.Y + i)) // если координаты пули совпадают с координатами врага1
                    {
                        Controls.Remove(enemy1); // враг удаляется с формы
                        Controls.Remove(bullet); // пуля удаляется с формы
                        es = 0; // счётчик обнуляется
                        b = 1; // счётчик пуль равен 1
                        break; // ломаем счётчик
                    }
                    if ((bullet.Location.X == enemy2.Location.X + j) && (bullet.Location.Y == enemy2.Location.Y + i)) // если координаты пули совпадают с координатами врага2
                    {
                        Controls.Remove(enemy2); // враг удаляется с формы
                        Controls.Remove(bullet); // пуля удаляется с формы
                        es1 = 0; // счётчик обнуляется
                        b = 1;// счётчик пуль равен 1
                        break;  // ломаем счётчик
                    }
                }
                if (b == 1) break;  // если пуля одна, то ломаем счётчик
            }
            e_spawn1(); // генерируем врага1
            e_spawn2(); // генерируем врага2
            if (bullet.Location.Y < 0) // если пуля за пределами формы, то
            {
                Controls.Remove(bullet); // удаляем ее
                b = 1; // увеличиваем количество пуль
            }
            t1++; // увеливаем счётчик для таймера
        }
        public void lost()
        {
            if (kheart == -2) // если сердец нет, то
            {
                timer1.Stop(); // таймер1 останавливается
                c = 0; // счётчик обнуляется
                bullets_e.Stop(); // таймер для пуль врага останавливается
                e_movements.Stop(); // таймер для движения врагов останавливается
                h_bullet.Stop(); // таймер для движения пули космолёта останавливается
                MessageBox.Show("Вы проиграли. Счёт: " + death.ToString()); // выводим сообщение
                {
                    Application.Restart(); // перезапускаем игру
                }
            }
        }
    }
}


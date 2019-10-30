using System;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _objs;
        public static void Load()
        {
            _objs = new BaseObject[50];
            Random rnd = new Random();
            _objs[0] = new Moon(new Point(50, 100), new Point(0, 0), new Size(5, 5));
            for (int i = 11; i < _objs.Length-1; i++)
                _objs[i] = new Star(new Point(rnd.Next(1, 800), rnd.Next(1, 800)), new Point(2, 0), new Size(5, 5));
            _objs[_objs.Length - 1] = new Moon(new Point(50, 100), new Point(0, 0), new Size(5, 5));
            for (int i = 1; i < 11; i++)
                _objs[i] = new BaseObject(new Point(600, rnd.Next(1, 800)), new Point(15 + i, 15 + i), new Size(20, 20));

        }

        static Game()
        {
        }
        public static void Init(Form form)
        {
            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Draw()
        {
            // Проверяем вывод графики
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }

    }
}

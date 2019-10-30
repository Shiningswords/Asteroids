//
using System;
using System.Drawing;

namespace Asteroids
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
        private Image img = Image.FromFile(@"Images\Meteorite.png");

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        virtual public void Draw()
        {
            Game.Buffer.Graphics.DrawImage(img, Pos);
        }
        virtual public void Update()
        {
            Pos.X = Pos.X - Dir.X;
            // Pos.Y = Pos.Y + Dir.Y;
            if(Pos.X <= 0) Pos.X = Game.Width;
            //if (Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }

    class Star: BaseObject
    {
        
        public Star() : base(new Point(0, 0), new Point(0, 0), new Size(0, 0))
        {
        }

        public Star( Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X <= 0) Pos.X = Game.Width;



        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X , Pos.Y , Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }
    }

    class Moon : BaseObject
    {
        private Image img = Image.FromFile(@"Images\moon.png");

        public Moon() : base(new Point(0, 0), new Point(0, 0), new Size(0, 0))
        {
        }

        public Moon(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public override void Update()
        {
            Pos.X = Pos.X;
            Pos.Y = Pos.Y;
        }

        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(img, Pos);
        }
    }
}

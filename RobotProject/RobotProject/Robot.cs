using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public class Robot
    {
        public float x, y;  //координаты робота
        public float w, h;  //размеры робота
        public float a;     //угол в радианах
        public float speed, rot_speed; //скорость движения и поворота робота
        public float a1;    //ускорение движения робота
        public float a2;    //ускорение поворота руля робота
        public float a_steer;   //угол руления робота

        public List<Sensor> sensors = new List<Sensor>();   //дальномеры

        public Robot()      //конструктор
        {
            x = 50; y = 70;
            w = 100; h = 70;
            a = 1;
            speed = 0;      //пикс в секунду
            rot_speed = 0;  //радиан в секунду

            for (int i = -5; i <= 5; i++)
            {
                var s = new Sensor { a = i * 0.1f, x = 0, y = 0 };
                sensors.Add(s);
            }
        }

        public void Draw(Graphics g) //отрисовка
        {
            var t = g.Transform;
            g.TranslateTransform(x, y);
            g.RotateTransform(a * 180 / (float)Math.PI);
            g.DrawRectangle(Pens.Black, -h / 2, -w / 2, h, w);

            foreach (var s in sensors)
            {
                g.DrawLine(Pens.Violet,
                            s.x,
                            s.y,
                            s.x + s.maxDist * (float)Math.Cos(s.a),
                            s.y + s.maxDist * (float)Math.Sin(s.a)
                    );

                //new
                g.DrawLine(Pens.Red,
                            s.x,
                            s.y,
                            s.x + s.measuredDist * (float)Math.Cos(s.a),
                            s.y + s.measuredDist * (float)Math.Sin(s.a)
                    );
            }

            g.Transform = t;
        }

        public void Sim(float dt, World w) //симуляция
        {

            //new
            speed += a1 * dt;
            speed = Math.Sign(speed) * Math.Max(0, Math.Min(100, Math.Abs(speed)));

            a_steer += a2 * dt;
            a_steer = Math.Sign(a_steer) * Math.Max(0, Math.Min(1, Math.Abs(a_steer)));

            var _R = 2 * (float)Math.Sin(a_steer) / h;  //величина обратная радиусу окружности, по которой движется робот
            rot_speed = speed * _R;

            float s = (float)Math.Sin(a);
            float c = (float)Math.Cos(a);

            x += speed * c * dt;
            y += speed * s * dt;
            a += rot_speed * dt;

            //new
            foreach (var sens in sensors)
                sens.CheckDistance(w, this);
        }

        //new
        public string ShowSensors(string separator)
        {
            var s = string.Join(separator,
                                sensors.Select(x => x.measuredDist.ToString("F0", CultureInfo.InvariantCulture)));
            return s;
        }

        public void MoveToGoal(float x, float y)
        {
            var beta = a;
            var dx = x - this.x;
            var dy = y - this.y;
            var gamma = (float)Math.Atan2(dy, dx);

            var alpha = gamma - beta;    //угол направления на цель
            float pi = (float)Math.PI, pi2 = 2 * pi;
            while (alpha > pi) alpha -= pi2;
            while (alpha < -pi) alpha += pi2;

            if (alpha > 0) a_steer = 1; //управление поворотом руля
            else if (alpha < 0) a_steer = -1;
            else a_steer = 0;
            speed = 50;
        }
    }
}

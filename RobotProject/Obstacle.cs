using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public class Obstacle
    {
        private float _x;
        private float _y; //координаты
        private float _diameter; //размер
        public float X { get { return _x; } }
        public float Y { get { return _y; } }
        public float Diameter { get { return _diameter; } }

        public Obstacle(float x, float y, float diameter)
        {
            _x = x;
            _y = y;
            _diameter = diameter;
        }

        public void Draw(Graphics g) //отрисовка
        {   
            g.DrawEllipse(Pens.Blue, X - Diameter / 2, Y - Diameter / 2, Diameter, Diameter);
        }
    }
}

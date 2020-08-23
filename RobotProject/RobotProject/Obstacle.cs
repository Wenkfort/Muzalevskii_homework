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
        public float x, y; //координаты
        public float d; //размер

        public void Draw(Graphics g) //отрисовка
        {   g.DrawEllipse(Pens.Blue, x - d / 2, y - d / 2, d, d);
        }
    }
}

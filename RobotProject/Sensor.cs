using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public class Sensor
    {
        public float x, y, a;
        public float maxDist = 100;

        //new
        public float measuredDist;

        public float CheckDistance(World w, Robot r)
        {
            float step = 1;
            float s = (float)Math.Sin(a + r.a);
            float c = (float)Math.Cos(a + r.a);
            float x_ = x, y_ = y;           //промежуточные точки луча

            for (float i = 0; i < maxDist; i += step)
            {
                x_ += step * c;
                y_ += step * s;

                //new
                if (CheckPoint(r.x + x_, r.y + y_, w.obstacles))
                {
                    return measuredDist = (float)Math.Sqrt(x_ * x_ + y_ * y_);
                }
            }

            //new
            return measuredDist = maxDist;
        }

        private bool CheckPoint(float x_, float y_, List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                var o = obstacles[i];
                var dx = o.x - x_;
                var dy = o.y - y_;

                if ((float)Math.Sqrt(dx * dx + dy * dy) < o.d / 2)
                    return true;
            }
            return false;
        }
    }
}

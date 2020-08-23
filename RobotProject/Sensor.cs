using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public class Sensor
    {
        private float _x, _y, _angle;
        private float _maxDist = 100;

        public float X => this._x;     
        public float Y => this._y;
        public float Angle => this._angle;
        public float MaxDist => this._maxDist;

        public Sensor(float x, float y, float angle)
        {
            this._x = x;
            this._y = y;
            this._angle = angle;
        }

        //new
        public float measuredDist;

        public float CheckDistance(World world, Robot robot)
        {
            float step = 1;
            float s = (float)Math.Sin(_angle + robot.Angle);
            float c = (float)Math.Cos(_angle + robot.Angle);
            float xCurrent = _x, yCurrent = _y;           //промежуточные точки луча

            for (float i = 0; i < MaxDist; i += step)
            {
                xCurrent += step * c;
                yCurrent += step * s;

                //new
                if (CheckPoint(robot.X + xCurrent, robot.Y + yCurrent, world.obstacles))
                {
                    return measuredDist = (float)Math.Sqrt(xCurrent * xCurrent + yCurrent * yCurrent);
                }
            }

            //new
            return measuredDist = MaxDist;
        }

        private bool CheckPoint(float x_, float y_, List<Obstacle> obstacles)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                var dx = obstacles[i].X - x_;
                var dy = obstacles[i].Y - y_;

                if ((float)Math.Sqrt(dx * dx + dy * dy) < obstacles[i].Diameter / 2)
                    return true;
            }
            return false;
        }
    }
}

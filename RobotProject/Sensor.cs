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

        public float X { get => this._x; }
        public float Y { get => this._y; }
        public float Angle { get => this._angle; }
        public float MaxDist { get => this._maxDist; }

        public Sensor(float x, float y, float angle)
        {
            this._x = x;
            this._y = y;
            this._angle = angle;
        }

        //new
        public float measuredDist;

        public float CheckDistance(StaticMap map, Robot robot)
        {
            float step = 1;
            float sin = (float)Math.Sin(_angle + robot.Angle);
            float cos = (float)Math.Cos(_angle + robot.Angle);
            float xCurrent = _x, yCurrent = _y;           //промежуточные точки луча

            for (float i = 0; i < MaxDist; i += step)
            {
                xCurrent += step * cos;
                yCurrent += step * sin;

                if (map.IsCellOccupied(robot.X + xCurrent, robot.Y + yCurrent))
                {
                    return measuredDist = (float)Math.Sqrt(xCurrent * xCurrent + yCurrent * yCurrent);
                }
            }

            return measuredDist = MaxDist;
        }
    }
}

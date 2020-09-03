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
        public bool goalRiched = false;
        private StaticMap _map;
        public int id = -1;
        private Goal _goal;                    
        private float _x;
        private float _y;  //координаты робота
        private float _width = 25;
        private float _height = 50;  //размеры робота
        private float _angle;     //угол в радианах
        private float _speed = 0;
        private float _rotSpeed = 0; //скорость движения и поворота робота, [pix/s]
        private float _acc;    //ускорение движения робота
        private float _steeringWheelRotAcc = 0.14f;    //ускорение поворота руля робота
        private float _steeringWheelAngle;   //угол руления робота
        private const float _maxSpeed = 100;
        private const float _maxSteeringWheelAngleAbs = 1;

        public List<Sensor> sensors = new List<Sensor>();   //дальномеры

        public float Angle { get {return _angle; } } 
        public float X { get => _x; }
        public float Y { get => _y; }
        public float Rot_speed { get => _rotSpeed; }
        public float Acc { get => _acc; set => _acc = value; }
        public Goal Goal { get => _goal; 
            set
            {
                _goal = value;
                goalRiched = false;
            }
        }

        public Robot(float x, float y, float angle, int id, ref StaticMap map)
        {
            _x = x;
            _y = y;
            _angle = angle;
            _map = map;
            this.id = id;

            for (int i = -5; i <= 5; i++)
            {
                sensors.Add(new Sensor(0, 0, (float)i * 0.1f));
            }
        }

        public void Draw(Graphics g) //отрисовка
        {   
            var t = g.Transform;
            g.TranslateTransform(_x, _y);
            g.RotateTransform(_angle * 180 / (float)Math.PI);
            g.DrawRectangle(Pens.Black, -_height / 2, -_width / 2, _height, _width);

            foreach (var sensor in sensors)
            {
                g.DrawLine(Pens.Violet,
                            sensor.X,
                            sensor.Y,
                            sensor.X + sensor.MaxDist * (float)Math.Cos(sensor.Angle),
                            sensor.Y + sensor.MaxDist * (float)Math.Sin(sensor.Angle)
                    );

                //new
                g.DrawLine(Pens.Red,
                            sensor.X,
                            sensor.Y,
                            sensor.X + sensor.measuredDist * (float)Math.Cos(sensor.Angle),
                            sensor.Y + sensor.measuredDist * (float)Math.Sin(sensor.Angle)
                    );
            }

            g.Transform = t;
        }

        public bool MoveToGoal(float dt) //симуляция
        {
            float dist_to_goal = CommonMethods.dist_between_points(Goal.X, Goal.Y, X, Y);
            if (dist_to_goal < 10 && !goalRiched)
            {
                goalRiched = true;
                return true;
            }

            //new
            _speed += Acc * dt;
            _speed = Math.Sign(_speed) * Math.Max(0, Math.Min(_maxSpeed, Math.Abs(_speed)));

            _steeringWheelAngle += _steeringWheelRotAcc * dt;
            _steeringWheelAngle = Math.Sign(_steeringWheelAngle) * Math.Max(0, Math.Min(_maxSteeringWheelAngleAbs, Math.Abs(_steeringWheelAngle)));

            _rotSpeed = _speed * 2 * (float)Math.Sin(_steeringWheelAngle) / _height;  

            _x += _speed * (float)Math.Cos(_angle) * dt;
            _y += _speed * (float)Math.Sin(_angle) * dt;
            _angle += Rot_speed * dt;

            //new
            float distance;
            foreach (var sensor in sensors)
                distance = sensor.CheckDistance(_map, this);
            Sim(dt);
            return false;
        }

        private void Sim(float dt)
        { 
            var gamma = (float)Math.Atan2(Goal.Y - Y, Goal.X - X);

            var alpha = gamma - _angle;    //угол направления на цель
            while (alpha > Math.PI) alpha -= 2 * (float)Math.PI;
            while (alpha < -Math.PI) alpha += 2 * (float)Math.PI;

            var obstacle_dir = GetObstacleDir();

            if (obstacle_dir != 0)
            {
                _steeringWheelAngle = Math.Sign(obstacle_dir) * _maxSteeringWheelAngleAbs;
            } else
            {
                if (alpha == 0)
                    _steeringWheelAngle = 0;
                else
                    _steeringWheelAngle = Math.Sign(alpha) * _maxSteeringWheelAngleAbs; //управление поворотом руля
                _speed = _maxSpeed / 2;
            }
            

            float pi = (float)Math.PI, pi2 = 2 * pi;
            while (alpha > pi) alpha -= pi2;
            while (alpha < -pi) alpha += pi2;
        }

        private float GetObstacleDir()
        {
            float s = 0;
            var c = sensors.Count;
            for (int i = 0; i < c; i++)
            {
                float sign = 0;
                if (i < c / 2) sign = -1;
                if (i > c / 2) sign = 1;
                s += sign * sensors[i].measuredDist / sensors[i].MaxDist;
            }
            return s / c;
        }
    }
}

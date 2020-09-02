﻿using System;
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
        private float _steeringWheelRotAcc;    //ускорение поворота руля робота
        private float _steeringWheelAngle;   //угол руления робота
        private const float _maxSpeed = 100;
        private const float _maxSteeringWheelAngleAbs = 1;

        public List<Sensor> sensors = new List<Sensor>();   //дальномеры

        public float Angle => _angle; 
        public float X => _x;
        public float Y => _y;
        public float Rot_speed => _rotSpeed;
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

        public void Sim(float dt) //симуляция
        {
            float dist_to_goal = CommonMethods.dist_between_points(Goal.X, Goal.Y, X, Y);
            if (dist_to_goal < 10)
            {
                goalRiched = true;
                return;
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
            MoveToGoal();
        }

        public void MoveToGoal()
        { 
            var gamma = (float)Math.Atan2(Goal.Y - Y, Goal.X - X);

            var alpha = gamma - _angle;    //угол направления на цель
            while (alpha > Math.PI) alpha -= 2 * (float)Math.PI;
            while (alpha < -Math.PI) alpha += 2 * (float)Math.PI;

            if (alpha == 0) 
                _steeringWheelAngle = 0;
            else
                _steeringWheelAngle = Math.Sign(alpha) * _maxSteeringWheelAngleAbs; //управление поворотом руля
            _speed = _maxSpeed / 2;
        }
    }
}

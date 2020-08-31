using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public class World  //класс со всеми объектами виртуальной среды
    {
        public Robot robot; //робот
        private List<Robot> robots = new List<Robot>();
        private List<PointF> goalPoints = new List<PointF>();
        private Map map = new Map();
        private PointF _priorityPoint = new PointF(0, 0);                    

        public PointF PriorityPoint
        {
            get => _priorityPoint;
            set
            {
                // TODO: реализовать алгоритм аукциона
                foreach (var robot in robots)
                    robot.Goal = value;
                _priorityPoint  = value;
            }
        }

        public World()
        {

        }

        public void clear_robots()
        {
            robots.Clear();
        }

        public void clear_obstacles()
        {
            map.clear_obstacles();
        }

        public void clear_goal_points()
        {
            goalPoints.Clear();
        }

        public void add_robot(float x, float y, float angle)
        {
            robots.Add(new Robot(x, y, angle, ref map));
        }

        public void add_goalPoints(float x, float y)
        {
            goalPoints.Add(new PointF(x, y));
        }

        public void add_obstacle(float x, float y, float diameter)
        {
            map.set_obstacle(x, y, diameter);
        }

        public void Draw(Graphics g)
        {
            map.Draw(g);
            g.FillEllipse(Brushes.Violet, PriorityPoint.X, PriorityPoint.Y, 5, 5);    //отрисовка приоритетной точки
            foreach (var robot in robots)
            {
                robot.Draw(g);
            }
            foreach (var goal in goalPoints)
            {
                g.FillEllipse(Brushes.Red, goal.X, goal.Y, 5, 5);    //отрисовка целевых точек
            }
        }

        public void Sim(float dt)
        {
            foreach (var robot in robots)
            {
                if (robot != null)
                    robot.Sim(dt);
            }
        }

    }
}

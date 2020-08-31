using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotProject
{

    public class World  //класс со всеми объектами виртуальной среды
    {
        public Robot robot; //робот
        private StaticMap staticMap;
        private List<Robot> robots = new List<Robot>();
        private List<PointF> goalPoints = new List<PointF>();
        private List<double> VScore = new List<double>();
        private PointF _priorityPoint = new PointF(0, 0);

        public World(ref StaticMap staticMap)
        {
            this.staticMap = staticMap;
        }

        public PointF PriorityPoint
        {
            get => _priorityPoint;
            set
            {
                _priorityPoint = value;
            }
        }

        public void set_robots(List<Robot> robots)
        {
            this.robots = robots;
        }

        public void set_goalPoints(List<PointF> goalPoints)
        {
            this.goalPoints = goalPoints;
        }

        public void Draw(Graphics g)
        {
            staticMap.Draw(g);
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
                robot.Sim(dt);
            }
        }

    }
}

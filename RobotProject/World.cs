using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public class World  //класс со всеми объектами виртуальной среды
    {
        public Robot robot; //робот
        public List<Obstacle> obstacles = new List<Obstacle>(); //список препятствий

        public World()
        {
            robot = new Robot(50, 50, 0, 50, 100);

            obstacles.Add(new Obstacle(50, 80, 50));
            obstacles.Add(new Obstacle(150, 110, 60));
            obstacles.Add(new Obstacle(90, 150, 40));
        }

        public void Draw(Graphics g)
        {
            robot.Draw(g);
            foreach (var obstacle in obstacles) obstacle.Draw(g);
        }

        public void Sim(float dt)
        {
            robot.Sim(dt, this);
        }
    }
}

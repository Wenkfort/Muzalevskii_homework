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
        public Robot r; //робот
        public List<Obstacle> obstacles = new List<Obstacle>(); //список препятствий

        public World()
        {
            r = new Robot() { x = 50, y = 50, a = 0, w = 50, h = 100 };

            obstacles.Add(new Obstacle { x = 50, y = 80, d = 50 });
            obstacles.Add(new Obstacle { x = 150, y = 110, d = 60 });
            obstacles.Add(new Obstacle { x = 90, y = 150, d = 40 });
        }

        public void Draw(Graphics g)
        {
            r.Draw(g);
            foreach (var o in obstacles) o.Draw(g);
        }

        public void Sim(float dt)
        {
            r.Sim(dt, this);
        }
    }
}

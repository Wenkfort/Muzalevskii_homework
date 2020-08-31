using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public class StaticMap
    {
        public StaticMap() { }
        
        private List<Obstacle> obstacles = new List<Obstacle>();            //список препятствий

        public void set_obstacles(List<Obstacle> obstacles)
        {
            this.obstacles = obstacles;
        }

        public bool IsCellOccupied(float x_, float y_)
        {
            for (int i = 0; i < obstacles.Count; i++)
            {
                if (obstacles[i] == null)
                    continue;

                var dx = obstacles[i].X - x_;
                var dy = obstacles[i].Y - y_;

                if ((float)Math.Sqrt(dx * dx + dy * dy) < obstacles[i].Diameter / 2)
                    return true;
            }
            return false;
        }

        public void Draw(Graphics g)
        {
            foreach (var obstacle in obstacles)
            {
                obstacle.Draw(g);
            }
        }
    }
}

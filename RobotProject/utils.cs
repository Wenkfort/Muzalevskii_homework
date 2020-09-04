using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotProject
{
    public struct Goal
    {
        public float X;
        public float Y;
        public int Id;
        public float Vscore;
        // goal.status = "not_ansigned", "riched"
        public string status;
    }

    class CommonMethods
    {
        public static float dist_between_points(float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}

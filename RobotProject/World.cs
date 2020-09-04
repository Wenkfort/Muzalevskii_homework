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
    /**
     * World - represent the scene and contains all objects
     */
    public class World  
    {
        private RichTextBox logTextBox;
        private StaticMap staticMap;            
        private List<Robot> robots = new List<Robot>();
        private List<Goal> goalPoints = new List<Goal>();
        private PointF _priorityPoint;

        /**
         * params:
         *      staticMap - map with static obstacles
         *      logTextBox - text window for debug information and auction results output
         */
        public World(ref StaticMap staticMap, RichTextBox logTextBox)
        {
            this.staticMap = staticMap;
            this.logTextBox = logTextBox;
        }

        public PointF PriorityPoint
        {
            get
            {
                return _priorityPoint;
            }
            set
            {
                _priorityPoint = value;
                AuctionTargets();
            }
        }

        private void UpdateVScores()
        {
            for (int i = 0; i < goalPoints.Count; i++)
            {
                var goal = goalPoints[i];

                goal.Vscore = CommonMethods.dist_between_points(goal.X, goal.Y, PriorityPoint.X, PriorityPoint.Y);
                goalPoints[i] = goal;
            }
        }

        private float[,] CalculateCscores()
        {
            float[, ] CScores = new float[robots.Count, goalPoints.Count];
            for (int robot_id = 0; robot_id < robots.Count; robot_id++)
                for (int goal_id = 0; goal_id < goalPoints.Count; goal_id++)
                    CScores[robot_id, goal_id] = CommonMethods.dist_between_points(goalPoints[goal_id].X, goalPoints[goal_id].Y, robots[robot_id].X, robots[robot_id].Y);
            return CScores;
        }

        private void AuctionTargets()
        {
            UpdateVScores();
            float[,] CScores = CalculateCscores();

            List<int> notAnsignedGoalIds = new List<int>();
            List<int> notAnsignedRobotsIds = new List<int>();

            // adding only relevant goalPoints, that haven`t already been reached
            foreach (var goal in goalPoints)
                if (goal.status != "riched")
                    notAnsignedGoalIds.Add(goal.Id);

            // if all points have already been reached, end auction
            if (notAnsignedGoalIds.Count == 0)
                return;

            logTextBox.Text += "\nAuction:";

            // adding all robots to auction
            foreach (var robot in robots)
                notAnsignedRobotsIds.Add(robot.id);

            int notAnsignedGoalIdsCount = notAnsignedGoalIds.Count;
            for (int i = 0; i < Math.Min(robots.Count, notAnsignedGoalIdsCount); i++)
            {
                int MostPriorityGoalId = -1;
                float VscoreMax = float.MaxValue;
                foreach (var goalId in notAnsignedGoalIds)
                {
                    if (goalPoints[goalId].Vscore < VscoreMax)
                    {
                        MostPriorityGoalId = goalId;
                        VscoreMax = goalPoints[goalId].Vscore;
                    }
                }

                float NearestRobotDist = float.MaxValue;
                int NearestRobotId = -1;
                foreach (var robotId in notAnsignedRobotsIds)
                {
                    if (CScores[robotId, MostPriorityGoalId] < NearestRobotDist)
                    {
                        NearestRobotDist = CScores[robotId, MostPriorityGoalId];
                        NearestRobotId = robotId;
                    }
                }

                // we have found a point with the highest priority and the nearest robot to this point
                SetRobotGoal(NearestRobotId, MostPriorityGoalId);

                // previously mentioned point and robot are excluded from auction
                for (int k = 0; k < notAnsignedGoalIds.Count; k++)
                    if (notAnsignedGoalIds[k] == MostPriorityGoalId)
                        notAnsignedGoalIds.RemoveAt(k);

                for (int k = 0; k < notAnsignedRobotsIds.Count; k++)
                    if (notAnsignedRobotsIds[k] == NearestRobotId)
                        notAnsignedRobotsIds.RemoveAt(k);
            }
        }

        public void SetRobotGoal(int robot_id, int goal_id)
        {
            logTextBox.Text += "\nrobot_id: " + robot_id.ToString() + " -> goal_id: " + goal_id.ToString();
            robots[robot_id].Goal = goalPoints[goal_id];
        }

        public void SetRobots(List<Robot> robots)
        {
            this.robots = robots;
        }

        public void SetGoalPoints(List<Goal> goalPoints)
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
                Font font = new Font("Microsoft Sans Serif", 7F, FontStyle.Bold, GraphicsUnit.Point);
                g.DrawString(robot.id.ToString(), font, Brushes.Violet, robot.X, robot.Y);
            }
            foreach (var goal in goalPoints)
            {
                Brush color = Brushes.Red;
                if (goal.status == "riched")
                    color = Brushes.Green;
                g.FillEllipse(color, goal.X, goal.Y, 5, 5);    //отрисовка целевых точек
                Font font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold, GraphicsUnit.Point);
                g.DrawString(goal.Id.ToString(), font, Brushes.Red, goal.X + 2, goal.Y + 2);
            }
        }

        public void Sim(float dt)
        {
            foreach (var robot in robots)
                if (robot.ReachGoal(dt))
                {
                    Goal goal = goalPoints[robot.Goal.Id];
                    goal.status = "riched";
                    goalPoints[robot.Goal.Id] = goal;
                    AuctionTargets();
                }
        }
    }
}

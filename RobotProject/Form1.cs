using System;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RobotProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int MaxGoalsNumber = 10;
        int MaxRobotNumber = 10;
        World world;
        Graphics g;             //графический контекст

        private void Form1_Load(object sender, EventArgs e)
        {
            pb.Image = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(pb.Image);

            world = new World();
            init_scene();
            world.Draw(g);  //отрисовка мира
        }

        private void init_scene()
        {
            RobotsTable.Rows.Add();
            RobotsTable.Rows[0].Cells[0].Value = 50;
            RobotsTable.Rows[0].Cells[1].Value = 50;
            RobotsTable.Rows[0].Cells[2].Value = 0;
            RobotsTable.Rows[1].Cells[0].Value = 50;
            RobotsTable.Rows[1].Cells[1].Value = 150;
            RobotsTable.Rows[1].Cells[2].Value = 0;

            GoalsTable.Rows.Add();
            GoalsTable.Rows[0].Cells[0].Value = 200;
            GoalsTable.Rows[0].Cells[1].Value = 200;
            GoalsTable.Rows[1].Cells[0].Value = 300;
            GoalsTable.Rows[1].Cells[1].Value = 200;

            obstaclesTable.Rows.Add();
            obstaclesTable.Rows[0].Cells[0].Value = 150;
            obstaclesTable.Rows[0].Cells[1].Value = 350;
            obstaclesTable.Rows[0].Cells[2].Value = 10;
            obstaclesTable.Rows[1].Cells[0].Value = 350;
            obstaclesTable.Rows[1].Cells[1].Value = 150;
            obstaclesTable.Rows[1].Cells[2].Value = 15;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cb_pause.Checked) return;

            var dt = timer1.Interval / 1000f;
            g.Clear(Color.White);

            world.Sim(dt);
            world.Draw(g);

            pb.Refresh();
        }

        private void start_simulation(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void SetPriorityPoint(object sender, MouseEventArgs e)
        {
            var p = ((MouseEventArgs)e).Location;
            world.PriorityPoint = new PointF(p.X, p.Y);
        }

        private void GoalsTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (GoalsTable.Rows.Count <= MaxGoalsNumber)
            {
                GoalsTable.AllowUserToAddRows = true;
            }
            else
            {
                GoalsTable.AllowUserToAddRows = false;
            }
        }

        private void RobotsTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (RobotsTable.Rows.Count <= MaxRobotNumber)
            {
                RobotsTable.AllowUserToAddRows = true;
            }
            else
            {
                RobotsTable.AllowUserToAddRows = false;
            }
        }

        private void set_robots_Click(object sender, EventArgs e)
        {
            world.clear_robots();
            List<int> remove_rows_with_id = new List<int>();
            for (int i = 0; i < RobotsTable.Rows.Count; i++)
            {
                if (RobotsTable.Rows[i].Cells[0].Value == null || RobotsTable.Rows[i].Cells[1].Value == null || RobotsTable.Rows[i].Cells[2].Value == null)
                    continue;
                try
                {
                    float x = float.Parse(RobotsTable.Rows[i].Cells[0].Value.ToString());
                    float y = float.Parse(RobotsTable.Rows[i].Cells[1].Value.ToString());
                    float angle = float.Parse(RobotsTable.Rows[i].Cells[2].Value.ToString());
                    world.add_robot(x, y, angle);
                }
                catch
                {
                    remove_rows_with_id.Add(i);
                }
                
            }
            foreach (var i in remove_rows_with_id)
                RobotsTable.Rows.RemoveAt(i);

            g.Clear(Color.White);
            world.Draw(g);
            pb.Refresh();
        }

        private void set_goals_Click(object sender, EventArgs e)
        {
            world.clear_goal_points();
            List<int> remove_rows_with_id = new List<int>();
            for (int i = 0; i < GoalsTable.Rows.Count; i++)
            {
                if (GoalsTable.Rows[i].Cells[0].Value == null || GoalsTable.Rows[i].Cells[1].Value == null)
                    continue;
                try
                {
                    float x = float.Parse(GoalsTable.Rows[i].Cells[0].Value.ToString());
                    float y = float.Parse(GoalsTable.Rows[i].Cells[1].Value.ToString());
                    world.add_goalPoints(x, y);
                }
                catch
                {
                    remove_rows_with_id.Add(i);
                }

            }
            foreach (var i in remove_rows_with_id)
                GoalsTable.Rows.RemoveAt(i);

            g.Clear(Color.White);
            world.Draw(g);
            pb.Refresh();
        }

        private void set_obstacles_Click(object sender, EventArgs e)
        {
            world.clear_obstacles();
            List<int> remove_rows_with_id = new List<int>();
            for (int i = 0; i < obstaclesTable.Rows.Count; i++)
            {
                if (obstaclesTable.Rows[i].Cells[0].Value == null || obstaclesTable.Rows[i].Cells[1].Value == null || obstaclesTable.Rows[i].Cells[2].Value == null)
                    continue;
                try
                {
                    float x = float.Parse(obstaclesTable.Rows[i].Cells[0].Value.ToString());
                    float y = float.Parse(obstaclesTable.Rows[i].Cells[1].Value.ToString());
                    float r = float.Parse(obstaclesTable.Rows[i].Cells[2].Value.ToString());
                    world.add_obstacle(x, y, 2 * r);
                }
                catch
                {
                    remove_rows_with_id.Add(i);
                }

            }
            foreach (var i in remove_rows_with_id)
                obstaclesTable.Rows.RemoveAt(i);

            g.Clear(Color.White);
            world.Draw(g);
            pb.Refresh();
        }
    }
}

﻿using System;
using System.Drawing;
using System.Globalization;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

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
        StaticMap static_map = new StaticMap();

        private void Form1_Load(object sender, EventArgs e)
        {
            pb.Image = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(pb.Image);

            world = new World(ref static_map, logTextBox);
            init_scene();
            world.PriorityPoint = new PointF(pb.Width / 2, pb.Height / 2);
            update_picture();
        }

        private void init_scene()
        {
            RobotsTable.Rows.Add();
            RobotsTable.Rows.Add();
            RobotsTable.Rows[0].Cells[0].Value = 50;
            RobotsTable.Rows[0].Cells[1].Value = 50;
            RobotsTable.Rows[0].Cells[2].Value = 0;
            RobotsTable.Rows[1].Cells[0].Value = 50;
            RobotsTable.Rows[1].Cells[1].Value = 150;
            RobotsTable.Rows[1].Cells[2].Value = 0;
            RobotsTable.Rows[2].Cells[0].Value = 50;
            RobotsTable.Rows[2].Cells[1].Value = 100;
            RobotsTable.Rows[2].Cells[2].Value = 0;

            GoalsTable.Rows.Add();
            GoalsTable.Rows.Add();
            GoalsTable.Rows[0].Cells[0].Value = 200;
            GoalsTable.Rows[0].Cells[1].Value = 200;
            GoalsTable.Rows[1].Cells[0].Value = 300;
            GoalsTable.Rows[1].Cells[1].Value = 200;
            GoalsTable.Rows[2].Cells[0].Value = 100;
            GoalsTable.Rows[2].Cells[1].Value = 200;

            obstaclesTable.Rows.Add();
            obstaclesTable.Rows[0].Cells[0].Value = 150;
            obstaclesTable.Rows[0].Cells[1].Value = 150;
            obstaclesTable.Rows[0].Cells[2].Value = 10;
            obstaclesTable.Rows[1].Cells[0].Value = 350;
            obstaclesTable.Rows[1].Cells[1].Value = 150;
            obstaclesTable.Rows[1].Cells[2].Value = 15;

            set_robots_();
            set_obstacles_();
            set_goals_();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cb_pause.Checked) return;

            var dt = timer1.Interval / 1000f;

            world.Sim(dt);
            update_picture();
        }

        private void update_picture()
        {
            g.Clear(Color.White);
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
            update_picture();
        }

        private void GoalsTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (GoalsTable.Rows.Count <= MaxGoalsNumber)
                GoalsTable.AllowUserToAddRows = true;
            else
                GoalsTable.AllowUserToAddRows = false;
        }

        private void RobotsTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (RobotsTable.Rows.Count <= MaxRobotNumber)
                RobotsTable.AllowUserToAddRows = true;
            else
                RobotsTable.AllowUserToAddRows = false;
        }
        private void set_robots_Click(object sender, EventArgs e)
        {
            set_robots_();
        }

        private void set_robots_()
        {
            int robot_id = 0;
            List<Robot> robots = new List<Robot>();
            List<int> remove_rows_with_id = new List<int>();
            for (int i = 0; i < RobotsTable.Rows.Count; i++)
            {
                bool correct_data = true;

                List<float> coords = new List<float>();
                for (int j = 0; j < 3; j++)
                {
                    if (RobotsTable.Rows[i].Cells[j].Value == null)
                    {
                        RobotsTable.Rows[i].Cells[j].Value = "error";
                        correct_data = false;
                    }
                    try
                    {
                        coords.Add(float.Parse(RobotsTable.Rows[i].Cells[j].Value.ToString()));
                    }
                    catch
                    {
                        RobotsTable.Rows[i].Cells[j].Value = "error";
                        correct_data = false;
                    }
                }

                if (!correct_data)
                    continue;

                robots.Add(new Robot(coords[0], coords[1], coords[2], robot_id, ref static_map));
                robot_id++;
            }

            world.set_robots(robots);
            update_picture();
        }

        private void set_goals_Click(object sender, EventArgs e)
        {
            set_goals_();
        }

        private void set_goals_()
        {
            int goal_id = 0;
            List<Goal> goalPoints = new List<Goal>();
            List<int> remove_rows_with_id = new List<int>();
            for (int i = 0; i < GoalsTable.Rows.Count; i++)
            {
                bool correct_data = true;
                List<float> coords = new List<float>();
                for (int j = 0; j < 2; j++)
                {
                    if (GoalsTable.Rows[i].Cells[j].Value == null)
                    {
                        correct_data = false;
                        GoalsTable.Rows[i].Cells[j].Value = "error";
                    }
                    try
                    {
                        coords.Add(float.Parse(GoalsTable.Rows[i].Cells[j].Value.ToString()));
                    }
                    catch
                    {
                        GoalsTable.Rows[i].Cells[j].Value = "error";
                        correct_data = false;
                    }
                }

                if (!correct_data)
                    continue;

                Goal goal = new Goal();
                goal.X = coords[0];
                goal.Y = coords[1];
                goal.id = goal_id;
                goal.status = "not_ansigned";
                goalPoints.Add(goal);
                goal_id++;
            }

            world.set_goalPoints(goalPoints);
            update_picture();
        }

        private void set_obstacles_Click(object sender, EventArgs e)
        {
            set_obstacles_();
        }

        private void set_obstacles_()
        {
            List<Obstacle> obstacles = new List<Obstacle>();
            List<int> remove_rows_with_id = new List<int>();
            for (int i = 0; i < obstaclesTable.Rows.Count; i++)
            {
                bool correct_data = true;
                List<float> coords = new List<float>();
                for (int j = 0; j < 3; j++)
                {
                    if (obstaclesTable.Rows[i].Cells[j].Value == null)
                    {
                        obstaclesTable.Rows[i].Cells[j].Value = "error";
                        correct_data = false;
                    }
                    try
                    {
                        coords.Add(float.Parse(obstaclesTable.Rows[i].Cells[j].Value.ToString()));
                    }
                    catch
                    {
                        obstaclesTable.Rows[i].Cells[j].Value = "error";
                        correct_data = false;
                    }
                }

                if (!correct_data)
                    continue;
                obstacles.Add(new Obstacle(coords[0], coords[1], 2 * coords[2]));
            }

            static_map.set_obstacles(obstacles);
            update_picture();
        }

        private void stopSim_Click(object sender, EventArgs e)
        {
            set_obstacles_();
            set_robots_();
            set_goals_();
            world.PriorityPoint = world.PriorityPoint;
            timer1.Enabled = false;
        }
    }
}

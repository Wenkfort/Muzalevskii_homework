using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace RobotProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        World world;
        Graphics g;//графический контекст
        PointF goal; //целевая точка для робота (задается щелчком мыши) 

        private void Form1_Load(object sender, EventArgs e)
        {
            pb.Image = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(pb.Image);

            world = new World();

            timer1.Enabled = true;
        }

        float time = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cb_pause.Checked) return;

            var dt = timer1.Interval / 1000f;
            g.Clear(Color.Yellow);

            world.Sim(dt);  //расчет мира
            world.Draw(g);  //отрисовка мира

            g.FillEllipse(Brushes.Violet, goal.X, goal.Y, 5, 5);    //отрисовка целевой точки

            pb.Refresh();

            //пример управления
            //world.r.rot_speed = (float)Math.Sin(5*time);

            time += dt;

            var state = string.Format(CultureInfo.InvariantCulture, "{0} {1}", world.r.speed, world.r.rot_speed);

            if (state != last_state) rtb_log.Text += state + "\r\n";

            tb_xya.Text = string.Format(CultureInfo.InvariantCulture, "{0:F0}, {1:F1}, {2:F2}",
                                                                      world.r.x, world.r.y, world.r.a);
            rtb_sensors.Text = world.r.ShowSensors("; ");

            last_state = state;

            world.r.MoveToGoal(goal.X, goal.Y); //движение робота к цели

            //запись обучающего примера в датасет
            var sample = string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\r\n", world.r.x, world.r.y, world.r.a,
                                                                         goal.X, goal.Y, world.r.a_steer);
            if (sample != last_sample)
                rtb_dataset.Text += sample;
            last_sample = sample;
        }

        string last_sample = "";
        string last_state = "";
        string keys = "";

        //new
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) keys = TryAppend(keys, "w"); //world.r.a1 = 50;
            if (e.KeyCode == Keys.S) keys = TryAppend(keys, "s"); //world.r.a1 = -50;
            if (e.KeyCode == Keys.A) keys = TryAppend(keys, "a"); //world.r.a_steer = -1;
            if (e.KeyCode == Keys.D) keys = TryAppend(keys, "d"); //world.r.a_steer = 1;
            ProcessKeys();
        }

        //new
        public string TryAppend(string s, string s2)
        {
            if (!s.Contains(s2)) return s + s2;
            return s;
        }

        //new
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) keys = keys.Replace("w", "");
            if (e.KeyCode == Keys.S) keys = keys.Replace("s", "");
            if (e.KeyCode == Keys.A) keys = keys.Replace("a", "");
            if (e.KeyCode == Keys.D) keys = keys.Replace("d", "");
            ProcessKeys();
        }

        //new
        public void ProcessKeys()
        {
            world.r.a1 = 0;
            world.r.a2 = 0;
            if (keys.Contains("w")) world.r.a1 += 100;
            if (keys.Contains("s")) world.r.a1 -= 100;
            if (keys.Contains("a")) world.r.a2 -= 4;
            if (keys.Contains("d")) world.r.a2 += 4;
        }

        private void Pb_DoubleClick(object sender, EventArgs e)
        {
            var p = ((MouseEventArgs)e).Location;
            goal = new PointF(p.X, p.Y);
        }
    }
}

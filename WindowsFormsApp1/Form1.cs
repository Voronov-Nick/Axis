using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{//
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    


        private double _NSpeed;
        private double _Xspeed;
        private double _t;
        private double _ygol;
        private double _Yspeed;
        private double _x;
        private double _y;
        private const double DT = 0.1;
        private const double G = 9.81;
        private const double K = 0.1;


        private void axis2_Load(object sender, EventArgs e)
        {
            axis1.Axis_Type = 3;
            axis1.x_Base = 200;
            axis1.y_Base = 200;
            axis1.Pix_Size = (float)0.001;
            axis1.AxisDraw();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _t += DT;
            _x = _Xspeed * _t;
            _y = -_Yspeed * _t - G * _t * _t / 4;
            if (checkBox1.Checked)
            {
                _Xspeed -= DT * DT * K * _Xspeed * _Xspeed;
                _Yspeed += G * DT * DT;
            }
            if (_y <= 0)
            {
                timer1.Stop();
                _x = 0;
                _y = 0;
                _t = 0;
            }
            axis1.PixDraw((float)_x, (float)_y, Color.Blue, 0);
            axis1.StatToPic();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var vse = _ygol * Math.PI / 180;
            double.TryParse(textBox1.Text, out _NSpeed);
            double.TryParse(textBox2.Text, out _ygol);
            _Xspeed = (_NSpeed * Math.Cos(vse));
            _Yspeed = (_NSpeed * Math.Sin(-vse));
            timer1.Start();
        }
    }
}
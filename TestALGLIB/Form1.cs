using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestALGLIB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("V:" + Math.Round(1.5));
            Console.WriteLine("V:" + Math.Round(2.5));

            for (int i = 0; i < 6; i++)
            {
                double vv = -3.5 + i;

                double rv1 = Math.Round(vv);
                double rv2 = Math.Round(vv, MidpointRounding.AwayFromZero);
                double rv3 = Math.Round(vv * 2, MidpointRounding.AwayFromZero) / 2;
                Console.WriteLine("V:" + vv + "  RV1:" + rv1 + " RV2:" + rv2 + " RV3:" + rv3);
            }






            double[] x = new double[] { 0.0, 0.5, 1.0 };
            double[] y = new double[] { 0.0, 1.0 };
            double[] f = new double[] { 0.00, 0.25, 1.00, 2.00, 2.25, 3.00 };
            double vx = 0.25 * 10;
            double vy = 0.50 * 7;
            double v;
            double dx;
            double dy;
            double dxy;
            alglib.spline2dinterpolant s;

            for (int i = 0; i < 3; i++) x[i] = x[i] * 10;
            for (int i = 0; i < 2; i++) y[i] = y[i] * 7;
            // build spline
            alglib.spline2dbuildbicubicv(x, 3, y, 2, f, 1, out s);

            // calculate S(0.25,0.50)
            v = alglib.spline2dcalc(s, vx, vy);
            System.Console.WriteLine("{0:F4}", v); // EXPECTED: 1.0625

            // calculate derivatives
            alglib.spline2ddiff(s, vx, vy, out v, out dx, out dy, out dxy);
            System.Console.WriteLine("{0:F4}", v); // EXPECTED: 1.0625
            System.Console.WriteLine("{0:F4}", dx); // EXPECTED: 0.5000
            System.Console.WriteLine("{0:F4}", dy); // EXPECTED: 2.0000
            System.Console.ReadLine();

        }
    }
}

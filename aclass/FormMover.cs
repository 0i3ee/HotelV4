using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HotelV4.aclass
{
    public static class FormMover
    {
        private static bool dragging = false;
        private static Point dragCursorPoint;
        private static Point dragFormPoint;

        public static void Moveform(Form form)
        {
            form.MouseDown += new MouseEventHandler(Form_MouseDown);
            form.MouseMove += new MouseEventHandler(Form_MouseMove);
            form.MouseUp += new MouseEventHandler(Form_MouseUp);
        }

        private static void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = ((Form)sender).Location;
            }
        }

        private static void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                ((Form)sender).Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private static void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = false;
            }
        }
    }
}

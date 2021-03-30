using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {       
        //Begin section: Global veriables
        int width = 700;                    //main pictureBox widht
        int height = 450;                   //main pictureBox height
        Point p1 = new Point(50, 225);      //start curve point location
        Point pn = new Point(650, 225);     //end curve point location

        bool visiblePolyline = true;
        bool visibleControlPoints = true;

        bool movingPoint = false;
        int indexOfMovingPoint;
        int typeOfMovingPoint;

        bool movingImage = true;
        bool rotatingImage = false;

        bool naiveRotation = true;
        bool filterRotation = false;

        double currnetAngle = 2.0;

        int basicWidth = 60;
        int basicHeight = 60;

        int diagonalWidth = 86;
        int diagonalHeight = 86;

        Bitmap tmp;

        Thread t = null;
        Bitmap image;
        List<Point> curvePoints;
        ControlPoint[] controlPoints;
        Point imageLocation = new Point(50, 225);
        int currentImageLocation = 0;
        //End section: Global veriables

        public Form1()
        {
            InitializeComponent();
            PrepareSettings();
            PredefinePolyline();
        }

        private void PrepareSettings()
        {
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            //main pictureBox
            mainPictureBox.Width = this.width;
            mainPictureBox.Height = this.height;

            //numericUpDown
            numericUpDown.Minimum = 2;
            numericUpDown.Maximum = 50;
            numericUpDown.Value = 6;
            numericUpDown.TextAlign = HorizontalAlignment.Center;

            //visiblePolyline
            checkBoxPolylineVisible.Checked = true;
            radioButtonPolyline.Checked = true;

            //Image
            PrepareImage();

            //Radiobuttons
            radioButtonCurveAnimation.Checked = true;
            radioButtonNaiveRotating.Checked = true;
        }

        private void PrepareImage()
        {
            string path = @"Images/image1.png";
            Image image = Image.FromFile(path);
            this.image = new Bitmap(image, new Size(basicWidth, basicHeight));

            pictureBoxImageView.Image = this.image;

            pictureBoxImage.Image = this.image;
            pictureBoxImage.Size = new Size(basicWidth, basicHeight);
            pictureBoxImage.Visible = false;

            tmp = new Bitmap(pictureBoxImageView.Image, new Size(60, 60));
            pictureBoxTmp.Size = new Size(60, 60);
            pictureBoxTmp.Image = tmp;
        }

        private void PredefinePolyline()
        {
            GenerateStartPoints(6);
            mainPictureBox.Invalidate();
        }

        //Begin section: Interface's objects functions
        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            int l = (int)numericUpDown.Value;
            if (t != null)
                t.Abort();
            currentImageLocation = 0;
            pictureBoxImage.Visible = false;
            pictureBoxImage.Image = pictureBoxImageView.Image;
            pictureBoxImage.Size = new Size(basicWidth, basicHeight);
            GenerateStartPoints(l);
        }

        private void radioButtonPolyline_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPolylineVisible.Checked)
                visiblePolyline = radioButtonPolyline.Checked;
            mainPictureBox.Invalidate();
        }

        private void checkBoxPolylineVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPolylineVisible.Checked == false)
            {
                visibleControlPoints = false;
                visiblePolyline = false;
            }
            else
            {
                visibleControlPoints = true;
                visiblePolyline = radioButtonPolyline.Checked;
            }
            mainPictureBox.Invalidate();
        }


        private void radioButtonCurveAnimation_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCurveAnimation.Checked)
            {
                movingImage = true;
                rotatingImage = false;
            }
        }

        private void radioButtonRotatingAnimation_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonRotatingAnimation.Checked)
            {
                movingImage = false;
                rotatingImage = true;
            }

        }

        private void radioButtonNaiveRotating_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNaiveRotating.Checked)
            {
                naiveRotation = true;
                filterRotation = false;
            }
        }

        private void radioButtonFilteringRotating_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFilteringRotating.Checked)
            {
                naiveRotation = false;
                filterRotation = true;
            }
        }
        //End section: Interface's objects functions

        //Begin section: Mouse Click
        private void mainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                SearchPoint(e.Location);
        }

        private void SearchPoint(Point location)
        {
            for (int i = 0; i < controlPoints.Length; i++)
            {
                if (PointsDistance(controlPoints[i].point, location) < 3)
                {
                    AssignIndexAndType(i, 0);
                    return;
                }
                if (controlPoints[i].mode != 1 && PointsDistance(controlPoints[i].c1, location) < 3)
                {
                    AssignIndexAndType(i, 1);
                    return;
                }
                if (controlPoints[i].mode != 2 && PointsDistance(controlPoints[i].c2, location) < 3)
                {
                    AssignIndexAndType(i, 2);
                    return;
                }
            }
            movingPoint = false;
        }

        private double PointsDistance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private void AssignIndexAndType(int index, int type)
        {
            indexOfMovingPoint = index;
            typeOfMovingPoint = type;
            movingPoint = true;
        }

        private void mainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left || movingPoint == false)
                return;

            if (e.Location.X < 5 || e.Location.X > width - 5 || e.Location.Y < 5 || e.Location.Y > height - 5)
                return;

            int dx = e.Location.X - controlPoints[indexOfMovingPoint].point.X;
            int dy = e.Location.Y - controlPoints[indexOfMovingPoint].point.Y;

            if (typeOfMovingPoint == 0)
            {
                controlPoints[indexOfMovingPoint].point.X += dx;
                controlPoints[indexOfMovingPoint].point.Y += dy;

                if (controlPoints[indexOfMovingPoint].mode != 1)
                {
                    controlPoints[indexOfMovingPoint].c1.X += dx;
                    controlPoints[indexOfMovingPoint].c1.Y += dy;
                }

                if (controlPoints[indexOfMovingPoint].mode != 2)
                {
                    controlPoints[indexOfMovingPoint].c2.X += dx;
                    controlPoints[indexOfMovingPoint].c2.Y += dy;
                }
            }
            else if (typeOfMovingPoint == 1)
            {
                controlPoints[indexOfMovingPoint].c1 = e.Location;

                if (controlPoints[indexOfMovingPoint].mode != 2)
                {
                    controlPoints[indexOfMovingPoint].c2.X = controlPoints[indexOfMovingPoint].point.X - dx;
                    controlPoints[indexOfMovingPoint].c2.Y = controlPoints[indexOfMovingPoint].point.Y - dy;
                }
            }
            else if (typeOfMovingPoint == 2)
            {
                controlPoints[indexOfMovingPoint].c2 = e.Location;

                if (controlPoints[indexOfMovingPoint].mode != 1)
                {
                    controlPoints[indexOfMovingPoint].c1.X = controlPoints[indexOfMovingPoint].point.X - dx;
                    controlPoints[indexOfMovingPoint].c1.Y = controlPoints[indexOfMovingPoint].point.Y - dy;
                }
            }

            mainPictureBox.Invalidate();
        }
        //End section: Mouse Click

        //Begin section: Drawing functions
        private void mainPictureBox_Paint(object sender, PaintEventArgs e)
        {
            foreach (var p in controlPoints)
                p.Draw(e.Graphics, visibleControlPoints);

            if (visiblePolyline)
                DrawPolyline(e.Graphics);

            CalculateCurvePoints();
            DrawCurve(e.Graphics);

            pictureBoxImage.Location = new Point(curvePoints[currentImageLocation].X - pictureBoxImage.Size.Width / 2, curvePoints[currentImageLocation].Y - pictureBoxImage.Size.Height / 2);
        }

        private void DrawPolyline(Graphics graphics)
        {
            for (int i = 1; i < controlPoints.Length; i++)
            {
                graphics.DrawLine(Pens.Blue, controlPoints[i - 1].c2, controlPoints[i].c1);
            }
        }

        private void DrawCurve(Graphics graphics)
        {
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawLines(pen, curvePoints.ToArray());
            graphics.DrawLine(pen, curvePoints[curvePoints.Count - 1], controlPoints[controlPoints.Length - 1].point);
        }
        //End section: Drawing functions

        //Begin section: Calculative functions
        private void GenerateStartPoints(int l)
        {
            controlPoints = new ControlPoint[l];

            controlPoints[0] = new ControlPoint(p1.X, p1.Y, 1);
            controlPoints[l - 1] = new ControlPoint(pn.X, pn.Y, 2);

            int y1 = 50;
            int y2 = 400;
            int x = 50;
            int dx = (width - 100) / (l - 1);

            for (int i = 1; i < l - 1; i++)
            {
                x += dx;
                if (i % 2 == 0)
                    controlPoints[i] = new ControlPoint(x, y1, 0);
                else
                    controlPoints[i] = new ControlPoint(x, y2, 0);
            }
            this.mainPictureBox.Invalidate();
        }

        private void CalculateCurvePoints()
        {
            double dt = 0.05;
            List<Point> points = new List<Point>();
            for (int i = 0; i < controlPoints.Length - 1; i++)
            {
                double t = 0.0;
                while (t <= 1.0)
                {
                    double x = (1 - t) * (1 - t) * (1 - t) * controlPoints[i].point.X;
                    x += 3 * (1 - t) * (1 - t) * t * controlPoints[i].c2.X;
                    x += 3 * (1 - t) * t * t * controlPoints[i + 1].c1.X;
                    x += t * t * t * controlPoints[i + 1].point.X;

                    double y = (1 - t) * (1 - t) * (1 - t) * controlPoints[i].point.Y;
                    y += 3 * (1 - t) * (1 - t) * t * controlPoints[i].c2.Y;
                    y += 3 * (1 - t) * t * t * controlPoints[i + 1].c1.Y;
                    y += t * t * t * controlPoints[i + 1].point.Y;

                    Point p = new Point((int)x, (int)y);

                    points.Add(p);

                    t += dt;
                }
            }
            curvePoints = points;
        }
        //End section: Calculative functions

        //Begin section: Rotation and start/stop
        private void buttonSTART_Click(object sender, EventArgs e)
        {
            if (t != null) 
                t.Abort();
            pictureBoxImage.Visible = true;
            if (movingImage)
            {
                t = new Thread(new ThreadStart(MovingPicture));
                t.Start();
            }
            else if (rotatingImage)
            {
                pictureBoxImage.Size = new Size(diagonalWidth, diagonalHeight);
                if (naiveRotation)
                {
                    t = new Thread(new ThreadStart(NaiveRotation));
                    t.Start();
                }
                else if (filterRotation) 
                {
                    currnetAngle = 0.0;
                    pictureBoxTmp.Image = pictureBoxImageView.Image;
                    pictureBoxTmp.Size = new Size(60, 60);
                    t = new Thread(new ThreadStart(FilterRotation));
                    t.Start();
                }
            }
        }

        private void buttonSTOP_Click(object sender, EventArgs e)
        {
            t.Abort();
        }

        private void MovingPicture()
        {
            for (int i = currentImageLocation; i < curvePoints.Count; i++)
            {
                imageLocation = new Point(curvePoints[i].X - 30, curvePoints[i].Y - 30);
                mainPictureBox.Invalidate();
                currentImageLocation = i;
                Thread.Sleep(100);
            }
            for (int i = 0; i < currentImageLocation; i++)
            {
                imageLocation = new Point(curvePoints[i].X - 30, curvePoints[i].Y - 30);
                mainPictureBox.Invalidate();
                currentImageLocation = i;
                Thread.Sleep(100);
            }
            t = new Thread(new ThreadStart(MovingPicture));
            t.Start();
        }

        private void NaiveRotation()
        {
            int p = diagonalWidth / 2;
            Bitmap tmp = new Bitmap(diagonalWidth, diagonalHeight);
            for (int i = 13; i <= 72; i++)
            {
                for (int j = 13; j <= 72; j++)
                {
                    tmp.SetPixel(i, j, this.image.GetPixel(i - 13, j - 13));
                }
            }
            double angle;
            if (currnetAngle > 360.0)
            {
                angle = 2.0;
                currnetAngle = 2.0;
            }
            else
                angle = currnetAngle;
            double step = 2.0;
            while (angle <= 360.0)
            {
                Bitmap b = new Bitmap(diagonalWidth, diagonalHeight);
                for (int i = 0; i < b.Height; i++)
                {
                    for (int j = 0; j < b.Width; j++)
                    {
                        //convert coordinates
                        int x = j - p;
                        int y = i - p;

                        double a = angle;

                        double cos = Math.Cos(a * Math.PI / 180.0);
                        double sin = Math.Sin(a * Math.PI / 180.0);

                        //determinat basic matrix
                        double d = cos * cos + sin * sin;

                        //invertible matrix
                        double[,] tab = { { cos / d, sin / d }, { (-1.0) * sin / d, cos / d } };

                        double dx = x * tab[0, 0] + y * tab[0, 1];
                        double dy = x * tab[1, 0] + y * tab[1, 1];

                        int kx = (int)dx + p;
                        int ky = (int)dy + p;

                        if (kx >= 0 && kx <= diagonalWidth - 1 && ky >= 0 && ky <= diagonalHeight - 1) 
                            b.SetPixel(i, j, tmp.GetPixel(kx, ky));
                    }
                }
                pictureBoxImage.Image = b;
                angle += step;
                currnetAngle = angle;
                Thread.Sleep(20);
            }
            t = new Thread(new ThreadStart(NaiveRotation));
            t.Start();
        }

        private void XShear(double angle)
        {
            double shear = -1.0 * Math.Tan(-angle / 2 * Math.PI / 180.0);
            int maxII = (int)Math.Floor(shear * (tmp.Height - 1 + 0.5));
            Bitmap b = new Bitmap(tmp.Width + maxII, tmp.Height);
            for (int i = 0; i < b.Height; i++)
                for (int j = 0; j < b.Width; j++)
                    b.SetPixel(j, i, Color.White);
            for (int y = 0; y < tmp.Height; y++)
            {
                int ii = (int)Math.Floor(shear * (y + 0.5));
                double ff = Math.Floor(shear * (y + 0.5)) - ii;
                Color prev_left = Color.FromArgb(0, 0, 0);
                for (int x = 0; x < tmp.Width; x++)
                {
                    Color pixel = tmp.GetPixel(tmp.Width - 1 - x, y);
                    Color left = Color.FromArgb((int)(pixel.R * ff), (int)(pixel.G * ff), (int)(pixel.B * ff));

                    int R = pixel.R - left.R + prev_left.R;
                    int G = pixel.G - left.G + prev_left.G;
                    int B = pixel.B - left.B + prev_left.B;

                    pixel = Color.FromArgb(R, G, B);
                    prev_left = left;

                    b.SetPixel(tmp.Width - 1 - x + ii, y, pixel);
                }
                //b.SetPixel(ii, y, prev_left);     //powoduje czarna linie przy obracaniu
            }
            tmp = new Bitmap(b, b.Size);
        }

        private void YShear(double angle)
        {
            double shear = Math.Sin(-angle * Math.PI / 180.0);
            int maxII = (int)Math.Floor(shear * (tmp.Width - 1 + 0.5));
            Bitmap b = new Bitmap(tmp.Width, tmp.Height + Math.Abs(maxII));
            for (int i = 0; i < b.Height; i++)
                for (int j = 0; j < b.Width; j++)
                    b.SetPixel(j, i, Color.White);
            for (int x = 0; x < tmp.Width; x++)
            {
                int ii = (int)Math.Floor(shear * (x + 0.5));
                double ff = Math.Floor(shear * (x + 0.5)) - ii;
                Color prev_down = Color.FromArgb(0, 0, 0);
                for (int y = 0; y < tmp.Height; y++)
                {
                    Color pixel = tmp.GetPixel(x, tmp.Height - 1 - y);
                    Color down = Color.FromArgb((int)(pixel.R * ff), (int)(pixel.G * ff), (int)(pixel.B * ff));
                    int R = pixel.R - down.R + prev_down.R;
                    int G = pixel.G - down.G + prev_down.G;
                    int B = pixel.B - down.B + prev_down.B;

                    pixel = Color.FromArgb(R, G, B);
                    prev_down = down;

                    b.SetPixel(x, tmp.Height - 1 - y + ii + Math.Abs(maxII), pixel);
                }
                //b.SetPixel(x, ii + Math.Abs(maxII), prev_down);       //powoduje czarna linie przy obracaniu
            }
            tmp = new Bitmap(b, b.Size);
        }

        private void FilterRotation()
        {
            double angle = 2.0;
            double angleStep = 2.0;
            while (angle <= 90.0)
            {
                tmp = new Bitmap(pictureBoxTmp.Image, new Size(60, 60));
                XShear(angle);
                YShear(angle);
                XShear(angle);
                if (tmp.Width >= 86)
                {
                    int stepw = (tmp.Width - 86) / 2;
                    int steph = (tmp.Height - 86) / 2;
                    Bitmap b = new Bitmap(86, 86);
                    for (int i = 0; i < 86; i++)
                    {
                        for (int j = 0; j < 86; j++)
                        {
                            b.SetPixel(j, i, tmp.GetPixel(j + stepw, i + steph));
                        }
                    }
                    pictureBoxImage.Image = b;
                }
                else
                {
                    int stepw = (86 - tmp.Width) / 2;
                    int steph = (86 - tmp.Height) / 2;
                    Bitmap b = new Bitmap(86, 86);
                    for (int i = steph; i < 86 - steph - 1; i++)
                    {
                        for (int j = stepw; j < 86 - stepw - 1; j++)
                        {
                            b.SetPixel(j, i, tmp.GetPixel(j - stepw, i - steph));
                        }
                    }
                    pictureBoxImage.Image = b;
                }
                angle += angleStep;
                Thread.Sleep(1);
            }
            pictureBoxTmp.Image.RotateFlip(RotateFlipType.Rotate90FlipXY);
            t = new Thread(new ThreadStart(FilterRotation));
            t.Start();
        }
        //End section: Rotation and start/stop

        //Begin section: Load and Save
        private void buttonSave_Click(object sender, EventArgs e)
        {
            string path = @"Files";
            path = Path.GetFullPath(path);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Title = "Saving polyline";
            saveFileDialog1.Filter = "Txt files|*.txt";
            saveFileDialog1.InitialDirectory = path;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                sw.WriteLine("Project WK");
                int l = controlPoints.Length;
                sw.WriteLine($"{l}");
                sw.WriteLine($"{controlPoints[0].point.X},{controlPoints[0].point.Y},{controlPoints[0].c2.X},{controlPoints[0].c2.Y}");
                sw.WriteLine($"{controlPoints[l - 1].point.X},{controlPoints[l - 1].point.Y},{controlPoints[l - 1].c1.X},{controlPoints[l - 1].c1.Y}");
                for (int i = 1; i < l - 1; i++)
                {
                    ControlPoint cp = controlPoints[i];
                    sw.WriteLine($"{cp.point.X},{cp.point.Y},{cp.c1.X},{cp.c1.Y},{cp.c2.X},{cp.c2.Y}");
                }
                sw.Close();
                MessageBox.Show("Polyline saved successfully.");
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string path = @"Files";
            path = Path.GetFullPath(path);

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Loading";
            openFileDialog1.Filter = "Txt files|*.txt";
            openFileDialog1.InitialDirectory = path;
            openFileDialog1.ShowDialog();

            if (openFileDialog1.FileName != "")
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                String[] buf;

                buf = sr.ReadLine().Split(',');
                if (buf[0] != "Project WK")
                {
                    MessageBox.Show("Failed to load the polyline.");
                    return;
                }
                buf = sr.ReadLine().Split(',');
                int l = int.Parse(buf[0]);

                List<ControlPoint> controls = new List<ControlPoint>();
                ControlPoint start = new ControlPoint();
                ControlPoint end = new ControlPoint();
                Point p, c1, c2;

                //start point
                buf = sr.ReadLine().Split(',');
                p = new Point(int.Parse(buf[0]), int.Parse(buf[1]));
                c2 = new Point(int.Parse(buf[2]), int.Parse(buf[3]));
                start.point = p;
                start.c2 = c2;
                start.mode = 1;
                controls.Add(start);

                //end point
                buf = sr.ReadLine().Split(',');
                p = new Point(int.Parse(buf[0]), int.Parse(buf[1]));
                c1 = new Point(int.Parse(buf[2]), int.Parse(buf[3]));
                end.point = p;
                end.c1 = c1;
                end.mode = 2;

                //all points
                for (int i = 1; i < l - 1; i++)
                {
                    buf = sr.ReadLine().Split(',');
                    p = new Point(int.Parse(buf[0]), int.Parse(buf[1]));
                    c1 = new Point(int.Parse(buf[2]), int.Parse(buf[3]));
                    c2 = new Point(int.Parse(buf[4]), int.Parse(buf[5]));

                    ControlPoint cp = new ControlPoint();
                    cp.mode = 0;
                    cp.point = p;
                    cp.c1 = c1;
                    cp.c2 = c2;

                    controls.Add(cp);
                }
                sr.Close();
                controls.Add(end);
                controlPoints = controls.ToArray();
                numericUpDown.Value = l;
                currentImageLocation = 0;
                pictureBoxImage.Visible = false;
                pictureBoxImage.Image = pictureBoxImageView.Image;
                pictureBoxImage.Size = new Size(basicWidth, basicHeight);
                t = null;
                mainPictureBox.Invalidate();
            }

        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string path = @"Images";
            path = Path.GetFullPath(path);
            dialog.InitialDirectory = path;
            dialog.Filter = "Image files (*.jpg, *.png) | *.jpg; *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(dialog.FileName);
                image = new Bitmap(img, new Size(basicWidth, basicHeight));
                pictureBoxImageView.Image = image;
                pictureBoxImage.Image = image;
                pictureBoxImage.Size = new Size(60, 60);
            }
            mainPictureBox.Invalidate();
        }
        //End section: Load and Save

        //Begin section: Classes
        class ControlPoint
        {
            public Point point;
            public Point c1;
            public Point c2;
            public int mode;

            //mode 1 - start point, mode 2 - end point, mode 0 - normal point
            public ControlPoint(int x, int y, int mode)
            {
                this.point = new Point(x, y);
                this.mode = mode;

                if (mode != 1)
                    c1 = new Point(x - 15, y);

                if (mode != 2)
                    c2 = new Point(x + 15, y);
            }

            public ControlPoint() { }

            public void Draw(Graphics graphics, bool visibleControlPoints)
            {
                //main point
                graphics.DrawEllipse(Pens.Black, point.X - 3, point.Y - 3, 6, 6);
                graphics.FillEllipse(new SolidBrush(Color.Black), point.X - 3, point.Y - 3, 6, 6);

                //control points
                if (visibleControlPoints)
                {
                    if (mode != 1)
                    {
                        graphics.DrawLine(Pens.Blue, point, c1);
                        graphics.DrawRectangle(Pens.Blue, c1.X - 3, c1.Y - 3, 6, 6);
                        graphics.FillRectangle(new SolidBrush(Color.Blue), c1.X - 3, c1.Y - 3, 6, 6);
                    }

                    if (mode != 2)
                    {
                        graphics.DrawLine(Pens.Blue, point, c2);
                        graphics.DrawRectangle(Pens.Blue, c2.X - 3, c2.Y - 3, 6, 6);
                        graphics.FillRectangle(new SolidBrush(Color.Blue), c2.X - 3, c2.Y - 3, 6, 6);
                    }
                }
            }
        }
        //End section: Classes

        //Begin section: Lab part
        private Color hsv2rgb(double h, double s, double v)
        {
            double red = 0, grn = 0, blu = 0;
            double i, f, p, q, t;

            if (v == 0)
            {
                red = 0;
                grn = 0;
                blu = 0;
            }
            else
            {
                h /= 60;
                i = Math.Floor(h);
                f = h - i;
                p = v * (1 - s);
                q = v * (1 - (s * f));
                t = v * (1 - (s * (1 - f)));
                if (i == 0) { red = v; grn = t; blu = p; }
                else if (i == 1) { red = q; grn = v; blu = p; }
                else if (i == 2) { red = p; grn = v; blu = t; }
                else if (i == 3) { red = p; grn = q; blu = v; }
                else if (i == 4) { red = t; grn = p; blu = v; }
                else if (i == 5) { red = v; grn = p; blu = q; }
            }
            return Color.FromArgb((int)(red*255), (int)(grn*255), (int)(blu*255));
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(60, 60);
            for (int i = 0; i < 60; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    if (i < 3 || i > 56 || j < 3 || j > 56) 
                        b.SetPixel(j, i, Color.Black);
                    else
                        b.SetPixel(j, i, Color.White);
                }
            }

            List<Color> colors = new List<Color>();
            for (int h = 0; h <= 330; h += 30)
            {
                colors.Add(hsv2rgb(h, 1, 1));
            }

            List<Point> points = new List<Point>();
            points.Add(new Point(52, 29));
            points.Add(new Point(46, 22));
            points.Add(new Point(38, 17));
            points.Add(new Point(31, 14));
            points.Add(new Point(23, 17));
            points.Add(new Point(16, 22));
            points.Add(new Point(9, 29));
            points.Add(new Point(16, 36));
            points.Add(new Point(23, 41));
            points.Add(new Point(31, 44));
            points.Add(new Point(38, 41));
            points.Add(new Point(46, 36));

            for (int i = 0; i < points.Count; i++)
            {
                Point p = points[i];
                for (int s = -2; s <= 2; s++)
                {
                    for (int k = -2; k <= 2; k++)
                    {
                        if ((s == -2 && (k == -2 || k == 2)) || (s == 2 && (k == -2 || k == 2)))
                            b.SetPixel(p.X + s, p.Y + k, Color.White);
                        else
                            b.SetPixel(p.X + s, p.Y + k, colors[i]);
                    }
                }
            }

            pictureBoxImage.Image = b;
            pictureBoxImage.Size = new Size(60, 60);
            pictureBoxImageView.Image = b;
            this.image = b;
            mainPictureBox.Invalidate();
        }
        //End section: Lab part
    }
}

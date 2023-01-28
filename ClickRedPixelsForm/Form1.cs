using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickRedPixelsForm
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        private GlobalKeyboardHook _globalKeyboardHook;
        public Form1()
        {
            InitializeComponent();
            this.button2.Enabled = false;
            textBoxDistance_TextChanged(null, null);

            _globalKeyboardHook = new GlobalKeyboardHook();
            _globalKeyboardHook.KeyboardPressed += OnKeyPressed;
        }

        private void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            //Debug.WriteLine(e.KeyboardData.VirtualCode);

            Debug.WriteLine($"{e.KeyboardData.VirtualCode}: {e.KeyboardState}");
            if (e.KeyboardData.VirtualCode != 162)
                return;

            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                Debug.WriteLine($"Pannick stop");
                panicStop = true;
            }
        }

        private void Scan()
        {
            var screen = Screen.PrimaryScreen;
            var size = screen.Bounds;
            var dist = int.Parse(textBoxDistance.Text);
            var maxTargets = int.Parse(textBoxmaxTargets.Text);

            //Create a new bitmap.
            var progressImage = new DirectBitmap(this.pictureBoxProgress.Width, this.pictureBoxProgress.Height);
            var bmpScreenshot = new DirectBitmap(size.Width, size.Height);

            // Create a graphics object from the bitmap.
            var gfxScreenshot = Graphics.FromImage(bmpScreenshot.Bitmap);

            // Take the screenshot from the upper left corner to the right bottom corner.
            gfxScreenshot.CopyFromScreen(size.X,
                                        size.Y,
                                        0,
                                        0,
                                        size.Size,
                                        CopyPixelOperation.SourceCopy);

            points.Clear();
            var percXOld = 0;
            var percYOld = 0;
            var percXOld2 = 0;
            var percYOld2 = 0;

            for (var x = 0; x < size.Size.Width; x++)
            {
                if (points.Count > maxTargets)
                {
                    break;
                }

                for (var y = 0; y < size.Size.Height; y++)
                {
                    if (points.Count > maxTargets)
                    {
                        break;
                    }

                    var pixel = bmpScreenshot.GetPixel(x, y);
                    var isEnemy = false;
                    if (PixelIsEnemy(pixel))
                    {
                        var addX = 1;
                        var addY = 1;

                        while (PixelIsEnemy(bmpScreenshot.GetPixel(x + addX, y + addY)))
                        {
                            addX++;
                            addY++;
                        }

                        var pointJ = new Point(x + addX / 2, y + addY / 2);

                        var found = false;
                        foreach (var pointI in points)
                        {
                            var distance = GetDistance(pointI, pointJ);

                            if (distance > dist) continue;
                            found = true;
                            break;
                        }

                        if (!found)
                        {
                            isEnemy = true;
                            points.Add(pointJ);

                            ColorRect(x + addX / 2 - dist / 2, y + addY / 2 - dist / 2, Color.Red, dist / 2, dist / 2, size.Size, progressImage);
                            ColorRect(x, y, Color.Yellow, addX, addY, size.Size, progressImage);
                        }
                    }

                    var percX = (int)((float)x / (float)size.Size.Width * this.pictureBoxProgress.Width);
                    var percY = (int)((float)y / (float)size.Size.Height * this.pictureBoxProgress.Height);
                    if (percXOld != percX || percY != percYOld)
                    {
                        percXOld = percX;
                        percYOld = percY;

                        var mmX = Math.Min(percX, progressImage.Width - 1);
                        var mmY = Math.Min(percY, progressImage.Height - 1);
                        if (progressImage.GetPixel(mmX, mmY).A == 0)
                        {
                            progressImage.SetPixel(
                                mmX,
                                mmY,
                                isEnemy ? Color.Red : Color.GreenYellow
                            );
                        }

                        if ((percX % 10 == 0 && percX != percXOld2))
                        {
                            percXOld2 = percX;
                            percYOld2 = percY;
                            this.BeginInvoke(new Action(delegate
                            {
                                this.pictureBoxProgress.Image = progressImage.Bitmap;
                            }));
                        }
                    }
                }
            }

            gfxScreenshot.Dispose();
            bmpScreenshot.Dispose();

            var str = $"Amount of targets: {points.Count}/{maxTargets}";
            foreach (var point in points)
            {
                str += $"{point}\r\n";
            }

            this.Invoke(new Action(delegate
            {
                this.pictureBoxProgress.Image = progressImage.Bitmap;
                textBoxOutput.Text = str;
                this.button1.Enabled = true;
                this.button2.Enabled = true;
            }));
        }

        private static void ColorRect(int x, int y, Color col, int sizeX, int sizeY, Size scaleMin, DirectBitmap bitmap)
        {
            for (var x2 = 0; x2 < sizeX; x2++)
            {
                for (var y2 = 0; y2 < sizeY; y2++)
                {
                    var cordX = (int)((float)(x + x2) / (float)scaleMin.Width * bitmap.Width);
                    var cordY = (int)((float)(y + y2) / (float)scaleMin.Height * bitmap.Height);

                    var mmX = Math.Max(0, Math.Min(cordX, bitmap.Width - 1));
                    var mmY = Math.Max(0, Math.Min(cordY, bitmap.Height - 1));

                    if (bitmap.GetPixel(mmX, mmY).A == 0)
                    {
                        bitmap.SetPixel(mmX, mmY, col);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.button2.Enabled = false;
            new Thread(new ThreadStart(this.Scan)).Start();
        }

        private static bool PixelIsEnemy(Color col)
        {
            return col.R == 153 && col.G == 15 && col.B == 15;
        }

        private static double GetDistance(Point a, Point b)
        {
            return Math.Sqrt(Math.Pow((b.X - a.X), 2) + Math.Pow((b.Y - a.Y), 2));
        }

        private bool panicStop = false;
        private async void button2_Click(object sender, EventArgs e)
        {
            makeClickThread();
        }

        Thread _clicky;
        private void makeClickThread()
        {
            Enabled = false;
            panicStop = false;

            var screen = Screen.PrimaryScreen;
            var size = screen.Bounds;

            float fireRate;
            float turrets;
            if (!float.TryParse(textBoxFireRate.Text, out fireRate) || !float.TryParse(textBoxTurrets.Text, out turrets))
            {
                MessageBox.Show("invalid value for firerate or turrets");
                Enabled = true;
                return;
            }

            var delay = 1000.0f / fireRate / turrets * 0.9f;
            _clicky = new Thread(new ThreadStart(delegate
            {
                var i = 0;
                foreach (var p in points)
                {
                    if (panicStop)
                    {
                        Debug.WriteLine($"Pannick stop :(");
                        break;
                    }

                    Thread.Sleep(30);
                    MouseOperations.SetCursorPosition(p.X + size.X, p.Y + size.Y);
                    Thread.Sleep(30);
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
                    Thread.Sleep(30);
                    MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
                    Thread.Sleep(30);

                    if (i++ >= turrets) Thread.Sleep((int)delay);
                }

                BeginInvoke(new Action(delegate
                {
                    panicStop = false;
                    Enabled = true;
                    _clicky.Join();
                }));
            }));

            _clicky.Start();
        }

        private void textBoxDistance_TextChanged(object sender, EventArgs e)
        {
            var w = 0;
            if (!int.TryParse(textBoxDistance.Text, out w)) return;

            var bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (var x = 0; x < w && x < pictureBox1.Width; x++)
            {
                for (var y = 0; y < pictureBox1.Height; y++)
                {
                    bitmap.SetPixel(x, y, Color.Red);
                }
            }

            pictureBox1.Image = bitmap;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _globalKeyboardHook.Dispose();
        }
    }
}

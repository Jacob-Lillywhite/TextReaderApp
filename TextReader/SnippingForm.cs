using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Tesseract;

namespace TextReader
{
    public partial class SnippingForm : Form, ISnippingForm
    {
        private readonly TesseractEngine engine;

        int selectX;
        int selectY;
        int selectWidth;
        int selectHeight;
        public Pen selectPen;
        public Bitmap screenshot;
        public  string extractedText;

        bool start = false;

        public SnippingForm()
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string tessDataPath = Path.Combine(projectRoot, "TextReader", "tessdata");
            engine = new TesseractEngine(tessDataPath, "eng", EngineMode.Default);
            InitializeComponent();

            this.TopMost = true;
            this.BackColor = Color.Black;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.Manual;
            this.Top = 0;
            this.Left = 0;
        }

        public void SnippingForm_Load(object sender, EventArgs e)
        {
            this.Hide();

            Bitmap printScreen = new Bitmap(
                Screen.PrimaryScreen.Bounds.Width, 
                Screen.PrimaryScreen.Bounds.Height);

            Graphics graphics = Graphics.FromImage(printScreen);
            graphics.CopyFromScreen(0, 0, 0, 0, printScreen.Size);

            using (MemoryStream memoryStream = new MemoryStream()) 
            {
                printScreen.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
                picCapture.Size = new Size(this.Width, this.Height);

                picCapture.Image = Image.FromStream(memoryStream);
            }

            this.Show();
            Cursor = Cursors.Cross;
        }

        public void Capture_MouseDown(object sender, MouseEventArgs e)
        {
            if (!start)
            {
                if(e.Button == MouseButtons.Left)
                {
                    selectX = e.X;
                    selectY = e.Y;
                    selectPen = new Pen(Color.FromArgb(0, 120, 215), 5);
                    selectPen.DashStyle = DashStyle.DashDotDot;
                }
                start = true;
            }
        }

        public void Capture_MouseMove(object sender, MouseEventArgs e)
        {
            if(picCapture.Image == null) { return; }

            if(start)
            {
                picCapture.Refresh();
                selectWidth = e.X - selectX;
                selectHeight = e.Y - selectY;

                picCapture.CreateGraphics().SmoothingMode = SmoothingMode.AntiAlias;
                picCapture.CreateGraphics().DrawRectangle(selectPen, selectX, selectY, selectWidth, selectHeight);
            }
        }

        public void Capture_MouseUp(object sender, MouseEventArgs e)
        {
            if (picCapture.Image == null) { return; }

            start = false;
            SaveToClipBoard();
        }

        public void SaveToClipBoard()
        {
            if(selectWidth > 0)
            {
                Rectangle rectangle = new Rectangle(selectX, selectY, selectWidth, selectHeight);

                Bitmap OriginalImage = new Bitmap(picCapture.Image, picCapture.Width, picCapture.Height);
                Bitmap _img = new Bitmap(selectWidth, selectHeight);
                Graphics graphics = Graphics.FromImage(_img);

                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.DrawImage(OriginalImage, 0, 0, rectangle, GraphicsUnit.Pixel);

                using (Bitmap screenshot = new Bitmap(_img))
                using (Graphics g = Graphics.FromImage(_img))
                {
                    g.CopyFromScreen(this.Location, Point.Empty, this.Size);

                    using (Page page = engine.Process(screenshot))
                    {
                        extractedText = page.GetText();
                        extractedText = extractedText.Replace("\n", "\r\n")
                            .Replace("\r", "\r\n");
                        //    .Replace("@", "")
                        //    .Replace("!", ".")
                        //    .Replace("  ", " ")
                        //    .Replace("\\", " ");
                        //Regex regex = new Regex("[^a-zA-Z0-9,.'\"!? ]+");
                        //Regex regex2 = new Regex("(?:^| )[b-hj-z](?= |$)");
                        //extractedText = regex.Replace(extractedText, "");
                        //extractedText = regex2.Replace(extractedText, "");
                    }
                }

                if (extractedText?.Length == 0) { extractedText = " "; }
                Clipboard.SetText(extractedText);
            }
                this.Close();
        }
    }
}

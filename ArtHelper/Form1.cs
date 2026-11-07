using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using ArtHelper.Properties;

namespace ArtHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            outputDirectoryTextBox.Text = GetOutputDirectory();
            gradeCountNumericUpDown.Value = GetGradeCount();
        }

        private void chooseImageButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "JPEG images (*.jpg;*.jpeg)|*.jpg;*.jpeg|All files (*.*)|*.*";
                dialog.Title = "Choose an image";
                dialog.CheckFileExists = true;

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    string outputDirectory = outputDirectoryTextBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(outputDirectory))
                    {
                        outputDirectory = GetOutputDirectory();
                    }

                    Directory.CreateDirectory(outputDirectory);
                    Settings.Default.OutputDirectory = outputDirectory;
                    Settings.Default.GradeCount = (int)gradeCountNumericUpDown.Value;
                    Settings.Default.Save();

                    string gridPath;
                    string gradesPath;
                    ProcessImage(dialog.FileName, outputDirectory, (int)gradeCountNumericUpDown.Value,
                        out gridPath, out gradesPath);
                    selectedImageLabel.Text = dialog.FileName;
                    statusLabel.Text = "Created:\r\n" + gridPath + "\r\n" + gradesPath;
                }
                catch (Exception ex)
                {
                    statusLabel.Text = "The image could not be processed.";
                    MessageBox.Show(this, ex.Message, "Art Helper", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void browseOutputButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Choose where processed images will be saved";
                dialog.SelectedPath = GetOutputDirectory();

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    outputDirectoryTextBox.Text = dialog.SelectedPath;
                    Settings.Default.OutputDirectory = dialog.SelectedPath;
                    Settings.Default.Save();
                }
            }
        }

        private static string GetOutputDirectory()
        {
            if (!string.IsNullOrWhiteSpace(Settings.Default.OutputDirectory))
            {
                return Settings.Default.OutputDirectory;
            }

            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output");
        }

        private static decimal GetGradeCount()
        {
            return Math.Max(2, Math.Min(256, Settings.Default.GradeCount));
        }

        private static void ProcessImage(string inputPath, string outputDirectory, int gradeCount,
            out string gridPath, out string gradesPath)
        {
            string name = Path.GetFileNameWithoutExtension(inputPath);
            gridPath = Path.Combine(outputDirectory, name + "_grid.jpg");
            gradesPath = Path.Combine(outputDirectory, name + "_grades.jpg");

            using (var source = new Bitmap(inputPath))
            using (var canvas = CreateCanvas(source))
            using (var gridImage = new Bitmap(canvas))
            using (var gradesImage = CreateGradesImage(canvas, gradeCount))
            {
                DrawGrid(gridImage);
                gridImage.Save(gridPath, ImageFormat.Jpeg);
                gradesImage.Save(gradesPath, ImageFormat.Jpeg);
            }
        }

        private static Bitmap CreateCanvas(Image source)
        {
            const double targetRatio = 1.25;
            int width = source.Width;
            int height = source.Height;
            bool widthIsLonger = width >= height;
            double existingRatio = widthIsLonger
                ? (double)width / height
                : (double)height / width;

            if (existingRatio < targetRatio)
            {
                if (widthIsLonger)
                {
                    width = (int)Math.Ceiling(height * targetRatio);
                }
                else
                {
                    height = (int)Math.Ceiling(width * targetRatio);
                }
            }
            else if (existingRatio > targetRatio)
            {
                if (widthIsLonger)
                {
                    height = (int)Math.Ceiling(width / targetRatio);
                }
                else
                {
                    width = (int)Math.Ceiling(height / targetRatio);
                }
            }

            var canvas = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (Graphics graphics = Graphics.FromImage(canvas))
            {
                graphics.Clear(Color.White);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(source, new Rectangle((width - source.Width) / 2,
                    (height - source.Height) / 2, source.Width, source.Height));
            }

            return canvas;
        }

        private static void DrawGrid(Bitmap image)
        {
            bool widthIsLonger = image.Width >= image.Height;
            int longDivisionCount = 10;
            int shortDivisionCount = 8;
            int longSize = widthIsLonger ? image.Width : image.Height;
            int shortSize = widthIsLonger ? image.Height : image.Width;
            const float lineWidth = 1f;

            using (Graphics graphics = Graphics.FromImage(image))
            using (var pen = new Pen(Color.FromArgb(128, 128, 128), lineWidth))
            {
                graphics.SmoothingMode = SmoothingMode.None;
                for (int i = 1; i < longDivisionCount; i++)
                {
                    float position = i * longSize / (float)longDivisionCount;
                    if (widthIsLonger)
                    {
                        graphics.DrawLine(pen, position, 0, position, image.Height);
                    }
                    else
                    {
                        graphics.DrawLine(pen, 0, position, image.Width, position);
                    }
                }

                for (int i = 1; i < shortDivisionCount; i++)
                {
                    float position = i * shortSize / (float)shortDivisionCount;
                    if (widthIsLonger)
                    {
                        graphics.DrawLine(pen, 0, position, image.Width, position);
                    }
                    else
                    {
                        graphics.DrawLine(pen, position, 0, position, image.Height);
                    }
                }
            }
        }

        private static Bitmap CreateGradesImage(Bitmap source, int gradeCount)
        {
            var grades = new Bitmap(source.Width, source.Height, PixelFormat.Format24bppRgb);
            for (int y = 0; y < source.Height; y++)
            {
                for (int x = 0; x < source.Width; x++)
                {
                    Color pixel = source.GetPixel(x, y);
                    int luminance = (int)Math.Round((0.299 * pixel.R) + (0.587 * pixel.G) + (0.114 * pixel.B));
                    int grade = Math.Min(gradeCount - 1, luminance * gradeCount / 256);
                    int value = (int)Math.Round(grade * 255.0 / (gradeCount - 1));
                    grades.SetPixel(x, y, Color.FromArgb(value, value, value));
                }
            }

            return grades;
        }
    }
}

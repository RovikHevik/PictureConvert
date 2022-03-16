using PictureConvert.Logic;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace PictureConvert
{
    public partial class Main_Form : Form
    {

        private static Bitmap ImageWithCode;
        private static Bitmap MagicImage;
        private static Bitmap ResizedImage;
        private static Bitmap PaleteColor;
        private static Image preImage;
        private static readonly Thread resizedThread = new Thread(new ThreadStart(ResizeImage));
        private static readonly Thread magicThread = new Thread(new ThreadStart(MakesMagic));
        private static readonly Thread codeOnImageThread = new Thread(new ThreadStart(CodeImage));
        private static readonly int A4Height = 99;
        private static readonly int A4Width = 70;
        private static int ResImgHeight;
        private static int ResImgWidth;
        private static string Path;

        private static void ResizeImage()
        {
            preImage = Image.FromFile(Path, true);
            ResizedImage = ImageLogic.ResizeImage(preImage, ResImgWidth, ResImgHeight);
            magicThread.Start();
            codeOnImageThread.Start();
            resizedThread.Abort();
        }

        private static void CodeImage()
        {
            magicThread.Join();
            ImageWithCode = ImageLogic.ImageWithCode(ImageLogic.ResizeImage((Bitmap)MagicImage.Clone(), A4Width, A4Height));
            PaleteColor = ImageLogic.MakeColorPalete();
            codeOnImageThread.Abort();
        }

        private static void MakesMagic()
        {
            MagicImage = ImageLogic.MagicImage((Bitmap)ResizedImage.Clone());
            magicThread.Abort();
        }

        public Main_Form()
        {
            InitializeComponent();
            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(DragEnterForm);
            this.DragDrop += new DragEventHandler(DragDropForm);
        }

        void DragEnterForm(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            LabelInfo.Visible = true;
            StartMagic.Visible = false;
        }

        void DragDropForm(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Path = files[0];
            LabelInfo.Visible = false;
            StartMagic.Visible = true;
            StartMagic.PerformClick();
            StartMagic.Visible = false;
        }
        private void DragLeaveForm(object sender, EventArgs e)
        {
            LabelInfo.Visible = false;
            StartMagic.Visible = true;
        }

        private void StartMagic_Click(object sender, EventArgs e)
        {
            ResImgWidth = ResizedImg.Width;
            ResImgHeight = ResizedImg.Height;
            if(Path == null)
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    Path = openFile.FileName;
                    try
                    {
                        Preloader.Visible = true;
                        StartMagic.Visible = false;
                        resizedThread.Start();
                        kostil.Start();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("картинку выбери сука");
                }
            }
            else
            {
                try
                {
                    Preloader.Visible = true;
                    resizedThread.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void StopPreloader()
        {
            Preloader.Visible = false;
            ReadyMagic.Visible = true;
            ReadyPicture.Image = MagicImage;
            ResizedImg.Image = ResizedImage;
        }

        private void ReadyMagic_Click(object sender, EventArgs e)
        {
            if (saveReadyFile.ShowDialog() == DialogResult.OK)
            {
                ImageWithCode.Save(saveReadyFile.FileName, ImageFormat.Png);
                PaleteColor.Save(saveReadyFile.FileName.Replace(".png", "Colors.png"), ImageFormat.Png);
                MessageBox.Show("готово");
            }
            else
            {
                MessageBox.Show("путь выбери сука");
            }
        }

        private void Kostil_Tick(object sender, EventArgs e)
        {
            if(codeOnImageThread.ThreadState == ThreadState.Stopped)
            {
                StopPreloader();
                kostil.Stop();
            }
        }
    }
}

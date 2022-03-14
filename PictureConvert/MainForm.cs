using PictureConvert.Logic;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace PictureConvert
{
    public partial class Main_Form : Form
    {
        private int A4Width = 70*4;
        private int A4Height = 99*4;

        public Main_Form()
        {
            InitializeComponent();
        }

        private void StartMagic_Click(object sender, EventArgs e)
        {
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                string Path = openFile.FileName;
                try
                {
                    Image preImage = Image.FromFile(Path, true);          
                    ReadyPicture.Image = ImageLogic.MagicImage(ImageLogic.ResizeImage(preImage, A4Width, A4Height));
                    ResizedImg.Image = ImageLogic.ResizeImage(preImage, ResizedImg.Width, ResizedImg.Height);
                    chromaticImage.Image = ImageLogic.ImageWithCode(ImageLogic.MagicImage(ImageLogic.ResizeImage(preImage, A4Width/4, A4Height/4)));
                    StartMagic.Visible = false; 
                    ReadyMagic.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(Path);
                }
            }
            else
            {
                MessageBox.Show("картинку выбери сука");
            }
        }

        private void ReadyMagic_Click(object sender, EventArgs e)
        {
            if (saveReadyFile.ShowDialog() == DialogResult.OK)
            {
                string Path = saveReadyFile.FileName;
                chromaticImage.Image.Save(Path, ImageFormat.Png);
                MessageBox.Show("готово");
            }
            else
            {
                MessageBox.Show("путь выбери сука");
            }
        }
    }
}

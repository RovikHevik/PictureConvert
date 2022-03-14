namespace PictureConvert
{
    partial class Main_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReadyPicture = new System.Windows.Forms.PictureBox();
            this.StartMagic = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveReadyFile = new System.Windows.Forms.SaveFileDialog();
            this.ReadyMagic = new System.Windows.Forms.Button();
            this.ResizedImg = new System.Windows.Forms.PictureBox();
            this.chromaticImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ReadyPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chromaticImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadyPicture
            // 
            this.ReadyPicture.Location = new System.Drawing.Point(12, 12);
            this.ReadyPicture.Name = "ReadyPicture";
            this.ReadyPicture.Size = new System.Drawing.Size(280, 396);
            this.ReadyPicture.TabIndex = 0;
            this.ReadyPicture.TabStop = false;
            // 
            // StartMagic
            // 
            this.StartMagic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartMagic.Location = new System.Drawing.Point(1053, 376);
            this.StartMagic.Name = "StartMagic";
            this.StartMagic.Size = new System.Drawing.Size(124, 35);
            this.StartMagic.TabIndex = 1;
            this.StartMagic.Text = "Выбрать файл";
            this.StartMagic.UseVisualStyleBackColor = true;
            this.StartMagic.Click += new System.EventHandler(this.StartMagic_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            // 
            // ReadyMagic
            // 
            this.ReadyMagic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadyMagic.Location = new System.Drawing.Point(1053, 376);
            this.ReadyMagic.Name = "ReadyMagic";
            this.ReadyMagic.Size = new System.Drawing.Size(124, 35);
            this.ReadyMagic.TabIndex = 2;
            this.ReadyMagic.Text = "Сохранить";
            this.ReadyMagic.UseVisualStyleBackColor = true;
            this.ReadyMagic.Visible = false;
            this.ReadyMagic.Click += new System.EventHandler(this.ReadyMagic_Click);
            // 
            // ResizedImg
            // 
            this.ResizedImg.Location = new System.Drawing.Point(328, 13);
            this.ResizedImg.Name = "ResizedImg";
            this.ResizedImg.Size = new System.Drawing.Size(280, 396);
            this.ResizedImg.TabIndex = 3;
            this.ResizedImg.TabStop = false;
            // 
            // chromaticImage
            // 
            this.chromaticImage.Location = new System.Drawing.Point(644, 12);
            this.chromaticImage.Name = "chromaticImage";
            this.chromaticImage.Size = new System.Drawing.Size(280, 396);
            this.chromaticImage.TabIndex = 4;
            this.chromaticImage.TabStop = false;
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1189, 423);
            this.Controls.Add(this.chromaticImage);
            this.Controls.Add(this.ResizedImg);
            this.Controls.Add(this.ReadyMagic);
            this.Controls.Add(this.StartMagic);
            this.Controls.Add(this.ReadyPicture);
            this.MinimumSize = new System.Drawing.Size(792, 462);
            this.Name = "Main_Form";
            this.ShowIcon = false;
            this.Text = "Преобразование";
            ((System.ComponentModel.ISupportInitialize)(this.ReadyPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chromaticImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ReadyPicture;
        private System.Windows.Forms.Button StartMagic;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveReadyFile;
        private System.Windows.Forms.Button ReadyMagic;
        private System.Windows.Forms.PictureBox ResizedImg;
        private System.Windows.Forms.PictureBox chromaticImage;
    }
}


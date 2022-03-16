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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.ReadyPicture = new System.Windows.Forms.PictureBox();
            this.StartMagic = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.OpenFileDialog();
            this.saveReadyFile = new System.Windows.Forms.SaveFileDialog();
            this.ReadyMagic = new System.Windows.Forms.Button();
            this.ResizedImg = new System.Windows.Forms.PictureBox();
            this.Preloader = new System.Windows.Forms.PictureBox();
            this.kostil = new System.Windows.Forms.Timer(this.components);
            this.LabelInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ReadyPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizedImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preloader)).BeginInit();
            this.SuspendLayout();
            // 
            // ReadyPicture
            // 
            this.ReadyPicture.Location = new System.Drawing.Point(12, 128);
            this.ReadyPicture.Name = "ReadyPicture";
            this.ReadyPicture.Size = new System.Drawing.Size(280, 396);
            this.ReadyPicture.TabIndex = 0;
            this.ReadyPicture.TabStop = false;
            // 
            // StartMagic
            // 
            this.StartMagic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.StartMagic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("StartMagic.BackgroundImage")));
            this.StartMagic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.StartMagic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.StartMagic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartMagic.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.StartMagic.FlatAppearance.BorderSize = 0;
            this.StartMagic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.StartMagic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.StartMagic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartMagic.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartMagic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.StartMagic.Location = new System.Drawing.Point(0, 0);
            this.StartMagic.Name = "StartMagic";
            this.StartMagic.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartMagic.Size = new System.Drawing.Size(627, 604);
            this.StartMagic.TabIndex = 1;
            this.StartMagic.UseVisualStyleBackColor = false;
            this.StartMagic.Click += new System.EventHandler(this.StartMagic_Click);
            // 
            // openFile
            // 
            this.openFile.FileName = "openFileDialog1";
            this.openFile.Filter = "Files|*.jpg;*.jpeg;*.png;";
            // 
            // saveReadyFile
            // 
            this.saveReadyFile.DefaultExt = "png";
            // 
            // ReadyMagic
            // 
            this.ReadyMagic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReadyMagic.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ReadyMagic.BackgroundImage")));
            this.ReadyMagic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ReadyMagic.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            this.ReadyMagic.FlatAppearance.BorderSize = 0;
            this.ReadyMagic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReadyMagic.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReadyMagic.Location = new System.Drawing.Point(248, 557);
            this.ReadyMagic.Name = "ReadyMagic";
            this.ReadyMagic.Size = new System.Drawing.Size(124, 35);
            this.ReadyMagic.TabIndex = 2;
            this.ReadyMagic.UseVisualStyleBackColor = true;
            this.ReadyMagic.Visible = false;
            this.ReadyMagic.Click += new System.EventHandler(this.ReadyMagic_Click);
            // 
            // ResizedImg
            // 
            this.ResizedImg.Location = new System.Drawing.Point(335, 128);
            this.ResizedImg.Name = "ResizedImg";
            this.ResizedImg.Size = new System.Drawing.Size(280, 396);
            this.ResizedImg.TabIndex = 3;
            this.ResizedImg.TabStop = false;
            // 
            // Preloader
            // 
            this.Preloader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(45)))));
            this.Preloader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Preloader.Image = ((System.Drawing.Image)(resources.GetObject("Preloader.Image")));
            this.Preloader.Location = new System.Drawing.Point(0, 0);
            this.Preloader.Name = "Preloader";
            this.Preloader.Size = new System.Drawing.Size(627, 604);
            this.Preloader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Preloader.TabIndex = 5;
            this.Preloader.TabStop = false;
            this.Preloader.Visible = false;
            // 
            // kostil
            // 
            this.kostil.Enabled = true;
            this.kostil.Interval = 500;
            this.kostil.Tick += new System.EventHandler(this.Kostil_Tick);
            // 
            // LabelInfo
            // 
            this.LabelInfo.BackColor = System.Drawing.Color.Transparent;
            this.LabelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LabelInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LabelInfo.Font = new System.Drawing.Font("Calibri Light", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelInfo.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LabelInfo.Location = new System.Drawing.Point(0, 0);
            this.LabelInfo.Name = "LabelInfo";
            this.LabelInfo.Size = new System.Drawing.Size(627, 604);
            this.LabelInfo.TabIndex = 6;
            this.LabelInfo.Text = "Опустите файл";
            this.LabelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LabelInfo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(415, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "Оригинал";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(6, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 36);
            this.label2.TabIndex = 8;
            this.label2.Text = "Пример готового фото";

            // 
            // Main_Form
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(46)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(627, 604);
            this.Controls.Add(this.StartMagic);
            this.Controls.Add(this.LabelInfo);
            this.Controls.Add(this.Preloader);
            this.Controls.Add(this.ReadyPicture);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResizedImg);
            this.Controls.Add(this.ReadyMagic);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximumSize = new System.Drawing.Size(643, 643);
            this.MinimumSize = new System.Drawing.Size(643, 643);
            this.Name = "Main_Form";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Преобразование";
            this.DragLeave += new System.EventHandler(this.DragLeaveForm);
            ((System.ComponentModel.ISupportInitialize)(this.ReadyPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResizedImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Preloader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ReadyPicture;
        private System.Windows.Forms.Button StartMagic;
        private System.Windows.Forms.OpenFileDialog openFile;
        private System.Windows.Forms.SaveFileDialog saveReadyFile;
        private System.Windows.Forms.Button ReadyMagic;
        private System.Windows.Forms.PictureBox ResizedImg;
        private System.Windows.Forms.PictureBox Preloader;
        private System.Windows.Forms.Timer kostil;
        private System.Windows.Forms.Label LabelInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}


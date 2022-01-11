namespace Image_Crop_GUI
{
    partial class playmatch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(playmatch));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.undo_button = new System.Windows.Forms.Button();
            this.refresh_button = new System.Windows.Forms.Button();
            this.newverificationimage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.matchstatus = new System.Windows.Forms.Label();
            this.studregno = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.matchtxt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.passport = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.original_image_picture_box = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.uploadfingerprint = new System.Windows.Forms.Button();
            this.loading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newverificationimage)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.original_image_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox2.Location = new System.Drawing.Point(14, 131);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(262, 210);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 12);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(273, 20);
            this.textBox2.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.undo_button);
            this.panel2.Controls.Add(this.refresh_button);
            this.panel2.Location = new System.Drawing.Point(3, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(364, 342);
            this.panel2.TabIndex = 4;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Location = new System.Drawing.Point(12, 21);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(334, 239);
            this.panel4.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Size = new System.Drawing.Size(334, 239);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(129, 288);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 12;
            this.button1.Text = "Crop";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.cropimage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Resize Original FingerPrint";
            // 
            // undo_button
            // 
            this.undo_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.undo_button.BackColor = System.Drawing.Color.LightGray;
            this.undo_button.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.undo_button.Location = new System.Drawing.Point(20, 288);
            this.undo_button.Name = "undo_button";
            this.undo_button.Size = new System.Drawing.Size(100, 30);
            this.undo_button.TabIndex = 10;
            this.undo_button.Text = "Undo";
            this.undo_button.UseVisualStyleBackColor = false;
            this.undo_button.Click += new System.EventHandler(this.undo_button_Click);
            // 
            // refresh_button
            // 
            this.refresh_button.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.refresh_button.BackColor = System.Drawing.Color.LightGray;
            this.refresh_button.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.refresh_button.Location = new System.Drawing.Point(241, 288);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(100, 30);
            this.refresh_button.TabIndex = 11;
            this.refresh_button.Text = "Refresh";
            this.refresh_button.UseVisualStyleBackColor = false;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // newverificationimage
            // 
            this.newverificationimage.Location = new System.Drawing.Point(289, 131);
            this.newverificationimage.Name = "newverificationimage";
            this.newverificationimage.Size = new System.Drawing.Size(255, 209);
            this.newverificationimage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.newverificationimage.TabIndex = 1;
            this.newverificationimage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 523);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(3, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Polygon Points:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mouse Points:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(96, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(273, 20);
            this.textBox1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.loading);
            this.panel3.Controls.Add(this.uploadfingerprint);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.matchstatus);
            this.panel3.Controls.Add(this.studregno);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.matchtxt);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.passport);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.newverificationimage);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.original_image_picture_box);
            this.panel3.Location = new System.Drawing.Point(407, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(558, 408);
            this.panel3.TabIndex = 14;
            // 
            // matchstatus
            // 
            this.matchstatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.matchstatus.AutoSize = true;
            this.matchstatus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchstatus.ForeColor = System.Drawing.Color.Red;
            this.matchstatus.Location = new System.Drawing.Point(468, 37);
            this.matchstatus.Name = "matchstatus";
            this.matchstatus.Size = new System.Drawing.Size(48, 19);
            this.matchstatus.TabIndex = 20;
            this.matchstatus.Text = "Failed";
            // 
            // studregno
            // 
            this.studregno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.studregno.AutoSize = true;
            this.studregno.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studregno.Location = new System.Drawing.Point(123, 37);
            this.studregno.Name = "studregno";
            this.studregno.Size = new System.Drawing.Size(44, 19);
            this.studregno.TabIndex = 19;
            this.studregno.Text = "-------";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(121, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Reg No:";
            // 
            // matchtxt
            // 
            this.matchtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.matchtxt.AutoSize = true;
            this.matchtxt.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.matchtxt.ForeColor = System.Drawing.Color.Red;
            this.matchtxt.Location = new System.Drawing.Point(510, 8);
            this.matchtxt.Name = "matchtxt";
            this.matchtxt.Size = new System.Drawing.Size(17, 19);
            this.matchtxt.TabIndex = 16;
            this.matchtxt.Text = "0";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(414, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Match Score:";
            // 
            // passport
            // 
            this.passport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.passport.BackColor = System.Drawing.Color.White;
            this.passport.Location = new System.Drawing.Point(14, 8);
            this.passport.Name = "passport";
            this.passport.Size = new System.Drawing.Size(99, 85);
            this.passport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.passport.TabIndex = 15;
            this.passport.TabStop = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.LightGray;
            this.button3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.Location = new System.Drawing.Point(14, 354);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 30);
            this.button3.TabIndex = 14;
            this.button3.Text = "Match Again";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.runmatchagain);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(11, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Resized FingerPrint";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(286, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Verification FingerPrint";
            // 
            // original_image_picture_box
            // 
            this.original_image_picture_box.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.original_image_picture_box.Location = new System.Drawing.Point(289, 131);
            this.original_image_picture_box.Name = "original_image_picture_box";
            this.original_image_picture_box.Size = new System.Drawing.Size(255, 210);
            this.original_image_picture_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.original_image_picture_box.TabIndex = 12;
            this.original_image_picture_box.TabStop = false;
            this.original_image_picture_box.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(414, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "Result:";
            // 
            // uploadfingerprint
            // 
            this.uploadfingerprint.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.uploadfingerprint.BackColor = System.Drawing.Color.LightGray;
            this.uploadfingerprint.Enabled = false;
            this.uploadfingerprint.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.uploadfingerprint.Location = new System.Drawing.Point(444, 354);
            this.uploadfingerprint.Name = "uploadfingerprint";
            this.uploadfingerprint.Size = new System.Drawing.Size(100, 30);
            this.uploadfingerprint.TabIndex = 22;
            this.uploadfingerprint.Text = "Save";
            this.uploadfingerprint.UseVisualStyleBackColor = false;
            this.uploadfingerprint.Click += new System.EventHandler(this.uploadfingerprint_Click);
            // 
            // loading
            // 
            this.loading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loading.AutoSize = true;
            this.loading.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loading.ForeColor = System.Drawing.Color.Red;
            this.loading.Location = new System.Drawing.Point(457, 386);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(79, 15);
            this.loading.TabIndex = 23;
            this.loading.Text = "Please wait...";
            this.loading.Visible = false;
            // 
            // playmatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 456);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "playmatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FingerPrint Match";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Crop_page_FormClosing);
            this.Load += new System.EventHandler(this.playmatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newverificationimage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.original_image_picture_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.Button undo_button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox original_image_picture_box;
        private System.Windows.Forms.PictureBox newverificationimage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label matchtxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox passport;
        private System.Windows.Forms.Label studregno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label matchstatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button uploadfingerprint;
        private System.Windows.Forms.Label loading;
    }
}
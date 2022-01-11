
namespace Image_Crop_GUI
{
    partial class VerificationCapture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerificationCapture));
            this.preview_img = new System.Windows.Forms.PictureBox();
            this.init_image = new System.Windows.Forms.PictureBox();
            this.capture_title = new System.Windows.Forms.Label();
            this.save_btn = new System.Windows.Forms.Button();
            this.next_item = new System.Windows.Forms.PictureBox();
            this.previous_item = new System.Windows.Forms.PictureBox();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.regmaticno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.preview_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.init_image)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previous_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // preview_img
            // 
            this.preview_img.BackColor = System.Drawing.Color.White;
            this.preview_img.Location = new System.Drawing.Point(104, 99);
            this.preview_img.Name = "preview_img";
            this.preview_img.Size = new System.Drawing.Size(207, 251);
            this.preview_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.preview_img.TabIndex = 14;
            this.preview_img.TabStop = false;
            this.preview_img.Visible = false;
            // 
            // init_image
            // 
            this.init_image.BackColor = System.Drawing.Color.White;
            this.init_image.Image = ((System.Drawing.Image)(resources.GetObject("init_image.Image")));
            this.init_image.Location = new System.Drawing.Point(0, 463);
            this.init_image.Name = "init_image";
            this.init_image.Size = new System.Drawing.Size(29, 31);
            this.init_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.init_image.TabIndex = 23;
            this.init_image.TabStop = false;
            // 
            // capture_title
            // 
            this.capture_title.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capture_title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.capture_title.Location = new System.Drawing.Point(1, 74);
            this.capture_title.Name = "capture_title";
            this.capture_title.Size = new System.Drawing.Size(423, 23);
            this.capture_title.TabIndex = 22;
            this.capture_title.Text = "Capture Right Thumb";
            this.capture_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.RoyalBlue;
            this.save_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.save_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save_btn.Font = new System.Drawing.Font("Segoe UI Symbol", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.save_btn.ForeColor = System.Drawing.Color.White;
            this.save_btn.Location = new System.Drawing.Point(160, 395);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(86, 36);
            this.save_btn.TabIndex = 21;
            this.save_btn.Text = "✓ Capture";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Visible = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // next_item
            // 
            this.next_item.BackColor = System.Drawing.Color.Transparent;
            this.next_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next_item.Image = ((System.Drawing.Image)(resources.GetObject("next_item.Image")));
            this.next_item.Location = new System.Drawing.Point(328, 238);
            this.next_item.Name = "next_item";
            this.next_item.Size = new System.Drawing.Size(40, 39);
            this.next_item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.next_item.TabIndex = 20;
            this.next_item.TabStop = false;
            this.next_item.Visible = false;
            this.next_item.Click += new System.EventHandler(this.next_item_Click);
            // 
            // previous_item
            // 
            this.previous_item.BackColor = System.Drawing.Color.Transparent;
            this.previous_item.Cursor = System.Windows.Forms.Cursors.Hand;
            this.previous_item.Image = ((System.Drawing.Image)(resources.GetObject("previous_item.Image")));
            this.previous_item.Location = new System.Drawing.Point(40, 238);
            this.previous_item.Name = "previous_item";
            this.previous_item.Size = new System.Drawing.Size(40, 39);
            this.previous_item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previous_item.TabIndex = 19;
            this.previous_item.TabStop = false;
            this.previous_item.Visible = false;
            this.previous_item.Click += new System.EventHandler(this.previous_item_Click);
            // 
            // Picture
            // 
            this.Picture.BackColor = System.Drawing.Color.White;
            this.Picture.Image = ((System.Drawing.Image)(resources.GetObject("Picture.Image")));
            this.Picture.Location = new System.Drawing.Point(104, 99);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(207, 251);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Picture.TabIndex = 17;
            this.Picture.TabStop = false;
            // 
            // regmaticno
            // 
            this.regmaticno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regmaticno.Location = new System.Drawing.Point(104, 31);
            this.regmaticno.Name = "regmaticno";
            this.regmaticno.Size = new System.Drawing.Size(207, 29);
            this.regmaticno.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "Reg/Matric No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VerificationCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 431);
            this.Controls.Add(this.regmaticno);
            this.Controls.Add(this.preview_img);
            this.Controls.Add(this.init_image);
            this.Controls.Add(this.capture_title);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.next_item);
            this.Controls.Add(this.previous_item);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "VerificationCapture";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verification Capture";
            this.Load += new System.EventHandler(this.VerificationCapture_Load);
            ((System.ComponentModel.ISupportInitialize)(this.preview_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.init_image)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previous_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox preview_img;
        private System.Windows.Forms.PictureBox init_image;
        private System.Windows.Forms.Label capture_title;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.PictureBox next_item;
        private System.Windows.Forms.PictureBox previous_item;
        private System.Windows.Forms.PictureBox Picture;
        private System.Windows.Forms.TextBox regmaticno;
        private System.Windows.Forms.Label label1;
    }
}
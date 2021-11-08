
namespace app2
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.antrenareBtn = new System.Windows.Forms.Button();
            this.testareBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(47, 65);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 600);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // antrenareBtn
            // 
            this.antrenareBtn.Location = new System.Drawing.Point(811, 99);
            this.antrenareBtn.Name = "antrenareBtn";
            this.antrenareBtn.Size = new System.Drawing.Size(100, 40);
            this.antrenareBtn.TabIndex = 1;
            this.antrenareBtn.Text = "Antrenare";
            this.antrenareBtn.UseVisualStyleBackColor = true;
            this.antrenareBtn.Click += new System.EventHandler(this.antrenareBtn_Click);
            // 
            // testareBtn
            // 
            this.testareBtn.Location = new System.Drawing.Point(811, 179);
            this.testareBtn.Name = "testareBtn";
            this.testareBtn.Size = new System.Drawing.Size(100, 40);
            this.testareBtn.TabIndex = 2;
            this.testareBtn.Text = "Testare";
            this.testareBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 673);
            this.Controls.Add(this.testareBtn);
            this.Controls.Add(this.antrenareBtn);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button antrenareBtn;
        private System.Windows.Forms.Button testareBtn;
    }
}


namespace CPU
{
    partial class Error
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
            this.OKbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OKbtn
            // 
            this.OKbtn.BackColor = System.Drawing.Color.Transparent;
            this.OKbtn.FlatAppearance.BorderSize = 0;
            this.OKbtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.OKbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.OKbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKbtn.Font = new System.Drawing.Font("Binary ITC", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKbtn.ForeColor = System.Drawing.Color.White;
            this.OKbtn.Location = new System.Drawing.Point(433, 210);
            this.OKbtn.Name = "OKbtn";
            this.OKbtn.Size = new System.Drawing.Size(71, 37);
            this.OKbtn.TabIndex = 0;
            this.OKbtn.Text = "OK";
            this.OKbtn.UseVisualStyleBackColor = false;
            this.OKbtn.Click += new System.EventHandler(this.OKbtn_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Binary ITC", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(219, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 141);
            this.label1.TabIndex = 1;
            // 
            // Error
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CPU.Properties.Resources.futurama_bender_cpu_1920x1080_wallpaper_www_wallpaperno_com_241;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(516, 259);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OKbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Error";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error";
            this.Load += new System.EventHandler(this.Error_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKbtn;
        private System.Windows.Forms.Label label1;
    }
}
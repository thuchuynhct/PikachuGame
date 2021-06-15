namespace PikachuGame
{
    partial class FrMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrMain));
            this.btn_batdau = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_batdau
            // 
            this.btn_batdau.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_batdau.BackgroundImage")));
            this.btn_batdau.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_batdau.FlatAppearance.BorderSize = 0;
            this.btn_batdau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_batdau.Font = new System.Drawing.Font("VNF-Futura", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_batdau.Location = new System.Drawing.Point(305, 416);
            this.btn_batdau.Name = "btn_batdau";
            this.btn_batdau.Size = new System.Drawing.Size(110, 103);
            this.btn_batdau.TabIndex = 0;
            this.btn_batdau.Text = "BẮT ĐẦU";
            this.btn_batdau.UseVisualStyleBackColor = false;
            this.btn_batdau.Click += new System.EventHandler(this.btn_batdau_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(721, 520);
            this.Controls.Add(this.btn_batdau);
            this.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Thức Huỳnh";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_batdau;
    }
}


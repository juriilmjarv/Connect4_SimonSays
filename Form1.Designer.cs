namespace SimonSaysVersion3
{
    partial class SimonSays
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
            this.playBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.btnConnectFour = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(219, 148);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(131, 51);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Location = new System.Drawing.Point(219, 262);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(131, 37);
            this.exitBtn.TabIndex = 1;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // btnConnectFour
            // 
            this.btnConnectFour.Location = new System.Drawing.Point(219, 205);
            this.btnConnectFour.Name = "btnConnectFour";
            this.btnConnectFour.Size = new System.Drawing.Size(131, 51);
            this.btnConnectFour.TabIndex = 2;
            this.btnConnectFour.Text = "Play Connect Four";
            this.btnConnectFour.UseVisualStyleBackColor = true;
            this.btnConnectFour.Click += new System.EventHandler(this.btnConnectFour_Click);
            // 
            // SimonSays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.btnConnectFour);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.playBtn);
            this.Name = "SimonSays";
            this.Text = "SimonSays";
            this.Load += new System.EventHandler(this.SimonSays_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button btnConnectFour;
    }
}


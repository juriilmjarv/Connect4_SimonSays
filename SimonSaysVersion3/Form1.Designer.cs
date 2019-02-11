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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimonSays));
            this.playBtn = new System.Windows.Forms.Button();
            this.exitBtn = new System.Windows.Forms.Button();
            this.connectFourBtn = new System.Windows.Forms.Button();
            this.connectFourPvP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playBtn.Location = new System.Drawing.Point(141, 109);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(286, 44);
            this.playBtn.TabIndex = 0;
            this.playBtn.Text = "Simon Says";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitBtn.Location = new System.Drawing.Point(216, 323);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(131, 39);
            this.exitBtn.TabIndex = 1;
            this.exitBtn.Text = "Exit";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // connectFourBtn
            // 
            this.connectFourBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectFourBtn.Location = new System.Drawing.Point(141, 253);
            this.connectFourBtn.Name = "connectFourBtn";
            this.connectFourBtn.Size = new System.Drawing.Size(286, 45);
            this.connectFourBtn.TabIndex = 2;
            this.connectFourBtn.Text = "Connect 4 vs Computer";
            this.connectFourBtn.UseVisualStyleBackColor = true;
            this.connectFourBtn.Click += new System.EventHandler(this.connectFourBtn_Click);
            // 
            // connectFourPvP
            // 
            this.connectFourPvP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectFourPvP.Location = new System.Drawing.Point(141, 185);
            this.connectFourPvP.Name = "connectFourPvP";
            this.connectFourPvP.Size = new System.Drawing.Size(286, 44);
            this.connectFourPvP.TabIndex = 3;
            this.connectFourPvP.Text = "Connect 4 PvP";
            this.connectFourPvP.UseVisualStyleBackColor = true;
            this.connectFourPvP.Click += new System.EventHandler(this.connectFourPvP_Click);
            // 
            // SimonSays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.connectFourPvP);
            this.Controls.Add(this.connectFourBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.playBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SimonSays";
            this.Text = "SimonSays";
            this.Load += new System.EventHandler(this.SimonSays_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button connectFourBtn;
        private System.Windows.Forms.Button connectFourPvP;
    }
}


namespace AAsyncAwait
{
    partial class MainForm
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
            this.bQotdSync = new System.Windows.Forms.Button();
            this.labelQotd = new System.Windows.Forms.Label();
            this.bQotdThread = new System.Windows.Forms.Button();
            this.bQotdAR = new System.Windows.Forms.Button();
            this.bQotdAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bQotdSync
            // 
            this.bQotdSync.Location = new System.Drawing.Point(40, 54);
            this.bQotdSync.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bQotdSync.Name = "bQotdSync";
            this.bQotdSync.Size = new System.Drawing.Size(312, 180);
            this.bQotdSync.TabIndex = 0;
            this.bQotdSync.Text = "Quote of the Day Sync";
            this.bQotdSync.UseVisualStyleBackColor = true;
            this.bQotdSync.Click += new System.EventHandler(this.bQotdSync_Click);
            // 
            // labelQotd
            // 
            this.labelQotd.AutoSize = true;
            this.labelQotd.Font = new System.Drawing.Font("Segoe UI Semibold", 15.9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelQotd.Location = new System.Drawing.Point(59, 328);
            this.labelQotd.Name = "labelQotd";
            this.labelQotd.Size = new System.Drawing.Size(272, 72);
            this.labelQotd.TabIndex = 1;
            this.labelQotd.Text = "labelQotd";
            // 
            // bQotdThread
            // 
            this.bQotdThread.Location = new System.Drawing.Point(380, 54);
            this.bQotdThread.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bQotdThread.Name = "bQotdThread";
            this.bQotdThread.Size = new System.Drawing.Size(312, 180);
            this.bQotdThread.TabIndex = 2;
            this.bQotdThread.Text = "Quote of the Day Thread";
            this.bQotdThread.UseVisualStyleBackColor = true;
            this.bQotdThread.Click += new System.EventHandler(this.bQotdThread_Click);
            // 
            // bQotdAR
            // 
            this.bQotdAR.Location = new System.Drawing.Point(716, 54);
            this.bQotdAR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bQotdAR.Name = "bQotdAR";
            this.bQotdAR.Size = new System.Drawing.Size(312, 180);
            this.bQotdAR.TabIndex = 3;
            this.bQotdAR.Text = "Quote of the Day AR";
            this.bQotdAR.UseVisualStyleBackColor = true;
            this.bQotdAR.Click += new System.EventHandler(this.bQotdAR_Click);
            // 
            // bQotdAsync
            // 
            this.bQotdAsync.Location = new System.Drawing.Point(1048, 54);
            this.bQotdAsync.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.bQotdAsync.Name = "bQotdAsync";
            this.bQotdAsync.Size = new System.Drawing.Size(312, 180);
            this.bQotdAsync.TabIndex = 4;
            this.bQotdAsync.Text = "Quote of the Day Async";
            this.bQotdAsync.UseVisualStyleBackColor = true;
            this.bQotdAsync.Click += new System.EventHandler(this.bQotdAsync_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(18F, 45F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 628);
            this.Controls.Add(this.bQotdAsync);
            this.Controls.Add(this.bQotdAR);
            this.Controls.Add(this.bQotdThread);
            this.Controls.Add(this.labelQotd);
            this.Controls.Add(this.bQotdSync);
            this.Font = new System.Drawing.Font("Segoe UI", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Quote of the Day";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bQotdSync;
        private System.Windows.Forms.Label labelQotd;
        private System.Windows.Forms.Button bQotdThread;
        private System.Windows.Forms.Button bQotdAR;
        private System.Windows.Forms.Button bQotdAsync;
    }
}


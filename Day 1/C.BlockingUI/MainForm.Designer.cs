namespace C.BlockingUI
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
            this.bDoSomething = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bDoSomething
            // 
            this.bDoSomething.Location = new System.Drawing.Point(54, 60);
            this.bDoSomething.Name = "bDoSomething";
            this.bDoSomething.Size = new System.Drawing.Size(337, 59);
            this.bDoSomething.TabIndex = 0;
            this.bDoSomething.Text = "Do Something";
            this.bDoSomething.UseVisualStyleBackColor = true;
            this.bDoSomething.Click += new System.EventHandler(this.bDoSomething_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(337, 65);
            this.button1.TabIndex = 1;
            this.button1.Text = "Do Smth Async ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bDoSomething);
            this.Name = "MainForm";
            this.Text = "Blocking UI";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bDoSomething;
        private System.Windows.Forms.Button button1;
    }
}


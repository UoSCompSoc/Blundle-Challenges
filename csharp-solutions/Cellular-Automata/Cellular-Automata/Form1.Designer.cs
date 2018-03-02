namespace Cellular_Automata
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
            this.components = new System.ComponentModel.Container();
            this.picBoxWorld = new System.Windows.Forms.PictureBox();
            this.txtBoxSteps = new System.Windows.Forms.TextBox();
            this.lblSteps = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.timerAntStep = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWorld)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxWorld
            // 
            this.picBoxWorld.Location = new System.Drawing.Point(12, 12);
            this.picBoxWorld.Name = "picBoxWorld";
            this.picBoxWorld.Size = new System.Drawing.Size(500, 500);
            this.picBoxWorld.TabIndex = 0;
            this.picBoxWorld.TabStop = false;
            // 
            // txtBoxSteps
            // 
            this.txtBoxSteps.Location = new System.Drawing.Point(12, 531);
            this.txtBoxSteps.Name = "txtBoxSteps";
            this.txtBoxSteps.Size = new System.Drawing.Size(134, 20);
            this.txtBoxSteps.TabIndex = 1;
            this.txtBoxSteps.Text = "386";
            // 
            // lblSteps
            // 
            this.lblSteps.AutoSize = true;
            this.lblSteps.Location = new System.Drawing.Point(12, 515);
            this.lblSteps.Name = "lblSteps";
            this.lblSteps.Size = new System.Drawing.Size(34, 13);
            this.lblSteps.TabIndex = 2;
            this.lblSteps.Text = "Steps";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(402, 518);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(110, 33);
            this.btnRun.TabIndex = 3;
            this.btnRun.Text = "Run Simulation";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // timerAntStep
            // 
            this.timerAntStep.Interval = 1;
            this.timerAntStep.Tick += new System.EventHandler(this.timerAntStep_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 561);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.lblSteps);
            this.Controls.Add(this.txtBoxSteps);
            this.Controls.Add(this.picBoxWorld);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Langton\'s Ant";
            ((System.ComponentModel.ISupportInitialize)(this.picBoxWorld)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxWorld;
        private System.Windows.Forms.TextBox txtBoxSteps;
        private System.Windows.Forms.Label lblSteps;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Timer timerAntStep;
    }
}


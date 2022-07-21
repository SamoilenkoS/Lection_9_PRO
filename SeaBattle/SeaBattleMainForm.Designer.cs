
namespace SeaBattle
{
    partial class SeaBattleMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxPlayerLeftZone = new System.Windows.Forms.PictureBox();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerLeftZone)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxPlayerLeftZone
            // 
            this.pictureBoxPlayerLeftZone.BackColor = System.Drawing.Color.White;
            this.pictureBoxPlayerLeftZone.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxPlayerLeftZone.Name = "pictureBoxPlayerLeftZone";
            this.pictureBoxPlayerLeftZone.Size = new System.Drawing.Size(417, 377);
            this.pictureBoxPlayerLeftZone.TabIndex = 0;
            this.pictureBoxPlayerLeftZone.TabStop = false;
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonStart.Location = new System.Drawing.Point(464, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(94, 56);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // SeaBattleMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 592);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBoxPlayerLeftZone);
            this.Name = "SeaBattleMainForm";
            this.Text = "SeaBattle";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.SeaBattleMainForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlayerLeftZone)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxPlayerLeftZone;
        private System.Windows.Forms.Button buttonStart;
    }
}

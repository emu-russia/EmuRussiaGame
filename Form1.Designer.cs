namespace EmuRussiaGame
{
	partial class Form1
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
			this.edgblaSoftControl1 = new EmuRussiaGame.EdgblaSoftControl();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// edgblaSoftControl1
			// 
			this.edgblaSoftControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.edgblaSoftControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edgblaSoftControl1.Location = new System.Drawing.Point(0, 0);
			this.edgblaSoftControl1.Name = "edgblaSoftControl1";
			this.edgblaSoftControl1.Size = new System.Drawing.Size(624, 449);
			this.edgblaSoftControl1.TabIndex = 0;
			this.edgblaSoftControl1.Text = "edgblaSoftControl1";
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 449);
			this.Controls.Add(this.edgblaSoftControl1);
			this.KeyPreview = true;
			this.Name = "Form1";
			this.Text = "Emu-Russia Game";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
			this.ResumeLayout(false);

		}

		#endregion

		private EdgblaSoftControl edgblaSoftControl1;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}
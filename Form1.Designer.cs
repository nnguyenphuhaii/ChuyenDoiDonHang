namespace ChuyenDoiDonHang
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			btnImport = new Button();
			btnRun = new Button();
			lblResult = new Label();
			SuspendLayout();
			// 
			// btnImport
			// 
			btnImport.Location = new Point(12, 106);
			btnImport.Name = "btnImport";
			btnImport.Size = new Size(75, 23);
			btnImport.TabIndex = 0;
			btnImport.Text = "Import";
			btnImport.UseVisualStyleBackColor = true;
			btnImport.Click += btnImport_Click;
			// 
			// btnRun
			// 
			btnRun.Location = new Point(97, 106);
			btnRun.Name = "btnRun";
			btnRun.Size = new Size(75, 23);
			btnRun.TabIndex = 1;
			btnRun.Text = "Run";
			btnRun.UseVisualStyleBackColor = true;
			btnRun.Click += btnRun_Click;
			// 
			// lblResult
			// 
			lblResult.AutoSize = true;
			lblResult.Location = new Point(12, 9);
			lblResult.Name = "lblResult";
			lblResult.Size = new Size(45, 15);
			lblResult.TabIndex = 2;
			lblResult.Text = "Result: ";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Window;
			ClientSize = new Size(184, 161);
			Controls.Add(lblResult);
			Controls.Add(btnRun);
			Controls.Add(btnImport);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "HomeForm";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnImport;
		private Button btnRun;
		private Label lblResult;
	}
}
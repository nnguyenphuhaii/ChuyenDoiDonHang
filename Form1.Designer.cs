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
			btnAddPreset = new Button();
			cboPreset = new ComboBox();
			menuStrip1 = new MenuStrip();
			fileToolStripMenuItem = new ToolStripMenuItem();
			menuDeletePreset = new ToolStripMenuItem();
			menuExit = new ToolStripMenuItem();
			testToolStripMenuItem = new ToolStripMenuItem();
			menuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// btnImport
			// 
			btnImport.Location = new Point(12, 126);
			btnImport.Name = "btnImport";
			btnImport.Size = new Size(75, 23);
			btnImport.TabIndex = 0;
			btnImport.Text = "Import";
			btnImport.UseVisualStyleBackColor = true;
			btnImport.Click += btnImport_Click;
			// 
			// btnRun
			// 
			btnRun.Location = new Point(142, 126);
			btnRun.Name = "btnRun";
			btnRun.Size = new Size(75, 23);
			btnRun.TabIndex = 1;
			btnRun.Text = "Run";
			btnRun.UseVisualStyleBackColor = true;
			btnRun.Click += btnRun_Click;
			// 
			// lblResult
			// 
			lblResult.Dock = DockStyle.Top;
			lblResult.Location = new Point(0, 24);
			lblResult.Name = "lblResult";
			lblResult.Size = new Size(232, 83);
			lblResult.TabIndex = 2;
			lblResult.Text = "Result: ";
			// 
			// btnAddPreset
			// 
			btnAddPreset.Location = new Point(142, 97);
			btnAddPreset.Name = "btnAddPreset";
			btnAddPreset.Size = new Size(75, 23);
			btnAddPreset.TabIndex = 3;
			btnAddPreset.Text = "Add Preset";
			btnAddPreset.UseVisualStyleBackColor = true;
			btnAddPreset.Click += btnAddPreset_Click;
			// 
			// cboPreset
			// 
			cboPreset.FormattingEnabled = true;
			cboPreset.Location = new Point(12, 97);
			cboPreset.Name = "cboPreset";
			cboPreset.Size = new Size(121, 23);
			cboPreset.TabIndex = 4;
			// 
			// menuStrip1
			// 
			menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
			menuStrip1.Location = new Point(0, 0);
			menuStrip1.Name = "menuStrip1";
			menuStrip1.Size = new Size(232, 24);
			menuStrip1.TabIndex = 5;
			menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuDeletePreset, menuExit, testToolStripMenuItem });
			fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			fileToolStripMenuItem.Size = new Size(37, 20);
			fileToolStripMenuItem.Text = "File";
			fileToolStripMenuItem.Click += fileToolStripMenuItem_Click_1;
			// 
			// menuDeletePreset
			// 
			menuDeletePreset.Image = Properties.Resources.icons8_delete_24;
			menuDeletePreset.Name = "menuDeletePreset";
			menuDeletePreset.Size = new Size(180, 22);
			menuDeletePreset.Text = "Delete Preset";
			menuDeletePreset.Click += menuDeletePreset_Click;
			// 
			// menuExit
			// 
			menuExit.Image = Properties.Resources.icons8_exit_502;
			menuExit.Name = "menuExit";
			menuExit.Size = new Size(180, 22);
			menuExit.Text = "Exit";
			menuExit.Click += menuExit_Click;
			// 
			// testToolStripMenuItem
			// 
			testToolStripMenuItem.Name = "testToolStripMenuItem";
			testToolStripMenuItem.Size = new Size(180, 22);
			testToolStripMenuItem.Text = "Test";
			testToolStripMenuItem.Click += testToolStripMenuItem_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.Window;
			ClientSize = new Size(232, 161);
			Controls.Add(cboPreset);
			Controls.Add(btnAddPreset);
			Controls.Add(lblResult);
			Controls.Add(btnRun);
			Controls.Add(btnImport);
			Controls.Add(menuStrip1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MainMenuStrip = menuStrip1;
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "HomeForm";
			Load += Form1_Load;
			menuStrip1.ResumeLayout(false);
			menuStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btnImport;
		private Button btnRun;
		private Label lblResult;
		private Button btnAddPreset;
		private ComboBox cboPreset;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem fileToolStripMenuItem;
		private ToolStripMenuItem menuDeletePreset;
		private ToolStripMenuItem menuExit;
		private ToolStripMenuItem testToolStripMenuItem;
	}
}
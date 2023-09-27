namespace ChuyenDoiDonHang
{
    partial class DeletePreset
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
            cboDeletePreset = new ComboBox();
            btnDelete = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cboDeletePreset
            // 
            cboDeletePreset.FormattingEnabled = true;
            cboDeletePreset.Location = new Point(12, 12);
            cboDeletePreset.Name = "cboDeletePreset";
            cboDeletePreset.Size = new Size(121, 23);
            cboDeletePreset.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(139, 11);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(220, 12);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // DeletePreset
            // 
            AcceptButton = btnDelete;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(308, 49);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(cboDeletePreset);
            Name = "DeletePreset";
            StartPosition = FormStartPosition.CenterParent;
            Text = "DeletePreset";
            Load += DeletePreset_Load;
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cboDeletePreset;
        private Button btnDelete;
        private Button btnCancel;
    }
}
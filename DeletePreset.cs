using ChuyenDoiDonHang.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChuyenDoiDonHang
{
    public partial class DeletePreset : Form
    {
        private Form1 parentForm;
        List<Preset> presets = new List<Preset>();
        string presetNameToDelete = "";
        public DeletePreset(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeletePreset_Load(object sender, EventArgs e)
        {
            // Load danh sách preset từ tệp JSON và đổ vào ComboBox
            LoadPresetsFromFile(); // Triển khai hàm này
            cboDeletePreset.DataSource = presets;
            cboDeletePreset.DisplayMember = "Name";
        }
        private void LoadPresetsFromFile()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string formulasFolderPath = Path.Combine(documentsPath, "Formulas");

            string jsonPath = Path.Combine(formulasFolderPath, "myPresets.json");

            if (File.Exists(jsonPath))
            {
                string json = File.ReadAllText(jsonPath);
                presets = JsonConvert.DeserializeObject<List<Preset>>(json);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboDeletePreset.Text.Length == 0)
                {
                    throw new Exception("Cần chọn Preset để xoá!");
                }
                presetNameToDelete = cboDeletePreset.Text;
                DeletePresetChoosing(presetNameToDelete);
                this.parentForm.LoadPresetsFromFile();
                this.parentForm.UpdateComboBox();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeletePresetChoosing(string presetName)
        {
            try
            {
                Preset presetToRemove = presets.FirstOrDefault(p => p.Name == presetName);

                if (presetToRemove != null)
                {
                    presets.Remove(presetToRemove);
                    SavePresetsToFile(); // Cập nhật tệp JSON sau khi xóa
                    MessageBox.Show("Xoá Preset thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception("Không tìm thấy preset có tên: " + presetName);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SavePresetsToFile()
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string formulasFolderPath = Path.Combine(documentsPath, "Formulas");

            if (!Directory.Exists(formulasFolderPath))
            {
                Directory.CreateDirectory(formulasFolderPath);
            }

            string jsonPath = Path.Combine(formulasFolderPath, "myPresets.json");

            string json = JsonConvert.SerializeObject(presets);

            File.WriteAllText(jsonPath, json);
        }
    }
}

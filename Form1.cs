using ChuyenDoiDonHang.Model;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ChuyenDoiDonHang
{
	public partial class Form1 : Form
	{
		//string apiKey = "EZAKb9716aa6afc3430781d263bc5a21aed5h8RCmah8QB2Z5HEzQwiu2Q";
		//string apiKey = Environment.GetEnvironmentVariable("EZAKb9716aa6afc3430781d263bc5a21aed5h8RCmah8QB2Z5HEzQwiu2Q")!;
		//string apiUrl = "https://api.easypost.com/v2/verify/address";

		//string street1 = "821 Old Paint Road";
		//string street2 = "";
		//string city = "Raymore";
		//string state = "Missouri";
		//string zip = "64083";
		//string country = "United States";
		List<Order> orders = new List<Order>();


		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				// Chọn tệp tin CSV
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = "CSV Files|*.csv";
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = openFileDialog.FileName;

					// Đọc dữ liệu từ file CSV
					orders.Clear();
					using (var reader = new StreamReader(filePath))
					{
						var config = new CsvConfiguration(CultureInfo.InvariantCulture)
						{
							HasHeaderRecord = false // Không sử dụng dòng đầu tiên làm tiêu đề
						};
						using (var csv = new CsvReader(reader, config))
						{
							orders = csv.GetRecords<Order>().ToList();
							orders.RemoveAt(0);
							lblResult.Text = "Đọc file thành công.\nVui lòng bấm Run để chạy\nvà xuất file.";
						}
					}

				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				lblResult.Text = "Result: " + ex.Message;
			}
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog1 = new SaveFileDialog();
			saveFileDialog1.Filter = "CSV Files|*.csv";
			saveFileDialog1.Title = "Save CSV File";
			saveFileDialog1.ShowDialog();

			if (saveFileDialog1.FileName != "")
			{
				ExportToCsv(orders, saveFileDialog1.FileName);
				MessageBox.Show("File đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				lblResult.Text = "File đã được lưu thành công!";
			}
		}
		public void ExportToCsv(List<Order> orders, string filePath)
		{
			using (var writer = new StreamWriter(filePath))
			using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
			{
				csv.WriteRecords(orders);
			}
		}
	}
}
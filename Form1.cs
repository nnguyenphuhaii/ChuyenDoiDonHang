using ChuyenDoiDonHang.Model;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace ChuyenDoiDonHang
{
	public partial class Form1 : Form
	{
		List<Order> orders = new List<Order>();
		List<OrderOut> ordersOut = new List<OrderOut>();
		List<Preset> presets = new List<Preset>();
		OpenFileDialog openFileDialog = new OpenFileDialog();

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadPresetsFromFile();
			UpdateComboBox();
		}

		private async void btnImport_Click(object sender, EventArgs e)
		{
			try
			{
				openFileDialog.Filter = "CSV Files|*.csv";
				// Chọn tệp tin CSV
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = openFileDialog.FileName;

					// Đọc dữ liệu từ file CSV
					orders.Clear();
					ordersOut.Clear();
					using (var reader = new StreamReader(filePath))
					{
						var config = new CsvConfiguration(CultureInfo.InvariantCulture)
						{
							HasHeaderRecord = false // Không sử dụng dòng đầu tiên làm tiêu đề
						};
						using (var csv = new CsvReader(reader, config))
						{
							orders = csv.GetRecords<Order>().ToList();
							//Order firstRow = orders.FirstOrDefault();
							//ordersOut.Add(firstRow);
							orders.RemoveAt(0);

							foreach (Order order in orders)
							{
								if (order.LineitemSku == null)
								{
									break;
								}
                                if (CountingGach(order.LineitemSku) >= 2)
                                {
                                    // Tách chuỗi thành mảng các phần
                                    string[] phanTach = order.LineitemSku.Split('-');

                                    // Lấy phần tử cuối cùng trong mảng
                                    string kyTuSauDauGach = phanTach[phanTach.Length - 1];

                                    Console.WriteLine($"Ký tự sau dấu gạch thứ hai là: {kyTuSauDauGach}");
                                }
                            }
							ordersOut = orders.Select(p => new OrderOut
							{
								ID = p.Name,
								ProductSKU = p.LineitemSku,
								Size = SizeCalculator(p.LineitemSku),
                                CustomName = p.LineitemProperties,
                                Quantity = p.LineitemQuantity,
								Name = p.ShippingName,
								Telephone = p.ShippingPhone,
								Countrycode = p.ShippingCountryCode,
								MockupLink = p.LineitemImage,
								Province = p.ShippingProvince,
								City = p.ShippingCity,
								Street = p.ShippingAddress1 + ", " + p.ShippingAddress2,
								Postcode = p.ShippingZip
							}).ToList();

							foreach (OrderOut orderOut in ordersOut)
							{
								if (!string.IsNullOrEmpty(orderOut.ProductSKU) && orderOut.ProductSKU.Length >= 3)
								{
									string productSkuPrefix = orderOut.ProductSKU.Substring(0, 3);

									// Lấy ra công thức từ Preset được chọn
									Preset selectedPreset = presets.FirstOrDefault(p => p.Name == cboPreset.Text);

									if (selectedPreset != null)
									{
										Formula formula = selectedPreset.Formulas.Find(f => f.SKUSite == productSkuPrefix);

										if (formula != null)
										{
											orderOut.ProductSKU = formula.SKUYocol;
										}
										else
										{
											orderOut.ProductSKU = "#######";
                                        }
                                    }
                                }
							}
						}
					}
					// Tắt tạm để test những tính năng khác
					await VerifyAddresses(ordersOut);
					lblResult.Text = "Thành công.\nVui lòng bấm Run để chạy và xuất file.";
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
				ExportToCsv(ordersOut, saveFileDialog1.FileName);
				MessageBox.Show("File đã được lưu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				lblResult.Text = "File đã được lưu thành công!";
			}
		}
		public void ExportToCsv(List<OrderOut> ordersOut, string filePath)
		{
			using (var writer = new StreamWriter(filePath))
			using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
			{
				csv.WriteRecords(ordersOut);
			}
		}

		private void Form1_ResizeEnd(object sender, EventArgs e)
		{
		}

		private void btnAddPreset_Click(object sender, EventArgs e)
		{
			openFileDialog.Filter = "CSV Files|*.csv";
			string presetName = Microsoft.VisualBasic.Interaction.InputBox("Nhập tên của preset", "Tên preset", "");

			if (!string.IsNullOrEmpty(presetName))
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = openFileDialog.FileName;

					try
					{
						// Đọc nội dung từ tệp CSV
						string[] lines = File.ReadAllLines(filePath);

						// Kiểm tra xem nội dung có hợp lệ hay không
						if (lines.Length > 0)
						{
							// Tạo một mới preset
							Preset newPreset = new Preset
							{
								Formulas = new List<Formula>(),
								Name = presetName // Sử dụng tên được nhập từ InputBox
							};

							// Thêm các công thức từ tệp CSV vào danh sách công thức của preset
							foreach (string line in lines)
							{
								string[] fields = line.Split(','); // Giả sử các trường được phân tách bằng dấu ','
								if (fields.Length >= 3)
								{
									Formula formula = new Formula
									{
										Name = fields[0],
										SKUSite = fields[1],
										SKUYocol = fields[2]
									};
									newPreset.Formulas.Add(formula);
								}
								else
								{
									MessageBox.Show("Dòng không chứa đủ thông tin cần thiết.");
									return; // Thoát khỏi sự kiện để không thêm preset khi có lỗi
								}
							}
							newPreset.Formulas.RemoveAt(0);
							// Thêm preset vào danh sách và cập nhật combobox
							presets.Add(newPreset);
							cboPreset.Items.Add(newPreset.Name);

							// Hiển thị tên preset trong combobox
							cboPreset.SelectedItem = newPreset.Name;
							lblResult.Text = "Result: Thêm Preset " + newPreset.Name + " thành công!";

							SavePresetsToFile();
							// Xóa nội dung trường tên preset
							//textBoxPresetName.Text = "";
						}
						else
						{
							MessageBox.Show("Tệp CSV không chứa dữ liệu hợp lệ.");
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Đã xảy ra lỗi khi đọc tệp CSV: " + ex.Message);
					}
				}
				else
				{
					MessageBox.Show("Tệp chưa được chọn.");
				}
			}
			else
			{
				MessageBox.Show("Tên preset không được để trống.");
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

		public void LoadPresetsFromFile()
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
		public void UpdateComboBox()
		{
			cboPreset.Items.Clear();
			cboPreset.Text = "";

			foreach (Preset preset in presets)
			{
				cboPreset.Items.Add(preset.Name);
			}
		}

		private void fIleToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void menuExit_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void menuDeletePreset_Click(object sender, EventArgs e)
		{
			DeletePreset deleteForm = new DeletePreset(this);
			deleteForm.ShowDialog();
		}

		private void btnReload_Click(object sender, EventArgs e)
		{
			LoadPresetsFromFile();
			UpdateComboBox();
		}
		//private async Task CheckAddress(Address addressToCheck)
		//{
		//	HereAPIService hereApiService = new HereAPIService();

		//	string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		//	string formulasFolderPath = Path.Combine(documentsPath, "Formulas");

		//	try
		//	{
		//		bool isValid = await hereApiService.CheckAddressValidity(addressToCheck);

		//		if (isValid)
		//		{
		//			MessageBox.Show("Địa chỉ hợp lệ.");
		//		}
		//		else
		//		{
		//			MessageBox.Show("Địa chỉ không hợp lệ.");
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"Lỗi: {ex.Message}");
		//	}
		//}

		private void fileToolStripMenuItem_Click_1(object sender, EventArgs e)
		{

		}

		private async void testToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Address address = new Address
				{
					AddressLine1 = "7307 Southwind Dr",
					City = "Chesterfield",
					State = "Virginia",
					PostalCode = "23832",
					Country = "US"
				};
				//string apiUrl = "https://address.melissadata.net/v3/WEB/GlobalAddress/doGlobalAddress";
				string apiUrl = "https://personator.melissadata.net/v3/WEB/ContactVerify/doContactVerify";
				string apiKey = "eofMMY1Vf3p3zZqFjq_Gb6**nSAcwXpxhQ0PC2lXxuDAZ-**"; // Thay YOUR_API_KEY bằng API key của bạn

				//string requestUrl = $"{apiUrl}?AddressLine1={address.AddressLine1}&City={address.City}&State={address.State}&PostalCode={address.PostalCode}&Country={address.Country}&Key={apiKey}";
				string requestUrl = $"{apiUrl}?id={apiKey}&a1={address.AddressLine1}&loc={address.City}&admarea={address.State}&postal={address.PostalCode}&ctry={address.Country}&format=JSON";

				HttpClient client = new HttpClient();
				HttpResponseMessage response = await client.GetAsync(requestUrl);

				if (response.IsSuccessStatusCode)
				{
					string responseBody = await response.Content.ReadAsStringAsync();
					Console.WriteLine(responseBody);
					// Xử lý phản hồi từ API ở đây
				}
				else
				{
					// Xử lý khi yêu cầu thất bại
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				lblResult.Text = "Result: " + ex.Message;
			}
			
		}
		private async Task VerifyAddresses(List<OrderOut> ordersOut)
		{
			try
			{
				int dem = 0;
				string apiUrl = "https://personator.melissadata.net/v3/WEB/ContactVerify/doContactVerify";
				//string apiUrl = "https://address.melissadata.net/v3/WEB/GlobalAddress/doGlobalAddress";
				string apiKey = "Dh8bYYAxNZwYQ56pYOPJ2O**nSAcwXpxhQ0PC2lXxuDAZ-**";
                foreach (OrderOut order in ordersOut)
				{
					string requestUrl = $"{apiUrl}?id={apiKey}&a1={order.Street}&loc={order.City}&admarea={order.Province}&postal={order.Postcode}&ctry={order.Countrycode}&format=JSON";

					HttpClient client = new HttpClient();
					HttpResponseMessage response = await client.GetAsync(requestUrl);

					if (response.IsSuccessStatusCode)
					{
						string responseBody = await response.Content.ReadAsStringAsync();
						//JObject responseObject = JObject.Parse(responseBody);
						//string results = (string)responseObject["Records"][0]["Results"];

						if (responseBody.Contains("AS"))
						{
							order.VerifyAddress = "TRUE"; // Địa chỉ hợp lệ
						}
						else if (responseBody.Contains("AC"))
						{
							order.VerifyAddress = "SUSPECT"; // Địa chỉ có vấn đề  
						}
						else if (responseBody.Contains("AE"))
						{
							order.VerifyAddress = "FALSE"; // Địa chỉ không hợp lệ
						}
						else
						{ 
							order.VerifyAddress = "NOCREDIT";
						}
					}
					else
					{
						order.VerifyAddress = "THẤT BẠI"; // Xử lý khi yêu cầu thất bại
					}
					dem++;
					lblResult.Text = "Đã Verify xong dòng " + dem;
					await Task.Delay(50);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				lblResult.Text = "Result: " + ex.Message;
			}
		}
        private int CountingGach(string LineitemSku)
        {
            try
            {
				return LineitemSku.Split('-').Length - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblResult.Text = "Result: " + ex.Message;
				return -1;
            }
        }
        private string SizeCalculator(string LineitemSku)
        {
            try
            {
                if (CountingGach(LineitemSku) >= 2)
                {
                    // Tách chuỗi thành mảng các phần
                    string[] phanTach = LineitemSku.Split('-');
					string size = phanTach[phanTach.Length - 1].Trim();

                    if (size != "S" && size != "M" && size != "L" && size != "XL" && size != "XL" && size != "3XL" && size != "4XL" && size != "5XL")
					{
                        return "#######";
                    }

                    // Trả về size
                    return phanTach[phanTach.Length - 1];
                }
                else { return "#######"; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "#######";
            }
        }
        private string GetCustomName(string LineitemProperties)
        {
            try
            {
                if (LineitemProperties.Length > 0)
                {
                    // Tách chuỗi thành mảng các phần
                    string[] phanTach = LineitemProperties.Split(':');
                    return phanTach[phanTach.Length - 1].Trim();
                }
                else { return ""; }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }
    }
}
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
                    List<Order> orders = new List<Order>();
                    using (var reader = new StreamReader(filePath))
                    {
                        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                        {
                            HasHeaderRecord = true // Không sử dụng dòng đầu tiên làm tiêu đề
                        };
                        using (var csv = new CsvReader(reader, config))
                        {
                            orders = csv.GetRecords<Order>().ToList();
                        }
                    }
                    Console.WriteLine(orders);
                    // Hiển thị thông báo
                    //StringBuilder message = new StringBuilder();
                    //foreach (var order in orders)
                    //{
                    //    message.AppendLine($"Shop Domain: {order.SourceAnalytics}, Name: {order.Name}, Shipping Method: {order.ShippingMethod}, Created At: {order.CreatedAt}");
                    //    // (Thêm các thuộc tính khác vào message tùy theo nhu cầu)
                    //}

                    //MessageBox.Show(message.ToString(), "Thông tin đơn hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
        }
    }
}
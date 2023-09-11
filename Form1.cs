namespace ChuyenDoiDonHang
{
    public partial class Form1 : Form
    {
        //string apiKey = Environment.GetEnvironmentVariable("EZAKb9716aa6afc3430781d263bc5a21aed5h8RCmah8QB2Z5HEzQwiu2Q")!;
        string apiKey = "EZAKb9716aa6afc3430781d263bc5a21aed5h8RCmah8QB2Z5HEzQwiu2Q";

        string apiUrl = "https://api.easypost.com/v2/verify/address";

        string street1 = "821 Old Paint Road";
        string street2 = "";
        string city = "Raymore";
        string state = "Missouri";
        string zip = "64083";
        string country = "United States";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            openFileDialog.Title = "Select a CSV File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                // Xu ly file CSV
            }
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                var data = new
                {
                    address = new
                    {
                        street1 = street1,
                        street2 = street2,
                        city = city,
                        state = state,
                        zip = zip,
                        country = country
                    }
                };

                string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                HttpResponseMessage response = await client.PostAsync(apiUrl, new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json"));

                string result = await response.Content.ReadAsStringAsync();

                MessageBox.Show(result, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
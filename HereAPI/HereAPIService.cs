using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChuyenDoiDonHang.Model;

namespace ChuyenDoiDonHang.HereAPI
{
    public class HereAPIService
    {
        private const string ApiKey = "h-J-H-vbsrzmpdVWsKuUYdv1IwZZYkT-lkZ6AZMa7_g";

   //     public async Task<bool> CheckAddressValidity(Address address)
   //     {
			//try
			//{
			//	using (HttpClient client = new HttpClient())
			//	{
			//		string url = $"https://geocoder.ls.hereapi.com/6.2/geocode.json?searchtext={address}&apiKey={ApiKey}";

			//		HttpResponseMessage response = await client.GetAsync(url);
			//		if (response.IsSuccessStatusCode)
			//		{
			//			string responseData = await response.Content.ReadAsStringAsync();
			//			// Kiểm tra dữ liệu JSON để xác định tính hợp lệ của địa chỉ
			//			// Ví dụ: Kiểm tra trường "Result" hoặc "View" trong JSON
			//			// và kiểm tra số lượng kết quả trả về.
			//			// Điều này sẽ phụ thuộc vào định dạng JSON mà Here API trả về.
			//			// Có thể cần phân tích JSON để trích xuất thông tin cụ thể.

			//			// Ví dụ đơn giản: Nếu có kết quả trả về, địa chỉ được xem là hợp lệ
			//			return responseData.Contains("Result");
			//		}
			//		else
			//		{
			//			throw new Exception("Lỗi khi gọi Here API.");
			//		}
			//	}
			//}
			//catch (Exception ex)
			//{
			//	MessageBox.Show($"Lỗi: {ex.Message}");
			//}
   //     }
    }
}

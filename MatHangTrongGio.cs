using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopNPC.Models
{
    public class MatHangTrongGio
    {
        // Sản phẩm được mua
        public Product SanPham { get; set; }

        // Số lượng của sản phẩm đó
        public int SoLuong { get; set; }

        // --- CODE MỚI THÊM VÀO ---
        // Ô chứa "Trọng lượng" đã chọn (ví dụ: "200g")
        public string TrongLuong { get; set; }

        // Ô chứa "Loại sốt" đã chọn (ví dụ: "Sốt cay")
        public string LoaiSot { get; set; }

        // (Chúng ta có thể thêm 1 ID duy nhất cho mặt hàng trong giỏ nếu cần, nhưng tạm thời thế này là đủ)
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopNPC.Data;
using ShopNPC.Models;

namespace ShopNPC.Controllers
{
    public class HomeController : Controller
    {
        // Hàm này sẽ tự động chạy trước mọi Action trong controller
        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            // Gọi hàm đếm và truyền số lượng sản phẩm vào ViewBag để hiển thị trên giao diện
            ViewBag.SoLuongTrongGio = DemSoLuongTrongGioHang();
            base.OnActionExecuting(context);
        }

        public ActionResult Index()
        {
            var products = ProductData.GetAllProducts();  // lấy danh sách sản phẩm
            return View(products);
        }

        public ActionResult LandingPage()
        {
            var products = ProductData.GetAllProducts(); // Lấy danh sách sản phẩm
            return View(products); // Truyền vào View
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(string fullname, string email, string password, DateTime ngaysinh)
        {
            var users = Session["Users"] as List<User> ?? new List<User>();
            var user = new User
            {
                FullName = fullname,
                Email = email,
                Password = password,
                NgaySinh = ngaysinh
            };

            users.Add(user);
            Session["Users"] = users;

            // ✅ Lưu người vừa đăng ký vào session hiện tại
            Session["CurrentUser"] = user;

            return RedirectToAction("Profile");
        }


        public ActionResult SignIn()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Thitnuong()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Thitxao()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Nuocuong()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Monrau()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Hutieuvami()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Comrang()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Welcome()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult WelcomeBack()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ThanhToanThanhCong()
        {
            // Lấy từ TempData
            var orderId = TempData["LastOrderId"] as string;

            // Giữ TempData sống thêm 1 request nữa để view đọc được
            TempData.Keep("LastOrderId");

            // Nếu TempData rỗng thì fallback sang Session
            if (string.IsNullOrEmpty(orderId))
            {
                var ds = Session["DonHangs"] as List<DonHang>;
                orderId = ds?.FirstOrDefault()?.MaDon;
            }

            System.Diagnostics.Debug.WriteLine(">>> OrderId được gửi sang View: " + (orderId ?? "NULL"));

            ViewBag.OrderId = orderId;
            return View();
        }

        public ActionResult ThanhToan()
        {
            var gioHang = Session["GioHang"] as List<MatHangTrongGio>;

            if (gioHang == null || gioHang.Count == 0)
            {
                return RedirectToAction("XemGioHang");
            }

            // Tính tổng tiền
            decimal tongTienHang = gioHang.Sum(item => item.SanPham.Price * item.SoLuong);
            ViewBag.TongTienHang = tongTienHang;

            return View(gioHang); // truyền Model qua view
        }

        public ActionResult ProductDetail(int? id)
        {
            if (id == null)
                return RedirectToAction("Index"); // hoặc trả về view thông báo lỗi

            var product = ProductData.GetAllProducts().FirstOrDefault(p => p.Id == id);
            if (product == null)
                return HttpNotFound();

            return View(product);
        }

        // Action để hiển thị trang giỏ hàng
        public ActionResult GioHangTrong()
        {
            // Lấy giỏ hàng từ Session
            var gioHang = Session["GioHang"] as List<MatHangTrongGio>;

            // Nếu giỏ hàng chưa có hoặc không có sản phẩm nào
            if (gioHang == null || gioHang.Count == 0)
            {
                // Trả về view giỏ hàng trống
                return View("GioHangTrong"); // Bạn cần tạo 1 view tên là GioHangTrong.cshtml
            }

            // Nếu có sản phẩm, trả về view với danh sách mặt hàng
            return View(gioHang);
        }

        // HÀM SỐ 1: DÙNG ĐỂ "XEM" GIỎ HÀNG
        public ActionResult XemGioHang()
        {
            // Lấy giỏ hàng từ Session ra kiểm tra
            var gioHang = Session["GioHang"] as List<MatHangTrongGio>;

            // Controller sẽ TỰ QUYẾT ĐỊNH xem nên hiển thị giao diện nào
            if (gioHang == null || gioHang.Count == 0)
            {
                // NẾU GIỎ HÀNG TRỐNG:
                // Trả về file giao diện tên là "GioHangTrong.cshtml"
                return View("GioHangTrong");
            }
            else
            {
                // NẾU GIỎ HÀNG CÓ SẢN PHẨM:
                // Trả về file giao diện tên là "GioHangCoSanPham.cshtml" và gửi kèm dữ liệu.
                return View("GioHangCoSanPham", gioHang);
            }
        }

        // HÀM SỐ 2: DÙNG ĐỂ "THÊM" SẢN PHẨM VÀO GIỎ (ĐÃ NÂNG CẤP)
        [HttpPost]
        // Sửa 1: Thêm 2 tham số mới 'trongLuong' và 'loaiSot' vào đây
        public ActionResult ThemVaoGio(int maSP, int soLuong, string trongLuong, string loaiSot)
        {
            // Lấy giỏ hàng hiện tại từ Session
            var gioHang = Session["GioHang"] as List<MatHangTrongGio>;

            // Nếu chưa có giỏ hàng, tạo mới
            if (gioHang == null)
            {
                gioHang = new List<MatHangTrongGio>();
            }

            // Sửa 2: Kiểm tra xem sản phẩm VỚI CÙNG TÙY CHỌN (sốt, gram) đã có trong giỏ chưa
            var matHang = gioHang.FirstOrDefault(m =>
                m.SanPham.Id == maSP &&
                m.TrongLuong == trongLuong &&
                m.LoaiSot == loaiSot
            );

            if (matHang == null) // Nếu chưa có (hoặc có nhưng khác tùy chọn)
            {
                var sanPham = ProductData.GetAllProducts().FirstOrDefault(p => p.Id == maSP);
                if (sanPham != null)
                {
                    // Sửa 3: Thêm sản phẩm mới VÀO KHO, LƯU CẢ TÙY CHỌN
                    gioHang.Add(new MatHangTrongGio
                    {
                        SanPham = sanPham,
                        SoLuong = soLuong,
                        TrongLuong = trongLuong, // <-- LƯU TRỌNG LƯỢNG
                        LoaiSot = loaiSot        // <-- LƯU LOẠI SỐT
                    });
                }
            }
            else // Nếu đã có sản phẩm VỚI CÙNG TÙY CHỌN NÀY
            {
                matHang.SoLuong += soLuong; // Chỉ cần cộng thêm số lượng
            }

            // Lưu giỏ hàng trở lại vào Session
            Session["GioHang"] = gioHang;

            // Trả về thông báo cho JavaScript
            return Json(new { success = true, message = "Đã thêm sản phẩm vào giỏ hàng!" });
        }


        // Hàm này dùng để đếm tổng số lượng sản phẩm trong giỏ hàng
        private int DemSoLuongTrongGioHang()
        {
            int tongSoLuong = 0;

            var gioHang = Session["GioHang"] as List<MatHangTrongGio>;
            if (gioHang != null)
            {
                // Cộng dồn số lượng từng mặt hàng
                tongSoLuong = gioHang.Sum(sp => sp.SoLuong);
            }

            return tongSoLuong;
        }


        [HttpPost]
        public ActionResult TangSoLuong(int maSP)
        {
            var gioHang = Session["GioHang"] as List<MatHangTrongGio>;
            if (gioHang == null) return Json(new { success = false });

            var matHang = gioHang.FirstOrDefault(m => m.SanPham.Id == maSP);
            if (matHang != null)
            {
                matHang.SoLuong++;
                Session["GioHang"] = gioHang;
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult GiamSoLuong(int maSP)
        {
            var gioHang = Session["GioHang"] as List<MatHangTrongGio>;
            if (gioHang == null) return Json(new { success = false });

            var matHang = gioHang.FirstOrDefault(m => m.SanPham.Id == maSP);
            if (matHang != null)
            {
                matHang.SoLuong--;
                if (matHang.SoLuong <= 0)
                {
                    gioHang.Remove(matHang);
                }
                Session["GioHang"] = gioHang;
            }

            return Json(new { success = true });
        }


        [HttpPost]
        public ActionResult TienHanhThanhToan(
            string HoTen,
            string SoDienThoai,
            string TinhThanh,
            string PhuongXa,
            string DiaChi,
            string GhiChu,
            string PhuongThucThanhToan,
            string VoucherCode)
        {
            // Lấy giỏ hàng
            var gioHang = Session["GioHang"] as List<MatHangTrongGio>;
            if (gioHang == null || gioHang.Count == 0)
                return RedirectToAction("XemGioHang");

            // Tính tiền
            decimal tamTinh = gioHang.Sum(x => (decimal)x.SanPham.Price * x.SoLuong);
            decimal ship = 0;
            decimal giam = 0;
            decimal tong = Math.Max(0, tamTinh + ship - giam);

            // Tạo mã đơn
            string maDon = "DH" + DateTime.Now.ToString("yyyyMMddHHmmssfff");

            // Tạo object đơn hàng
            var don = new DonHang
            {
                MaDon = maDon,
                CreatedAt = DateTime.Now,
                HoTen = HoTen,
                SoDienThoai = SoDienThoai,
                DiaChiDayDu = $"{DiaChi}, {PhuongXa}, {TinhThanh}",
                PhuongThucThanhToan = PhuongThucThanhToan,
                TrangThai = (PhuongThucThanhToan ?? "").ToUpper().Contains("COD") ? "processing" : "paid",
                TamTinh = tamTinh,
                PhiVanChuyen = ship,
                GiamGia = giam,
                TongCong = tong,
                MaKhuyenMai = string.IsNullOrWhiteSpace(VoucherCode) ? null : VoucherCode,
                // Sửa 4: Lưu cả tùy chọn vào chi tiết đơn hàng
                Items = gioHang.Select(x => new MatHangTrongGio
                {
                    SanPham = x.SanPham,
                    SoLuong = x.SoLuong,
                    TrongLuong = x.TrongLuong, // <-- LƯU TRỌNG LƯỢNG
                    LoaiSot = x.LoaiSot        // <-- LƯU LOẠI SỐT
                }).ToList()
            };

            // Lưu vào Session “DonHangs”
            var ds = Session["DonHangs"] as List<DonHang> ?? new List<DonHang>();
            ds.Insert(0, don);
            Session["DonHangs"] = ds;

            // Xóa giỏ
            Session["GioHang"] = null;

            // Lưu mã đơn để hiển thị ở trang thanh toán thành công
            TempData["LastOrderId"] = maDon;

            return RedirectToAction("ChiTietDonHang", new { id = maDon });
        }


        // GET: /Home/OrderDetail?id=...
        public ActionResult ChiTietDonHang(string id)
        {
            var ds = Session["DonHangs"] as List<DonHang> ?? new List<DonHang>();
            var don = ds.FirstOrDefault(x => x.MaDon == id);
            if (don == null) return HttpNotFound("Không tìm thấy đơn hàng");
            return View(don); // Views/Home/OrderDetail.cshtml
        }

        // Tạo trang để check lịch sử mua hàng
        // GET: /Home/LichSuMuaHang
        public ActionResult LichSuMuaHang()
        {
            var ds = Session["DonHangs"] as List<DonHang> ?? new List<DonHang>();
            return View(ds);
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            var users = Session["Users"] as List<User> ?? new List<User>();
            var user = users.FirstOrDefault(u => u.Username == email && u.Password == password);

            if (user == null)
            {
                ViewBag.Error = "Sai email hoặc mật khẩu!";
                return View();
            }

            Session["CurrentUser"] = user;
            return RedirectToAction("WelcomeBack");
        }

        public new ActionResult Profile()
        {
            var user = Session["CurrentUser"] as User;
            if (user == null)
            {
                return RedirectToAction("SignIn"); // Nếu chưa đăng nhập thì quay lại đăng nhập
            }
            return View(user);
        }
    }
}
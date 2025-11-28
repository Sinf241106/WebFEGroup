using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopNPC.Models;

namespace ShopNPC.Data
{
    public class ProductData
    {
        public static List<Product> GetAllProducts()
        {
            return new List<Product>
            {
             new Product
             {
                 Id = 1,
                 Name = "Thịt heo nướng",
                 Price = 200000,
                 Storage = new List<string>{"200g", "400g", "600g"},
                 Colors = new List<string> { "Sốt cay", "Sốt BBQ", "Không sốt" },
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/heo nướng.jpeg"
                 }
             },

             new Product
             {
                 Id = 2,
                 Name = "Thịt bò nướng",
                 Price = 300000,
                 Storage = new List<string>{"300g", "500g"},
                 Colors = new List<string> { "Sốt cay", "Sốt tiêu đen" },
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/bò nướng.jpg"
                 }
             },

             new Product
             {
                 Id = 3,
                 Name = "Thịt gà nướng",
                 Price = 250000,
                 Storage = new List<string>{"Nửa con", "Nguyên con"},
                 Colors = new List<string> { "Sốt mật ong", "Sốt cay" },
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/gà nướng.jpg"
                 }
             },

             new Product
             {
                 Id = 4,
                 Name = "Thịt ngỗng nướng",
                 Price = 500000,
                 Storage = new List<string>{"Nửa con", "Nguyên con"},
                 Colors = new List<string> { "Sốt chao", "Muối ớt" },
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/ngỗng nướng.jpg"
                 }
             },

             new Product
             {
                 Id = 5,
                 Name = "Bồ câu xào hành",
                 Price = 190000,
                 Storage = new List<string>{"Nửa con", "Nguyên con"},
                 Colors = new List<string> { "Sốt chao", "Muối ớt" },
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/1200nha-1200x676.jpg"
                 }
             },

             new Product
             {
                 Id = 6,
                 Name = "Thịt heo xào cay",
                 Price = 200000,
                 Storage = new List<string>{"300g", "500g"}, 
                 Colors = new List<string> { "Mức 1 (Ít cay)", "Mức 2 (Vừa cay)" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/cach-lam-thit-ga-xao-bang-chao-chong-dinh-1_b885258c326e4625a7b6a09841b793f3.jpg"
                 }
             },

             new Product
             {
                 Id = 7,
                 Name = "Bò xào sả ớt",
                 Price = 200000,
                 Storage = new List<string>{"Nhỏ", "Lớn"}, 
                 Colors = new List<string> { "Ít sả ớt", "Cay nồng", "Cay đặc biệt" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/BoXaoSaOt1200-1200x675.jpg"
                 }
             },

             new Product
             {
                 Id = 8,
                 Name = "Thịt gà xào",
                 Price = 200000,
                 Storage = new List<string>{"1/2 con", "1 con"}, 
                 Colors = new List<string> { "Không hành tỏi", "Thêm hành lá" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/cach-lam-thit-ga-xao-bang-chao-chong-dinh-1_b885258c326e4625a7b6a09841b793f3.jpg"
                 }
             },

             new Product
             {
                 Id = 9,
                 Name = "Coca Cola",
                 Price = 15000,
                 Storage = new List<string>{"Chai 330ml", "Lon 330ml"}, 
                 Colors = new List<string> { "Thêm đá", "Không đá" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/ace2fd39-2fc5-4cc0-9b23-2268b49f3f52.jpg"
                 }
             },

             new Product
             {
                 Id = 10,
                 Name = "C2",
                 Price = 13000,
                 Storage = new List<string>{"Chai 360ml", "Lốc 6 chai"}, 
                 Colors = new List<string> { "Vị chanh", "Vị trà đào" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/34d667ff916fc434bb52ed1eea615ce0.jpg"
                 }
             },

             new Product
             {
                 Id = 11,
                 Name = "Pepsi",
                 Price = 15000,
                 Storage = new List<string>{ "Chai 330ml", "Lon 330ml"}, 
                 Colors = new List<string> { "Thêm đá", "Không đường" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/ace2fd39-2fc5-4cc0-9b23-2268b49f3f52.jpg"
                 }
             },

             new Product
             {
                 Id = 12,
                 Name = "Sting",
                 Price = 150000, 
                 Storage = new List<string>{"Chai 330ml", "Lốc 6 chai"}, 
                 Colors = new List<string> { "Dâu (Đỏ)", "Nhân sâm (Vàng)" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/67-2.jpg"
                 }
             },

             new Product
             {
                 Id = 13,
                 Name = "Rau lang xào tỏi",
                 Price = 190000,
                 Storage = new List < string > { "1 phần", "2 phần" }, 
                 Colors = new List<string> { "Ít tỏi", "Nhiều tỏi" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/raulangxao.jpg"
                 }
             },

             new Product
             {
                 Id = 14,
                 Name = "Cải ngồng xào nấm hương",
                 Price = 120000,
                 Storage = new List < string > { "1 phần", "2 phần" }, 
                 Colors = new List<string> { "Ít dầu hào", "Thêm nấm" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/caingongxaonam.jpg"
                 }
             },

             new Product
             {
                 Id = 15,
                 Name = "Đậu que xào mè",
                 Price = 140000,
                 Storage = new List < string > { "1 phần", "2 phần" }, 
                 Colors = new List<string> { "Ít mè", "Không mè" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/dauque.jpg"
                 }
             },

             new Product
             {
                 Id = 16,
                 Name = "Cải thìa xào dầu hào",
                 Price = 150000,
                 Storage = new List < string > { "1 phần", "2 phần" }, 
                 Colors = new List<string> { "Ít dầu hào", "Nhiều dầu hào" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/caithia.jpg"
                 }
             },


             new Product
             {
                 Id = 17,
                 Name = "Hủ tiếu gõ",
                 Price = 40000,
                 Storage = new List < string > { "Nhỏ", "Lớn" }, 
                 Colors = new List<string> { "Nước", "Khô" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/hutieugo.jpg"
                 }
             },

             new Product
             {
                 Id = 18,
                 Name = "Hủ tiếu mì khô",
                 Price = 90000,
                 Storage = new List < string > { "Nhỏ", "Lớn" }, 
                 Colors = new List<string> { "Thịt nạc", "Xí quách" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/hutieumikho.jpg"
                 }
             },

             new Product
             {
                 Id = 19,
                 Name = "Hủ tiếu xào chay",
                 Price = 90000,
                 Storage = new List < string > { "Nhỏ", "Lớn" }, 
                 Colors = new List<string> { "Không tỏi", "Thêm rau" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/cach-lam-hu-tieu-xao-chay-tu-hu-tieu-an-lien-202201201403525844.jpg"
                 }
             },

             new Product
             {
                 Id = 20,
                 Name = "Mì xào bò",
                 Price = 50000,
                 Storage = new List < string > { "Nhỏ", "Lớn" }, 
                 Colors = new List<string> { "Mì trứng", "Mì gói" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/mixaobo.jpg"
                 }
             },

             new Product
             {
                 Id = 21,
                 Name = "Cơm rang ghẹ",
                 Price = 540000,
                 Storage = new List < string > { "Nhỏ", "Lớn" }, 
                 Colors = new List<string> { "Không hành", "Thêm trứng" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/comrangghe.jpg"
                 }
             },

             new Product
             {
                 Id = 22,
                 Name = "Cơm Chiên Rong Biển",
                 Price = 190000,
                 Storage = new List < string > { "Nhỏ", "Lớn" }, 
                 Colors = new List<string> { "Ít rong biển", "Nhiều rong biển" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/comchienrongbien.jpg"
                 }
             },

             new Product
             {
                 Id = 23,
                 Name = "Cơm chiên cá hộp",
                 Price = 540000,
                 Storage = new List < string > { "Nhỏ", "Lớn" }, 
                 Colors = new List<string> { "Ít ớt", "Cay" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/comchiencahop.jpg"
                 }
             },

             new Product
             {
                 Id = 24,
                 Name = "Cơm Chiên Trứng Muối Lạp Xưởng",
                 Price = 190000,
                 Storage = new List < string > { "Nhỏ", "Lớn" }, 
                 Colors = new List<string> { "Ít lạp xưởng", "Thêm trứng muối" }, 
                 ImageUrls = new List<string>
                 {
                     "~/images_LandingPage/comchientrungmuoi.jpg"
                 }
             },
            };
        }
    }
}
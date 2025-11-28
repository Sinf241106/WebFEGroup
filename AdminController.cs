using System.Web.Mvc;

namespace ShopNPC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            // Tạm trả nội dung thô để kiểm tra route/controller
            return Content("Admin controller reached");
        }
    }
}
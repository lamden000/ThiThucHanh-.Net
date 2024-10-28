using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ThucHanh02.Models;
using ThucHanh02.ViewModel;
using X.PagedList;

namespace ThucHanh02.Controllers
{
    public class HomeController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber=page==null ||page< 0?1: page.Value;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().OrderBy(x=>x.TenSp);
            PagedList<TDanhMucSp> lst=new PagedList<TDanhMucSp>(lstSanPham,pageNumber,pageSize);
            return View(lst);
        }

        public IActionResult SanPhamTheoLoai(String maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanPham = db.TDanhMucSps.AsNoTracking().Where(x=>x.MaLoai==maloai).OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstSanPham, pageNumber, pageSize);
            ViewBag.MaLoai = maloai;
            return View(lst);
        }

        public IActionResult ChiTietSanPham(String maSp)
        { 
            var sanPham =db.TDanhMucSps.SingleOrDefault(x=>x.MaSp==maSp);
            var anhSp= db.TAnhSps.Where(x=>x.MaSp==maSp).ToList();
            ViewBag.anhSanPham=anhSp;
            return View(sanPham); 
        }

        public IActionResult ProductDetail(String maSp)
        {
            var sanPham = db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSp = db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            var homeProductDetailViewModel= new HomeProductDetailViewModel(sanPham, anhSp);
            return View(homeProductDetailViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

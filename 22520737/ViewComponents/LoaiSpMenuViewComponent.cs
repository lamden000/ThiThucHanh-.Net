using Microsoft.AspNetCore.Mvc;
using ThucHanh02.Models;
using ThucHanh02.Repository;

namespace ThucHanh02.ViewComponents
{
    public class LoaiSpMenuViewComponent: ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;
        public LoaiSpMenuViewComponent (ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }

        public IViewComponentResult Invoke()
        {
            var loaiSp = _loaiSp.GetAllLoaiSp().OrderBy(x=>x.Loai);
            return View(loaiSp);
        }
    }
}

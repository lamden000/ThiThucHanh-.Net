using ThucHanh02.Models;

namespace ThucHanh02.ViewModel
{
    public class HomeProductDetailViewModel
    { 
        public TDanhMucSp danhMucSp { set; get; }
        public List<TAnhSp> anhSps { set; get; }

        public HomeProductDetailViewModel(TDanhMucSp danhMucSp, List<TAnhSp> anhSps)
        {
            this.danhMucSp = danhMucSp;
            this.anhSps = anhSps;
        }   
    }
}

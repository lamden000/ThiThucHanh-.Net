using Thuchanh2.Models;
namespace Thuchanh2.Repository
{
    public interface ILoadSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(String maloaiSp);
        TLoaiSp GetLoaiSp(String maloaiSp);

        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}

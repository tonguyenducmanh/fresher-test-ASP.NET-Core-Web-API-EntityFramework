using fresher_test_ASP.NET_Core_Web_API.Models;
using System.Linq.Expressions;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class GetCustomerInfo
    {
        public  Expression<Func<customer, object>> selectQuery = t => new
        {
            _id = t._id,
            anh = t.anh,
            xungho = t.xungho,
            hovadem = t.hovadem,
            ten = t.ten,
            phongban = t.phongban,
            chucdanh = t.chucdanh,
            dtdidong = t.dtdidong,
            dtcoquan = t.dtcoquan,
            loaitiemnang = t.loaitiemnang.Select(k => k.loaitiemnangContent),
            the = t.the.Select(p => p.theContent),
            nguongoc = t.nguongoc,
            zalo = t.zalo,
            emailcanhan = t.emailcanhan,
            emailcoquan = t.emailcoquan,
            tochuc = t.tochuc,
            masothue = t.masothue,
            taikhoannganhang = t.taikhoannganhang,
            motainganhang = t.motainganhang,
            ngaythanhlap = t.ngaythanhlap,
            loaihinh = t.loaihinh,
            linhvuc = t.linhvuc,
            nganhnghe = t.nganhnghe,
            doanhthu = t.doanhthu,
            quocgia = t.quocgia,
            tinhthanhpho = t.tinhthanhpho,
            quanhuyen = t.quanhuyen,
            phuongxa = t.phuongxa,
            sonha = t.sonha,
            mota = t.mota,
            dungchung = t.dungchung,
            history = t.history.Select(u => u.historyContent)
        };
    }
}

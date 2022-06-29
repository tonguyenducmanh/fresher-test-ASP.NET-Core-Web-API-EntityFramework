using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class SetCustomerInfo
    {
        public customer PostCustomerInfo(
            [FromForm] PostCustomerBody PostCustomerBody)
        {
            bool Postdungchung;
            if (PostCustomerBody.dungChung == true)
            {
                Postdungchung = true;
            }
            else
            {
                Postdungchung = false;
            }
              return new customer()
                 {
                    _id = PostCustomerBody._id,
                    anh = PostCustomerBody.anh,
                    xungho = PostCustomerBody.xungHo,
                    hovadem = PostCustomerBody.hoVaDem,
                    ten = PostCustomerBody.ten,
                    phongban = PostCustomerBody.phongBan,
                    chucdanh = PostCustomerBody.chucDanh,
                    dtdidong = PostCustomerBody.dienThoaiDiDong,
                    dtcoquan = PostCustomerBody.dienThoaiCoQuan,
                    nguongoc = PostCustomerBody.nguonGoc,
                    zalo = PostCustomerBody.zalo,
                    emailcanhan = PostCustomerBody.emailCaNhan,
                    emailcoquan = PostCustomerBody.emailCoQuan,
                    tochuc = PostCustomerBody.toChuc,
                    masothue = PostCustomerBody.maSoThue,
                    taikhoannganhang = PostCustomerBody.taiKhoanNganHang,
                    motainganhang = PostCustomerBody.moTaiNganHang,
                    ngaythanhlap = PostCustomerBody.ngayThanhLap,
                    loaihinh = PostCustomerBody.loaiHinh,
                    linhvuc = PostCustomerBody.linhVuc,
                    nganhnghe = PostCustomerBody.nganhNghe,
                    doanhthu = PostCustomerBody.doanhThu,
                    quocgia = PostCustomerBody.quocGia,
                    tinhthanhpho = PostCustomerBody.tinhThanh,
                    quanhuyen = PostCustomerBody.quanHuyen,
                    phuongxa = PostCustomerBody.phuongXa,
                    sonha = PostCustomerBody.soNha,
                    mota = PostCustomerBody.moTa,
                    dungchung = Postdungchung,
            };
        }
    }
}

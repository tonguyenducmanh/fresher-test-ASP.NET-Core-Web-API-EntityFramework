using fresher_test_ASP.NET_Core_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class FilterLoaitiemnangCustomerInfo
    {
        public Expression<Func<customer, bool>> LoaitiemnangQuery(string? filterString, int? filterCondition)
        {
            if (filterString != null)
            {
                switch (filterCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.loaitiemnang.Where(t => t.loaitiemnangContent == filterString).Count() > 0);
                    case 2:
                        // trường hợp không là
                        return k => (k.loaitiemnang.Where(t => t.loaitiemnangContent != filterString).Count() > 0);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => (k.loaitiemnang.Where(t => t.loaitiemnangContent.Contains(filterString)).Count() > 0);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => (k.loaitiemnang.Where(t => t.loaitiemnangContent.Contains(filterString)).Count() == 0);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.loaitiemnang.Select(t => t.loaitiemnangId == 0).Count() == 0);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.loaitiemnang.Select(t => t.loaitiemnangId != 0).Count() > 0);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;
                }

            }
            else
            {
                switch (filterCondition)
                {
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.loaitiemnang.Select(t => t.loaitiemnangId == 0).Count() == 0);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.loaitiemnang.Select(t => t.loaitiemnangId != 0).Count() > 0);

                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;
                }
            }
        }


    }
}

using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class FilterCustomerInfo
    {
        //tạo ra biểu thức lọc customer theo filterString
        // trả về hoặc họ hoặc tên chứa từ khóa tìm kiếm
        public Expression<Func<customer, bool>> filterQuery(
            [FromForm] PostSearchAndFilter PostSearchAndFilter
            )
        {
            if (PostSearchAndFilter.phongbanString != null)
            {
                switch (PostSearchAndFilter.phongbanCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.phongban == PostSearchAndFilter.phongbanString);
                        break;
                    case 2:
                        // trường hợp không là
                        return k => (k.phongban != PostSearchAndFilter.phongbanString);
                        break;
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.phongban.Contains(PostSearchAndFilter.phongbanString);
                        break;
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.phongban.Contains(PostSearchAndFilter.phongbanString);
                        break;
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.phongban == null);
                        break;
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.phongban != null);
                        break;
/*                    case 7:
                        // trường hợp chứa giá trị true hoặc false, trả về true hoặc false ở chuỗi tìm
                        return k => (k.phongban ==  true);
                        break;*/
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;
                        break;
                    
                }

            }
            else
            {
                return k => true; ;
            }
        }
    }
}

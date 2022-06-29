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
                return k => (k.phongban.Contains(PostSearchAndFilter.phongbanString));

            }
            else
            {
                return k => true; ;
            }
        }
    }
}

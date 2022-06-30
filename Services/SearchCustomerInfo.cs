using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class SearchCustomerInfo
    {
        //tạo ra biểu thức lọc customer theo searchString
        // trả về hoặc họ hoặc tên chứa từ khóa tìm kiếm
        public Expression<Func<customer, bool>> searchQuery(
            [FromForm] PostSearchAndFilter PostSearchAndFilter
            )
        {
        if (PostSearchAndFilter.searchString != null)
            { 
                return k => (k.hovadem.Contains(PostSearchAndFilter.searchString)
                                    || k.ten.Contains(PostSearchAndFilter.searchString));

            }
        else { 
                return k => true; ; 
            }
        }

    }
}

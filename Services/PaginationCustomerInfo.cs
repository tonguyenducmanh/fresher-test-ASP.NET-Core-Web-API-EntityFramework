using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class PaginationCustomerInfo
    {
        //tạo ra biểu thức giới hạn kết quả trả về theo limit và startindex
        public int limitQuery(
            [FromForm] PostSearchAndFilter PostSearchAndFilter
            )
        {
            if (PostSearchAndFilter.limit != 0)
            {
                return PostSearchAndFilter.limit;

            }
            else
            {
                return int.MaxValue;
                // trả về giá trị lớn nhất có thể của int
            }
        }
        public int startIndexQuery(
            [FromForm] PostSearchAndFilter PostSearchAndFilter
            )
        {
            if (PostSearchAndFilter.startIndex != 0)
            {
                return PostSearchAndFilter.startIndex;

            }
            else
            {
                return 0;
            }
        }
    }
}

using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class FilterCustomerInfo
    {

        public Expression<Func<customer, bool>> FilterQuery(string? filterValue,string? filterString, int? filterCondition)
        {
            if (filterString != null)
            {
                switch (filterCondition)
                {
                    case 1:
                        // trường hợp là
                        // hiểu dòng dưới là k => k.filterValue == filterString. nhưng filterValue mình sẽ truyền
                        // từ ngoài vào để dùng nhiều lần nên k viết trực tiếp được
                        return k => Equals(EF.Property<bool>(k, filterValue), filterString);
                    case 2:
                        // trường hợp không là
                        return k => !Equals(EF.Property<bool>(k, filterValue), filterString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        // dòng dưới tương đương k => k.filterValue.Contains(filterString)
                        return k => EF.Property<string>(k, filterValue).Contains(filterString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !EF.Property<string>(k, filterValue).Contains(filterString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => EF.Property<bool>(k, filterValue) == null;
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => EF.Property<bool>(k, filterValue) != null;
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
                        return k => EF.Property<bool>(k, filterValue) == null;
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => EF.Property<bool>(k, filterValue) != null;
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;
                }
            }
        }
        

    }
}

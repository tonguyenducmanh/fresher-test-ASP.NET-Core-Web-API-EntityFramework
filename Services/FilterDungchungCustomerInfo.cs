using fresher_test_ASP.NET_Core_Web_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class FilterDungchungCustomerInfo
    {
        public Expression<Func<customer, bool>> FilterQuery(string? filterValue, bool? filterString, int? filterCondition)
        {
            if (filterString != null)
            {
                switch (filterCondition)
                {
                    case 7:
                        // trường hợp dành riêng cho đồng chí dùng chung filter
                        return k => Equals(EF.Property<bool>(k, filterValue), filterString);

                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;
                }

            }
            else
            {
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;
            }
        }


    }
}

using fresher_test_ASP.NET_Core_Web_API.Models;
using System.Linq.Expressions;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class FilterHistoryCustomerInfo
    {
        public Expression<Func<customer, bool>> HistoryQuery(string? filterString, int? filterCondition)
        {
            if (filterString != null)
            {
                switch (filterCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.history.Where(t => t.historyContent == filterString).Count() > 0);
                    case 2:
                        // trường hợp không là
                        return k => (k.history.Where(t => t.historyContent != filterString).Count() > 0);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => (k.history.Where(t => t.historyContent.Contains(filterString)).Count() > 0);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => (k.history.Where(t => t.historyContent.Contains(filterString)).Count() == 0);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.history.Select(t => t.historyId == 0).Count() == 0);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.history.Select(t => t.historyId != 0).Count() > 0);
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
                        return k => (k.history.Select(t => t.historyId == 0).Count() == 0);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.history.Select(t => t.historyId != 0).Count() > 0);

                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;
                }
            }
        }

    }
}

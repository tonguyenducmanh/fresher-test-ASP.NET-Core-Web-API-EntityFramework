/*using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace fresher_test_ASP.NET_Core_Web_API.Services
{
    public class FilterCustomerInfo
    {
        public Expression<Func<loaitiemnang, bool>> loaitiemnangQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.loaitiemnangString != null)
            {
                switch (PostSearchAndFilter.loaitiemnangCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.loaitiemnangContent == PostSearchAndFilter.loaitiemnangString);
                    case 2:
                        // trường hợp không là
                        return k => (k.loaitiemnangContent != PostSearchAndFilter.loaitiemnangString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.loaitiemnangContent.Contains(PostSearchAndFilter.loaitiemnangString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.loaitiemnangContent.Contains(PostSearchAndFilter.loaitiemnangString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.loaitiemnangContent == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.loaitiemnangContent != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<the, bool>> theQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.theString != null)
            {
                switch (PostSearchAndFilter.theCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.theContent == PostSearchAndFilter.theString);
                    case 2:
                        // trường hợp không là
                        return k => (k.theContent != PostSearchAndFilter.theString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.theContent.Contains(PostSearchAndFilter.theString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.theContent.Contains(PostSearchAndFilter.theString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.theContent == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.theContent != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<history, bool>> historyQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.historyString != null)
            {
                switch (PostSearchAndFilter.historyCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.historyContent == PostSearchAndFilter.historyString);
                    case 2:
                        // trường hợp không là
                        return k => (k.historyContent != PostSearchAndFilter.historyString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.historyContent.Contains(PostSearchAndFilter.historyString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.historyContent.Contains(PostSearchAndFilter.historyString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.historyContent == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.historyContent != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }

        public Expression<Func<customer, bool>> xunghoQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.xunghoString != null)
            {
                switch (PostSearchAndFilter.xunghoCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.xungho == PostSearchAndFilter.xunghoString);
                    case 2:
                        // trường hợp không là
                        return k => (k.xungho != PostSearchAndFilter.xunghoString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.xungho.Contains(PostSearchAndFilter.xunghoString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.xungho.Contains(PostSearchAndFilter.xunghoString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.xungho == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.xungho != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;
                    
                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> hovademQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.hovademString != null)
            {
                switch (PostSearchAndFilter.hovademCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.hovadem == PostSearchAndFilter.hovademString);
                    case 2:
                        // trường hợp không là
                        return k => (k.hovadem != PostSearchAndFilter.hovademString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.hovadem.Contains(PostSearchAndFilter.hovademString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.hovadem.Contains(PostSearchAndFilter.hovademString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.hovadem == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.hovadem != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> tenQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.tenString != null)
            {
                switch (PostSearchAndFilter.tenCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.ten == PostSearchAndFilter.tenString);
                    case 2:
                        // trường hợp không là
                        return k => (k.ten != PostSearchAndFilter.tenString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.ten.Contains(PostSearchAndFilter.tenString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.ten.Contains(PostSearchAndFilter.tenString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.ten == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.ten != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> phongbanQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.phongbanString != null)
            {
                switch (PostSearchAndFilter.phongbanCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.phongban == PostSearchAndFilter.phongbanString);
                    case 2:
                        // trường hợp không là
                        return k => (k.phongban != PostSearchAndFilter.phongbanString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.phongban.Contains(PostSearchAndFilter.phongbanString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.phongban.Contains(PostSearchAndFilter.phongbanString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.phongban == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.phongban != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> chucdanhQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.chucdanhString != null)
            {
                switch (PostSearchAndFilter.chucdanhCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.chucdanh == PostSearchAndFilter.chucdanhString);
                    case 2:
                        // trường hợp không là
                        return k => (k.chucdanh != PostSearchAndFilter.chucdanhString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.chucdanh.Contains(PostSearchAndFilter.chucdanhString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.chucdanh.Contains(PostSearchAndFilter.chucdanhString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.chucdanh == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.chucdanh != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> dtdidongQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.dtdidongString != null)
            {
                switch (PostSearchAndFilter.dtdidongCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.dtdidong == PostSearchAndFilter.dtdidongString);
                    case 2:
                        // trường hợp không là
                        return k => (k.dtdidong != PostSearchAndFilter.dtdidongString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.dtdidong.Contains(PostSearchAndFilter.dtdidongString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.dtdidong.Contains(PostSearchAndFilter.dtdidongString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.dtdidong == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.dtdidong != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> dtcoquanQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.dtcoquanString != null)
            {
                switch (PostSearchAndFilter.dtcoquanCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.dtcoquan == PostSearchAndFilter.dtcoquanString);
                    case 2:
                        // trường hợp không là
                        return k => (k.dtcoquan != PostSearchAndFilter.dtcoquanString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.dtcoquan.Contains(PostSearchAndFilter.dtcoquanString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.dtcoquan.Contains(PostSearchAndFilter.dtcoquanString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.dtcoquan == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.dtcoquan != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> nguongocQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.nguongocString != null)
            {
                switch (PostSearchAndFilter.nguongocCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.nguongoc == PostSearchAndFilter.nguongocString);
                    case 2:
                        // trường hợp không là
                        return k => (k.nguongoc != PostSearchAndFilter.nguongocString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.nguongoc.Contains(PostSearchAndFilter.nguongocString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.nguongoc.Contains(PostSearchAndFilter.nguongocString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.nguongoc == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.nguongoc != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> zaloQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.zaloString != null)
            {
                switch (PostSearchAndFilter.zaloCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.zalo == PostSearchAndFilter.zaloString);
                    case 2:
                        // trường hợp không là
                        return k => (k.zalo != PostSearchAndFilter.zaloString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.zalo.Contains(PostSearchAndFilter.zaloString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.zalo.Contains(PostSearchAndFilter.zaloString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.zalo == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.zalo != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> emailcanhanQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.emailcanhanString != null)
            {
                switch (PostSearchAndFilter.emailcanhanCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.emailcanhan == PostSearchAndFilter.emailcanhanString);
                    case 2:
                        // trường hợp không là
                        return k => (k.emailcanhan != PostSearchAndFilter.emailcanhanString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.emailcanhan.Contains(PostSearchAndFilter.emailcanhanString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.emailcanhan.Contains(PostSearchAndFilter.emailcanhanString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.emailcanhan == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.phongban != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> emailcoquanQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.emailcoquanString != null)
            {
                switch (PostSearchAndFilter.emailcoquanCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.emailcoquan == PostSearchAndFilter.emailcoquanString);
                    case 2:
                        // trường hợp không là
                        return k => (k.emailcoquan != PostSearchAndFilter.emailcoquanString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.emailcoquan.Contains(PostSearchAndFilter.emailcoquanString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.emailcoquan.Contains(PostSearchAndFilter.emailcoquanString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.emailcoquan == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.emailcoquan != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> tochucQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.tochucString != null)
            {
                switch (PostSearchAndFilter.tochucCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.tochuc == PostSearchAndFilter.tochucString);
                    case 2:
                        // trường hợp không là
                        return k => (k.tochuc != PostSearchAndFilter.tochucString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.tochuc.Contains(PostSearchAndFilter.tochucString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.tochuc.Contains(PostSearchAndFilter.tochucString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.tochuc == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.tochuc != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> masothueQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
    {
        if (PostSearchAndFilter.masothueString != null)
        {
            switch (PostSearchAndFilter.masothueCondition)
            {
                case 1:
                    // trường hợp là
                    return k => (k.masothue == PostSearchAndFilter.masothueString);
                case 2:
                    // trường hợp không là
                    return k => (k.masothue != PostSearchAndFilter.masothueString);
                case 3:
                    // trường hợp chứa, không phân biệt chữ hoa chữ thường
                    return k => k.masothue.Contains(PostSearchAndFilter.masothueString);
                case 4:
                    // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                    return k => !k.masothue.Contains(PostSearchAndFilter.masothueString);
                case 5:
                    // trường hợp trống hoặc có thể là null
                    return k => (k.masothue == null);
                case 6:
                    // trường hợp không trống, khác rỗng hoặc khác null
                    return k => (k.masothue != null);
                default:
                    // trường hợp mặc định, trả về true để tránh báo lỗi
                    return k => true;

            }

        }
        else
        {
            return k => true; ;
        }
    }
        public Expression<Func<customer, bool>> taikhoannganhangQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
    {
        if (PostSearchAndFilter.taikhoannganhangString != null)
        {
            switch (PostSearchAndFilter.taikhoannganhangCondition)
            {
                case 1:
                    // trường hợp là
                    return k => (k.taikhoannganhang == PostSearchAndFilter.taikhoannganhangString);
                case 2:
                    // trường hợp không là
                    return k => (k.taikhoannganhang != PostSearchAndFilter.taikhoannganhangString);
                case 3:
                    // trường hợp chứa, không phân biệt chữ hoa chữ thường
                    return k => k.taikhoannganhang.Contains(PostSearchAndFilter.taikhoannganhangString);
                case 4:
                    // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                    return k => !k.taikhoannganhang.Contains(PostSearchAndFilter.taikhoannganhangString);
                case 5:
                    // trường hợp trống hoặc có thể là null
                    return k => (k.taikhoannganhang == null);
                case 6:
                    // trường hợp không trống, khác rỗng hoặc khác null
                    return k => (k.taikhoannganhang != null);
                default:
                    // trường hợp mặc định, trả về true để tránh báo lỗi
                    return k => true;

            }

        }
        else
        {
            return k => true; ;
        }
    }
        public Expression<Func<customer, bool>> motainganhangQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
    {
        if (PostSearchAndFilter.motainganhangString != null)
        {
            switch (PostSearchAndFilter.motainganhangCondition)
            {
                case 1:
                    // trường hợp là
                    return k => (k.motainganhang == PostSearchAndFilter.motainganhangString);
                case 2:
                    // trường hợp không là
                    return k => (k.motainganhang != PostSearchAndFilter.motainganhangString);
                case 3:
                    // trường hợp chứa, không phân biệt chữ hoa chữ thường
                    return k => k.motainganhang.Contains(PostSearchAndFilter.motainganhangString);
                case 4:
                    // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                    return k => !k.motainganhang.Contains(PostSearchAndFilter.motainganhangString);
                case 5:
                    // trường hợp trống hoặc có thể là null
                    return k => (k.motainganhang == null);
                case 6:
                    // trường hợp không trống, khác rỗng hoặc khác null
                    return k => (k.motainganhang != null);
                default:
                    // trường hợp mặc định, trả về true để tránh báo lỗi
                    return k => true;

            }

        }
        else
        {
            return k => true; ;
        }
    }
        public Expression<Func<customer, bool>> ngaythanhlapQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
    {
        if (PostSearchAndFilter.ngaythanhlapString != null)
        {
            switch (PostSearchAndFilter.ngaythanhlapCondition)
            {
                case 1:
                    // trường hợp là
                    return k => (k.ngaythanhlap == PostSearchAndFilter.ngaythanhlapString);
                case 2:
                    // trường hợp không là
                    return k => (k.ngaythanhlap != PostSearchAndFilter.ngaythanhlapString);
                case 3:
                    // trường hợp chứa, không phân biệt chữ hoa chữ thường
                    return k => k.ngaythanhlap.Contains(PostSearchAndFilter.ngaythanhlapString);
                case 4:
                    // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                    return k => !k.ngaythanhlap.Contains(PostSearchAndFilter.ngaythanhlapString);
                case 5:
                    // trường hợp trống hoặc có thể là null
                    return k => (k.ngaythanhlap == null);
                case 6:
                    // trường hợp không trống, khác rỗng hoặc khác null
                    return k => (k.emailcoquan != null);
                default:
                    // trường hợp mặc định, trả về true để tránh báo lỗi
                    return k => true;

            }

        }
        else
        {
            return k => true; ;
        }
    }
        public Expression<Func<customer, bool>> loaihinhQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
    {
        if (PostSearchAndFilter.loaihinhString != null)
        {
            switch (PostSearchAndFilter.loaihinhCondition)
            {
                case 1:
                    // trường hợp là
                    return k => (k.loaihinh == PostSearchAndFilter.loaihinhString);
                case 2:
                    // trường hợp không là
                    return k => (k.loaihinh != PostSearchAndFilter.loaihinhString);
                case 3:
                    // trường hợp chứa, không phân biệt chữ hoa chữ thường
                    return k => k.loaihinh.Contains(PostSearchAndFilter.loaihinhString);
                case 4:
                    // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                    return k => !k.loaihinh.Contains(PostSearchAndFilter.loaihinhString);
                case 5:
                    // trường hợp trống hoặc có thể là null
                    return k => (k.loaihinh == null);
                case 6:
                    // trường hợp không trống, khác rỗng hoặc khác null
                    return k => (k.emailcoquan != null);
                default:
                    // trường hợp mặc định, trả về true để tránh báo lỗi
                    return k => true;

            }

        }
        else
        {
            return k => true; ;
        }
    }
        public Expression<Func<customer, bool>> linhvucQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.linhvucString != null)
            {
                switch (PostSearchAndFilter.linhvucCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.linhvuc == PostSearchAndFilter.linhvucString);
                    case 2:
                        // trường hợp không là
                        return k => (k.linhvuc != PostSearchAndFilter.linhvucString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.linhvuc.Contains(PostSearchAndFilter.linhvucString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.linhvuc.Contains(PostSearchAndFilter.linhvucString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.linhvuc == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.linhvuc != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> nganhngheQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.nganhngheString != null)
            {
                switch (PostSearchAndFilter.nganhngheCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.nganhnghe == PostSearchAndFilter.nganhngheString);
                    case 2:
                        // trường hợp không là
                        return k => (k.nganhnghe != PostSearchAndFilter.nganhngheString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.nganhnghe.Contains(PostSearchAndFilter.nganhngheString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.nganhnghe.Contains(PostSearchAndFilter.nganhngheString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.nganhnghe == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.nganhnghe != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> doanhthuQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.doanhthuString != null)
            {
                switch (PostSearchAndFilter.doanhthuCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.doanhthu == PostSearchAndFilter.doanhthuString);
                    case 2:
                        // trường hợp không là
                        return k => (k.doanhthu != PostSearchAndFilter.doanhthuString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.doanhthu.Contains(PostSearchAndFilter.doanhthuString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.doanhthu.Contains(PostSearchAndFilter.doanhthuString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.doanhthu == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.doanhthu != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> quocgiaQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.quocgiaString != null)
            {
                switch (PostSearchAndFilter.quocgiaCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.quocgia == PostSearchAndFilter.quocgiaString);
                    case 2:
                        // trường hợp không là
                        return k => (k.quocgia != PostSearchAndFilter.quocgiaString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.quocgia.Contains(PostSearchAndFilter.quocgiaString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.quocgia.Contains(PostSearchAndFilter.quocgiaString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.quocgia == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.quocgia != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> tinhthanhphoQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.tinhthanhphoString != null)
            {
                switch (PostSearchAndFilter.tinhthanhphoCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.tinhthanhpho == PostSearchAndFilter.tinhthanhphoString);
                    case 2:
                        // trường hợp không là
                        return k => (k.tinhthanhpho != PostSearchAndFilter.tinhthanhphoString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.tinhthanhpho.Contains(PostSearchAndFilter.tinhthanhphoString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.tinhthanhpho.Contains(PostSearchAndFilter.tinhthanhphoString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.tinhthanhpho == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.tinhthanhpho != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> quanhuyenQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.quanhuyenString != null)
            {
                switch (PostSearchAndFilter.quanhuyenCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.quanhuyen == PostSearchAndFilter.quanhuyenString);
                    case 2:
                        // trường hợp không là
                        return k => (k.quanhuyen != PostSearchAndFilter.quanhuyenString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.quanhuyen.Contains(PostSearchAndFilter.quanhuyenString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.quanhuyen.Contains(PostSearchAndFilter.quanhuyenString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.quanhuyen == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.quanhuyen != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> phuongxaQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.phuongxaString != null)
            {
                switch (PostSearchAndFilter.phuongxaCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.phuongxa == PostSearchAndFilter.phuongxaString);
                    case 2:
                        // trường hợp không là
                        return k => (k.phuongxa != PostSearchAndFilter.phuongxaString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.phuongxa.Contains(PostSearchAndFilter.phuongxaString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.phuongxa.Contains(PostSearchAndFilter.phuongxaString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.phuongxa == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.phuongxa != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> sonhaQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.sonhaString != null)
            {
                switch (PostSearchAndFilter.sonhaCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.sonha == PostSearchAndFilter.sonhaString);
                    case 2:
                        // trường hợp không là
                        return k => (k.sonha != PostSearchAndFilter.sonhaString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.sonha.Contains(PostSearchAndFilter.sonhaString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.sonha.Contains(PostSearchAndFilter.sonhaString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.sonha == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.sonha != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> motaQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.motaString != null)
            {
                switch (PostSearchAndFilter.motaCondition)
                {
                    case 1:
                        // trường hợp là
                        return k => (k.mota == PostSearchAndFilter.motaString);
                    case 2:
                        // trường hợp không là
                        return k => (k.mota != PostSearchAndFilter.motaString);
                    case 3:
                        // trường hợp chứa, không phân biệt chữ hoa chữ thường
                        return k => k.mota.Contains(PostSearchAndFilter.motaString);
                    case 4:
                        // trường hợp không chứa, không phân biệt chữ hoa chữ thường
                        return k => !k.mota.Contains(PostSearchAndFilter.motaString);
                    case 5:
                        // trường hợp trống hoặc có thể là null
                        return k => (k.mota == null);
                    case 6:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.mota != null);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
        public Expression<Func<customer, bool>> dungchungQuery([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (PostSearchAndFilter.dungchungString != null)
            {
                switch (PostSearchAndFilter.dungchungCondition)
                {
                    case 7:
                        // trường hợp không trống, khác rỗng hoặc khác null
                        return k => (k.dungchung == PostSearchAndFilter.dungchungString);
                    default:
                        // trường hợp mặc định, trả về true để tránh báo lỗi
                        return k => true;

                }

            }
            else
            {
                return k => true; ;
            }
        }
    }
}
*/
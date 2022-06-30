using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;
using System.Linq.Expressions;
using fresher_test_ASP.NET_Core_Web_API.Services;

namespace fresher_test_ASP.NET_Core_Web_API.Controllers
{

    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly customerDatabaseContext _context;

        public customersController(customerDatabaseContext context)
        {
            _context = context;
        }

        // POST: /customers/all (tải danh sách cơ sở dữ liệu theo dạng json, có điều kiện tìm kiếm)
        [HttpPost()]
        [Route("/customers/all")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> PostFetchCustomer([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {
            if (_context.customer == null)
            {
                return NotFound();
            }
            // tải danh sách customer
            List<object> queryText = _context.customer
                    .Where(new SearchCustomerInfo().searchQuery(PostSearchAndFilter))
                    .Where(new FilterCustomerInfo().FilterQuery("xungho", PostSearchAndFilter.xunghoString, PostSearchAndFilter.xunghoCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("hovadem", PostSearchAndFilter.hovademString, PostSearchAndFilter.hovademCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("ten", PostSearchAndFilter.tenString, PostSearchAndFilter.tenCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("phongban", PostSearchAndFilter.phongbanString, PostSearchAndFilter.phongbanCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("chucdanh", PostSearchAndFilter.chucdanhString, PostSearchAndFilter.chucdanhCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("dtdidong", PostSearchAndFilter.dtdidongString, PostSearchAndFilter.dtdidongCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("dtcoquan", PostSearchAndFilter.dtcoquanString, PostSearchAndFilter.dtcoquanCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("nguongoc", PostSearchAndFilter.nguongocString, PostSearchAndFilter.nguongocCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("zalo", PostSearchAndFilter.zaloString, PostSearchAndFilter.zaloCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("emailcanhan", PostSearchAndFilter.emailcanhanString, PostSearchAndFilter.emailcanhanCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("emailcoquan", PostSearchAndFilter.emailcoquanString, PostSearchAndFilter.emailcoquanCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("tochuc", PostSearchAndFilter.tochucString, PostSearchAndFilter.tochucCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("masothue", PostSearchAndFilter.masothueString, PostSearchAndFilter.masothueCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("taikhoannganhang", PostSearchAndFilter.taikhoannganhangString, PostSearchAndFilter.taikhoannganhangCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("motainganhang", PostSearchAndFilter.motainganhangString, PostSearchAndFilter.motainganhangCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("ngaythanhlap", PostSearchAndFilter.ngaythanhlapString, PostSearchAndFilter.ngaythanhlapCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("loaihinh", PostSearchAndFilter.loaihinhString, PostSearchAndFilter.loaihinhCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("linhvuc", PostSearchAndFilter.linhvucString, PostSearchAndFilter.linhvucCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("nganhnghe", PostSearchAndFilter.nganhngheString, PostSearchAndFilter.nganhngheCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("doanhthu", PostSearchAndFilter.doanhthuString, PostSearchAndFilter.doanhthuCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("quocgia", PostSearchAndFilter.quocgiaString, PostSearchAndFilter.quocgiaCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("tinhthanhpho", PostSearchAndFilter.tinhthanhphoString, PostSearchAndFilter.tinhthanhphoCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("quanhuyen", PostSearchAndFilter.quanhuyenString, PostSearchAndFilter.quanhuyenCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("phuongxa", PostSearchAndFilter.phuongxaString, PostSearchAndFilter.phuongxaCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("sonha", PostSearchAndFilter.sonhaString, PostSearchAndFilter.sonhaCondition))
                    .Where(new FilterCustomerInfo().FilterQuery("mota", PostSearchAndFilter.motaString, PostSearchAndFilter.motaCondition))
                    .Where(new FilterDungchungCustomerInfo().FilterQuery("dungchung", PostSearchAndFilter.dungchungString, PostSearchAndFilter.dungchungCondition))
                    .Where(new FilterLoaitiemnangCustomerInfo().LoaitiemnangQuery(PostSearchAndFilter.loaitiemnangString, PostSearchAndFilter.loaitiemnangCondition))
                    .Where(new FilterTheCustomerInfo().TheQuery(PostSearchAndFilter.theString, PostSearchAndFilter.theCondition))
                    .Where(new FilterHistoryCustomerInfo().HistoryQuery(PostSearchAndFilter.historyString, PostSearchAndFilter.historyCondition))
                    .Skip(new PaginationCustomerInfo().startIndexQuery(PostSearchAndFilter))
                    .Take(new PaginationCustomerInfo().limitQuery(PostSearchAndFilter))
                    .Select(new GetCustomerInfo().selectQuery).ToList();

            return Ok(queryText);
        }
        
        // POST : /customers/count đếm lượng người dùng
        [HttpPost()]
        [Route("/customers/count")]
        public async Task<ActionResult> PostCountCutomer([FromForm] PostSearchAndFilter PostSearchAndFilter)
        {

            var queryText = _context.customer
                .Where(new SearchCustomerInfo().searchQuery(PostSearchAndFilter))
                .Where(new FilterCustomerInfo().FilterQuery("xungho", PostSearchAndFilter.xunghoString, PostSearchAndFilter.xunghoCondition))
                .Where(new FilterCustomerInfo().FilterQuery("hovadem", PostSearchAndFilter.hovademString, PostSearchAndFilter.hovademCondition))
                .Where(new FilterCustomerInfo().FilterQuery("ten", PostSearchAndFilter.tenString, PostSearchAndFilter.tenCondition))
                .Where(new FilterCustomerInfo().FilterQuery("phongban", PostSearchAndFilter.phongbanString, PostSearchAndFilter.phongbanCondition))
                .Where(new FilterCustomerInfo().FilterQuery("chucdanh", PostSearchAndFilter.chucdanhString, PostSearchAndFilter.chucdanhCondition))
                .Where(new FilterCustomerInfo().FilterQuery("dtdidong", PostSearchAndFilter.dtdidongString, PostSearchAndFilter.dtdidongCondition))
                .Where(new FilterCustomerInfo().FilterQuery("dtcoquan", PostSearchAndFilter.dtcoquanString, PostSearchAndFilter.dtcoquanCondition))
                .Where(new FilterCustomerInfo().FilterQuery("nguongoc", PostSearchAndFilter.nguongocString, PostSearchAndFilter.nguongocCondition))
                .Where(new FilterCustomerInfo().FilterQuery("zalo", PostSearchAndFilter.zaloString, PostSearchAndFilter.zaloCondition))
                .Where(new FilterCustomerInfo().FilterQuery("emailcanhan", PostSearchAndFilter.emailcanhanString, PostSearchAndFilter.emailcanhanCondition))
                .Where(new FilterCustomerInfo().FilterQuery("emailcoquan", PostSearchAndFilter.emailcoquanString, PostSearchAndFilter.emailcoquanCondition))
                .Where(new FilterCustomerInfo().FilterQuery("tochuc", PostSearchAndFilter.tochucString, PostSearchAndFilter.tochucCondition))
                .Where(new FilterCustomerInfo().FilterQuery("masothue", PostSearchAndFilter.masothueString, PostSearchAndFilter.masothueCondition))
                .Where(new FilterCustomerInfo().FilterQuery("taikhoannganhang", PostSearchAndFilter.taikhoannganhangString, PostSearchAndFilter.taikhoannganhangCondition))
                .Where(new FilterCustomerInfo().FilterQuery("motainganhang", PostSearchAndFilter.motainganhangString, PostSearchAndFilter.motainganhangCondition))
                .Where(new FilterCustomerInfo().FilterQuery("ngaythanhlap", PostSearchAndFilter.ngaythanhlapString, PostSearchAndFilter.ngaythanhlapCondition))
                .Where(new FilterCustomerInfo().FilterQuery("loaihinh", PostSearchAndFilter.loaihinhString, PostSearchAndFilter.loaihinhCondition))
                .Where(new FilterCustomerInfo().FilterQuery("linhvuc", PostSearchAndFilter.linhvucString, PostSearchAndFilter.linhvucCondition))
                .Where(new FilterCustomerInfo().FilterQuery("nganhnghe", PostSearchAndFilter.nganhngheString, PostSearchAndFilter.nganhngheCondition))
                .Where(new FilterCustomerInfo().FilterQuery("doanhthu", PostSearchAndFilter.doanhthuString, PostSearchAndFilter.doanhthuCondition))
                .Where(new FilterCustomerInfo().FilterQuery("quocgia", PostSearchAndFilter.quocgiaString, PostSearchAndFilter.quocgiaCondition))
                .Where(new FilterCustomerInfo().FilterQuery("tinhthanhpho", PostSearchAndFilter.tinhthanhphoString, PostSearchAndFilter.tinhthanhphoCondition))
                .Where(new FilterCustomerInfo().FilterQuery("quanhuyen", PostSearchAndFilter.quanhuyenString, PostSearchAndFilter.quanhuyenCondition))
                .Where(new FilterCustomerInfo().FilterQuery("phuongxa", PostSearchAndFilter.phuongxaString, PostSearchAndFilter.phuongxaCondition))
                .Where(new FilterCustomerInfo().FilterQuery("sonha", PostSearchAndFilter.sonhaString, PostSearchAndFilter.sonhaCondition))
                .Where(new FilterCustomerInfo().FilterQuery("mota", PostSearchAndFilter.motaString, PostSearchAndFilter.motaCondition))
                .Where(new FilterDungchungCustomerInfo().FilterQuery("dungchung", PostSearchAndFilter.dungchungString, PostSearchAndFilter.dungchungCondition))
                .Where(new FilterLoaitiemnangCustomerInfo().LoaitiemnangQuery(PostSearchAndFilter.loaitiemnangString, PostSearchAndFilter.loaitiemnangCondition))
                .Where(new FilterTheCustomerInfo().TheQuery(PostSearchAndFilter.theString, PostSearchAndFilter.theCondition))
                .Where(new FilterHistoryCustomerInfo().HistoryQuery(PostSearchAndFilter.historyString, PostSearchAndFilter.historyCondition))
                .Count()
                ;
            return Ok(queryText);
        }

        // GET : /customers/last tải bản ghi cuối cùng
        [HttpGet()]
        [Route("/customers/last")]
        public async Task<ActionResult> GetLastCutomer()
        {
            if (_context.customer == null)
            {
                return NotFound();
            }

            var queryText = _context.customer
                .OrderByDescending(t => t._id)
                .Take(1)
                .Select(new GetCustomerInfo().selectQuery)
               ;
            return Ok(await queryText.ToListAsync());
        }

        // POST : /customers/find tìm danh sách người dùng theo id (để xuất ra file excell)
        [HttpPost()]
        [Route("/customers/find")]
        public async Task<ActionResult> PostFindCutomer(string[] idsString)
        {
            if (_context.customer == null)
            {
                return NotFound();
            }

            //query for select customer, loaitiemnang, history, the
            // return json file with multiple dimenstion array

            GetCustomerInfo getCustomer = new GetCustomerInfo();
            var selectQuery = getCustomer.selectQuery;

            List<object> findCustomerResult = new();
            foreach (string id2 in idsString)
            {
                var queryText = _context.customer
                    .Where(t => t._id == id2)
                    .Select(selectQuery)
                   ;
                if (queryText == null)
                {
                    return NotFound();
                }
                queryText.ToList();
                foreach(var item in queryText)
                {

                    findCustomerResult.Add(item);
                }
            }
            return Ok(findCustomerResult);
        }

        // GET : /customers/check check người dùng
        [HttpGet()]
        [Route("/customers/check")]
        public async Task<ActionResult> GetCheckCutomer(string findID)
        {
            if (_context.customer == null)
            {
                return NotFound();
            }

            //query for select customer, loaitiemnang, history, the
            // return json file with multiple dimenstion array

            GetCustomerInfo getCustomer = new GetCustomerInfo();
            var selectQuery = getCustomer.selectQuery;

            var queryText = _context.customer.Where(t => t._id == findID).Select(selectQuery).ToList()
               ;
            if(queryText.Count() == 1)
            {
                return Ok(queryText);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: /customers (thêm bản ghi vào các cơ sở dữ liệu)
        [HttpPost()]
        [Route("/customers")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> PostCreateCustomer(
            [FromForm] PostCustomerBody PostCustomerBody
            )
        {

            if (_context.customer == null)
            {
                return Problem("Entity set 'customerDatabaseContext.customer'  is null.");
            }

            //tạo object setcustomer và gọi method postcustomerinfo
            SetCustomerInfo setcustomer =  new SetCustomerInfo();

            var newCustomer = setcustomer.PostCustomerInfo(PostCustomerBody);

            _context.customer.Add(newCustomer);
            await _context.SaveChangesAsync();


            //thêm nhiều loại tiềm năng, thẻ, lịch sử dựa trên _id customer vừa tạo
            if (PostCustomerBody.loaiTiemNang != null)
            {
                for (int i = 0; i < PostCustomerBody.loaiTiemNang.Count(); i++)
                {
                    loaitiemnang newLoaitiemnang = new()
                    {
                        loaitiemnangId = (_context.loaitiemnang.Count() > 0) ? (_context.loaitiemnang.OrderByDescending(p => p.loaitiemnangId).FirstOrDefault().loaitiemnangId + 1) : 1,
                        loaitiemnangContent = PostCustomerBody.loaiTiemNang[i],
                        customerId = newCustomer._id
                    };
                    _context.loaitiemnang.Add(newLoaitiemnang);
                    await _context.SaveChangesAsync();

                }
            }
            if (PostCustomerBody.the != null)
            {
                for (int i = 0; i < PostCustomerBody.the.Count(); i++)
                {
                    the newThe = new()
                    {
                        theId = (_context.the.Count() > 0) ? (_context.the.OrderByDescending(p => p.theId).FirstOrDefault().theId + 1) : 1,
                        theContent = PostCustomerBody.the[i],
                        customerId = newCustomer._id
                    };
                    _context.the.Add(newThe);
                    await _context.SaveChangesAsync();

                }
            }
            if (PostCustomerBody.history != null)
            {
                for (int i = 0; i < PostCustomerBody.history.Count(); i++)
                {
                    history newHistory = new()
                    {
                        historyId = (_context.history.Count() > 0) ? (_context.history.OrderByDescending(p => p.historyId).FirstOrDefault().historyId + 1) : 1,
                        historyContent = PostCustomerBody.history[i],
                        customerId = newCustomer._id
                    };
                    _context.history.Add(newHistory);
                    await _context.SaveChangesAsync();

                }
            }

            return Ok();
        }

        // PUT:/customers/edit chỉnh sửa ở mức cơ bản, yêu cầu phải trùng id của tất cả các cơ sở dữ liệu
        [HttpPut()]
        [Route("/customers/edit")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> PutEditCustomer(
            [FromForm] PostCustomerBody PostCustomerBody
            )
        {

            if (_context.customer == null)
            {
                return Problem("Entity set 'customerDatabaseContext.customer'  is null.");
            }
            //tạo object setcustomer và gọi method postcustomerinfo
            SetCustomerInfo setcustomer = new SetCustomerInfo();

            var newCustomer = setcustomer.PostCustomerInfo(PostCustomerBody);

            _context.customer.Update(newCustomer);
            await _context.SaveChangesAsync();

            //xóa và thêm mới nhiều thẻ, lịch sử giao dịch, loại tiềm năng theo _id customer đã sửa
            //vì người dùng sửa mấy trường này còn có khả năng thêm mới nữa
            //nên xóa hết những cái cũ đi và thêm mới hàng loạt

            var loaitiemnangCu = _context.loaitiemnang
                                .Where(t => t.customerId == PostCustomerBody._id)                
                                .Select(t => t).ToList();
            for ( int i = 0; i < loaitiemnangCu.Count(); i ++)
            {
                var deleteloaitiemnangCu = await _context.loaitiemnang.FindAsync(loaitiemnangCu[i].loaitiemnangId);
                if (deleteloaitiemnangCu == null)
                {
                    return NotFound();
                }
                _context.loaitiemnang.Remove(deleteloaitiemnangCu);
            }
            await _context.SaveChangesAsync();

            if (PostCustomerBody.loaiTiemNang != null)
            {
                for (int i = 0; i < PostCustomerBody.loaiTiemNang.Count(); i++)
                {
                    loaitiemnang newLoaitiemnang = new()
                    {
                        loaitiemnangId = (_context.loaitiemnang.Count() > 0) ? (_context.loaitiemnang.OrderByDescending(p => p.loaitiemnangId).FirstOrDefault().loaitiemnangId + 1) : 1,
                        loaitiemnangContent = PostCustomerBody.loaiTiemNang[i],
                        customerId = newCustomer._id
                    };
                    _context.loaitiemnang.Add(newLoaitiemnang);
                    await _context.SaveChangesAsync();
                }
            }


            // xóa thẻ cũ và thêm những thẻ mới

            var theCu = _context.the
                    .Where(t => t.customerId == PostCustomerBody._id)
                    .Select(t => t).ToList();
            for (int i = 0; i < theCu.Count(); i++)
            {
                var deletetheCu = await _context.the.FindAsync(theCu[i].theId);
                if (deletetheCu == null)
                {
                    return NotFound();
                }
                _context.the.Remove(deletetheCu);
            }
            await _context.SaveChangesAsync();

            if (PostCustomerBody.the != null)
            {
                for (int i = 0; i < PostCustomerBody.the.Count(); i++)
                {
                    the newThe = new()
                    {
                        theId = (_context.the.Count() > 0) ? (_context.the.OrderByDescending(p => p.theId).FirstOrDefault().theId + 1) : 1,
                        theContent = PostCustomerBody.the[i],
                        customerId = newCustomer._id
                    };
                    _context.the.Add(newThe);
                    await _context.SaveChangesAsync();
                }
            }

            //xóa lịch sử giao dịch cũ và thêm lịch sử giao dịch mới

            var hisotryCu = _context.history
                    .Where(t => t.customerId == PostCustomerBody._id)
                    .Select(t => t).ToList();
            for (int i = 0; i < hisotryCu.Count(); i++)
            {
                var deletehistoryCu = await _context.history.FindAsync(hisotryCu[i].historyId);
                if (deletehistoryCu == null)
                {
                    return NotFound();
                }
                _context.history.Remove(deletehistoryCu);
            }
            await _context.SaveChangesAsync();

            if (PostCustomerBody.history != null)
            {
                for (int i = 0; i < PostCustomerBody.history.Count(); i++)
                {
                    history newHistory = new()
                    {
                        historyId = (_context.history.Count() > 0) ? (_context.history.OrderByDescending(p => p.historyId).FirstOrDefault().historyId + 1) : 1,
                        historyContent = PostCustomerBody.history[i],
                        customerId = newCustomer._id
                    };
                    _context.history.Add(newHistory);
                    await _context.SaveChangesAsync();
                }
            }
            return Ok();
        }

        // POST : /customers/delete xóa nhiều bản ghi
        [HttpPost()]
        [Route("/customers/delete")]
        public async Task<ActionResult> PostDeleteCustomer(string[] idsString)
        {
            if (_context.customer == null)
            {
                return NotFound();
            }
            foreach (string id2 in idsString)
            {
                var deleteCustomer = await _context.customer.FindAsync(id2);
                if (deleteCustomer == null)
                {
                    return NotFound();
                }

                _context.customer.Remove(deleteCustomer);
            }
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}

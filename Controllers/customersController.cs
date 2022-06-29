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
        public async Task<ActionResult> PostFetchCustomer(
            [FromForm] PostSearchAndFilter PostSearchAndFilter
            )
        {
            if (_context.customer == null)
            {
                return NotFound();
            }

            //query for select customer, loaitiemnang, history, the
            // return json file with multiple dimenstion array

            GetCustomerInfo getCustomer = new GetCustomerInfo();
            var selectQuery = getCustomer.selectQuery;


            // biểu thức tìm kiếm họ hoặc tên từ file SearchCustomerInfo.cs
            SearchCustomerInfo searchCustomer = new SearchCustomerInfo();
            var searchString = searchCustomer.searchQuery(PostSearchAndFilter);

            // biểu thức lọc customer từ file FilterCustomerInfo.cs
            FilterCustomerInfo filterCustomer = new FilterCustomerInfo();
            var filterString = filterCustomer.filterQuery(PostSearchAndFilter);


            // phân trang kết quả. ví dụ lấy 10 người từ người thứ 9
            List<object> queryText;

            if(PostSearchAndFilter.limit == 0 || PostSearchAndFilter.limit == null)
            {
                queryText = _context.customer.Where(searchString)
                    .Skip(PostSearchAndFilter.startIndex).Select(selectQuery).ToList();
            }
            else if(PostSearchAndFilter.startIndex == 0 || PostSearchAndFilter.startIndex == null)
            {
                queryText = _context.customer.Where(searchString).Take(PostSearchAndFilter.limit)
                    .Select(selectQuery).ToList();
            }
            else if(PostSearchAndFilter.limit == 0 && PostSearchAndFilter.startIndex == 0)
            {
                queryText = _context.customer.Select(selectQuery).ToList();
            }
            else
            {
                queryText = _context.customer.Where(searchString).Where(filterString)
                    .Skip(PostSearchAndFilter.startIndex).Take(PostSearchAndFilter.limit).Select(selectQuery).ToList();
            }
            return Ok(queryText);
        }
        
        // POST : /customers/count đếm lượng người dùng
        [HttpPost()]
        [Route("/customers/count")]
        public async Task<ActionResult> PostCountCutomer(
            [FromForm] PostSearchAndFilter PostSearchAndFilter
            )
        {

            // biểu thức tìm kiếm họ hoặc tên từ file SearchCustomerInfo.cs
            SearchCustomerInfo searchCustomer = new SearchCustomerInfo();
            var searchString = searchCustomer.searchQuery(PostSearchAndFilter);

            // biểu thức lọc customer từ file FilterCustomerInfo.cs
            FilterCustomerInfo filterCustomer = new FilterCustomerInfo();
            var filterString = filterCustomer.filterQuery(PostSearchAndFilter);


            var queryText = _context.customer
                .Where(searchString).Where(filterString).Count()
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

            //query for select customer, loaitiemnang, history, the
            // return json file with multiple dimenstion array

            GetCustomerInfo getCustomer = new GetCustomerInfo();
            var selectQuery = getCustomer.selectQuery;

            var queryText = _context.customer
                .OrderByDescending(t => t._id)
                .Take(1)
                .Select(selectQuery)
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

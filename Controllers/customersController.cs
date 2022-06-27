using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fresher_test_ASP.NET_Core_Web_API.Models;
using fresher_test_ASP.NET_Core_Web_API.Models.ModelRequest;

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

        public async Task<ActionResult> PostFetchCustomer()
        {
            if (_context.customer == null)
            {
                return NotFound();
            }
            var queryText = _context.customer.Select(t => new
            {
                _id = t._id,
                anh = t.anh,
                xungho = t.xungho,
                hovadem = t.hovadem,
                ten = t.ten,
                phongban = t.phongban,
                dtdidong = t.dtdidong,
                dtcoquan = t.dtcoquan,
                loaitiemnang = t.loaitiemnang.Select(k => k.loaitiemnangContent),
                the = t.the.Select(p => p.theContent),
                nguongoc = t.nguongoc,
                zalo = t.zalo,
                emailcanhan = t.emailcanhan,
                emailcoquan = t.emailcoquan,
                tochuc = t.tochuc,
                masothue = t.masothue,
                taikhoannganhang = t.taikhoannganhang,
                motainganhang = t.motainganhang,
                ngaythanhlap = t.ngaythanhlap,
                loaihinh = t.loaihinh,
                linhvuc = t.linhvuc,
                nganhnghe = t.nganhnghe,
                doanhthu = t.doanhthu,
                quocgia = t.quocgia,
                tinhthanhpho = t.tinhthanhpho,
                quanhuyen = t.quanhuyen,
                phuongxa = t.phuongxa,
                sonha = t.sonha,
                mota = t.mota,
                dungchung = t.dungchung,
                history = t.history.Select(u => u.historyContent)
            })
                ;
            return Ok(await queryText.ToListAsync());
        }


        // GET : /customers/last tải bản ghi cuối cùng
        [HttpGet()]
        [Route("/customers/last")]
        public async Task<ActionResult> GetLastCutomer()
        {
            return Ok();
        }
        // POST : /customers/find tìm người dùng
        [HttpPost()]
        [Route("/customers/find")]
        public async Task<ActionResult> PostFindCutomer()
        {
            return Ok();
        }

        // GET : /customers/check check người dùng
        [HttpGet()]
        [Route("/customers/check")]
        public async Task<ActionResult> GetCheckCutomer()
        {
            return Ok();
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

            customer newCustomer = new()
            {
                _id = PostCustomerBody.id,
                anh = PostCustomerBody.anh,
                xungho = PostCustomerBody.xungho,
                hovadem = PostCustomerBody.hovadem,
                ten = PostCustomerBody.ten,
                phongban = PostCustomerBody.phongban,
                dtdidong = PostCustomerBody.dtdidong,
                dtcoquan = PostCustomerBody.dtcoquan,
                nguongoc = PostCustomerBody.nguongoc,
                zalo = PostCustomerBody.zalo,
                emailcanhan = PostCustomerBody.emailcanhan,
                emailcoquan = PostCustomerBody.emailcoquan,
                tochuc = PostCustomerBody.tochuc,
                masothue = PostCustomerBody.masothue,
                taikhoannganhang = PostCustomerBody.taikhoannganhang,
                motainganhang = PostCustomerBody.motainganhang,
                ngaythanhlap = PostCustomerBody.ngaythanhlap,
                loaihinh = PostCustomerBody.loaihinh,
                linhvuc = PostCustomerBody.linhvuc,
                nganhnghe = PostCustomerBody.nganhnghe,
                doanhthu = PostCustomerBody.doanhthu,
                quocgia = PostCustomerBody.quocgia,
                tinhthanhpho = PostCustomerBody.tinhthanhpho,
                quanhuyen = PostCustomerBody.quanhuyen,
                phuongxa = PostCustomerBody.phuongxa,
                sonha = PostCustomerBody.sonha,
                mota = PostCustomerBody.mota,
                dungchung = PostCustomerBody.dungchung,
            };

            loaitiemnang newLoaitiemnang = new()
            {
                loaitiemnangId = PostCustomerBody.loaitiemnangId,
                loaitiemnangContent = PostCustomerBody.loaitiemnangContent,
                customerId = newCustomer._id
            };
            the newThe = new()
            {
                theId = PostCustomerBody.theId,
                theContent = PostCustomerBody.theContent,
                customerId = newCustomer._id
            };
            history newHistory = new()
            {
                historyId = PostCustomerBody.historyId,
                historyContent = PostCustomerBody.historyContent,
                customerId = newCustomer._id
            };
            _context.customer.Add(newCustomer);
            _context.loaitiemnang.Add(newLoaitiemnang);
            _context.the.Add(newThe);
            _context.history.Add(newHistory);
            await _context.SaveChangesAsync();
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

            customer newCustomer = new()
            {
                _id = PostCustomerBody.id,
                anh = PostCustomerBody.anh,
                xungho = PostCustomerBody.xungho,
                hovadem = PostCustomerBody.hovadem,
                ten = PostCustomerBody.ten,
                phongban = PostCustomerBody.phongban,
                dtdidong = PostCustomerBody.dtdidong,
                dtcoquan = PostCustomerBody.dtcoquan,
                nguongoc = PostCustomerBody.nguongoc,
                zalo = PostCustomerBody.zalo,
                emailcanhan = PostCustomerBody.emailcanhan,
                emailcoquan = PostCustomerBody.emailcoquan,
                tochuc = PostCustomerBody.tochuc,
                masothue = PostCustomerBody.masothue,
                taikhoannganhang = PostCustomerBody.taikhoannganhang,
                motainganhang = PostCustomerBody.motainganhang,
                ngaythanhlap = PostCustomerBody.ngaythanhlap,
                loaihinh = PostCustomerBody.loaihinh,
                linhvuc = PostCustomerBody.linhvuc,
                nganhnghe = PostCustomerBody.nganhnghe,
                doanhthu = PostCustomerBody.doanhthu,
                quocgia = PostCustomerBody.quocgia,
                tinhthanhpho = PostCustomerBody.tinhthanhpho,
                quanhuyen = PostCustomerBody.quanhuyen,
                phuongxa = PostCustomerBody.phuongxa,
                sonha = PostCustomerBody.sonha,
                mota = PostCustomerBody.mota,
                dungchung = PostCustomerBody.dungchung,
            };

            loaitiemnang newLoaitiemnang = new()
            {
                loaitiemnangId = PostCustomerBody.loaitiemnangId,
                loaitiemnangContent = PostCustomerBody.loaitiemnangContent,
                customerId = newCustomer._id
            };
            the newThe = new()
            {
                theId = PostCustomerBody.theId,
                theContent = PostCustomerBody.theContent,
                customerId = newCustomer._id
            };
            history newHistory = new()
            {
                historyId = PostCustomerBody.historyId,
                historyContent = PostCustomerBody.historyContent,
                customerId = newCustomer._id
            };
            _context.customer.Update(newCustomer);
            _context.loaitiemnang.Update(newLoaitiemnang);
            _context.the.Update(newThe);
            _context.history.Update(newHistory);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // POST : /customers/delete xóa nhiều bản ghi
        [HttpPost()]
        [Route("/customers/delete")]
        public async Task<ActionResult> PostDeleteCustomer(string[] id)
        {
            if (_context.customer == null)
            {
                return NotFound();
            }
            foreach (string id2 in id)
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

        // POST : /customers/count đếm lượng người dùng
        [HttpPost()]
        [Route("/customers/count")]
        public async Task<ActionResult> PostCountCutomer()
        {
            return Ok();
        }
    }
}

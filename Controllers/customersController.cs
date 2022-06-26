using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fresher_test_ASP.NET_Core_Web_API.Models;

namespace fresher_test_ASP.NET_Core_Web_API.Controllers
{
    [Route("/")]
    [ApiController]
    public class customersController : ControllerBase
    {
        private readonly customerDatabaseContext _context;

        public customersController(customerDatabaseContext context)
        {
            _context = context;
        }

        // GET: / (tải danh sách tiềm năng)
        [HttpGet()]
        [Route("/")]

        public async Task<ActionResult> Getcustomer()
        {
          if (_context.history == null)
          {
              return NotFound();
          }
            // nếu muốn hiện kết quả theo dạng mỗi id 1 thẻ 1 loại 1 lịch sử giao dịch
            //var queryText = from m in _context.history
            //                select m;
            //var queryText = from m in _context.customer
            //                join n in _context.loaitiemnang
            //                on m._id equals n.customerId
            //                join p in _context.the
            //                on m._id equals p.customerId
            //                join k in _context.history
            //                on m._id equals k.customerId
            //                select new
            //                {
            //                    _id = m._id,
            //                    hovadem = m.hovadem,
            //                    ten = m.ten,
            //                    loaitiemnang = n != null ? n.loaitiemnangContent: default,
            //                    the = p != null ? p.theContent: default,
            //                    history = k != null ? k.historyContent: default
            //                }; 

            //nếu muốn hiện kết quả dạng json nested
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
                    loaitiemnang = t.loaitiemnang.Select(k =>  k.loaitiemnangContent),
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

        
    }
}

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
    public class filtersController : ControllerBase
    {
        private readonly customerDatabaseContext _context;

        public filtersController(customerDatabaseContext context)
        {
            _context = context;
        }

        // GET: /filters tải toàn bộ danh sách bộ lọc
        [HttpGet]
        [Route("/filters")]
        public async Task<ActionResult> GetFetchFilter()
        {
          if (_context.filter == null)
          {
              return NotFound();
          }
            var queryText = from m in _context.filter
                            join n in _context.filterContent
                            on m.filterId equals n.filterId
                            select new {
                                _id = m.filterId,
                                name = m.name,
                                filter = new
                                    {
                                    xunghoString = n.xunghoString,
                                    xunghoCondition = n.xunghoCondition,
                                    hovademString = n.hovademString,
                                    hovademCondition = n.hovademCondition,
                                    tenString = n.tenString,
                                    tenCondition = n.tenCondition,
                                    phongbanString = n.phongbanString,
                                    phongbanCondition = n.phongbanCondition,
                                    chucdanhString = n.chucdanhString,
                                    chucdanhCondition = n.chucdanhCondition,
                                    dtdidongString = n.dtdidongString,
                                    dtdidongCondition = n.dtdidongCondition,
                                    dtcoquanString = n.dtcoquanString,
                                    dtcoquanCondition = n.dtcoquanCondition,
                                    loaitiemnangString = n.loaitiemnangString,
                                    loaitiemnangCondition = n.loaitiemnangCondition,
                                    theString = n.theString,
                                    theCondition = n.theCondition,
                                    nguongocString = n.nguongocString,
                                    nguongocCondition = n.nguongocCondition,
                                    zaloString = n.zaloString,
                                    zaloCondition = n.zaloCondition,
                                    emailcanhanString = n.emailcanhanString,
                                    emailcanhanCondition = n.emailcanhanCondition,
                                    emailcoquanString = n.emailcoquanString,
                                    emailcoquanCondition = n.emailcoquanCondition,
                                    tochucString = n.tochucString,
                                    tochucCondition = n.tochucCondition,
                                    masothueString = n.masothueString,
                                    masothueCondition = n.masothueCondition,
                                    taikhoannganhangString = n.taikhoannganhangString,
                                    taikhoannganhangCondition = n.taikhoannganhangCondition,
                                    motainganhangString = n.motainganhangString,
                                    motainganhangCondition = n.motainganhangCondition,
                                    ngaythanhlapString = n.ngaythanhlapString,
                                    ngaythanhlapCondition = n.ngaythanhlapCondition,
                                    loaihinhString = n.loaihinhString,
                                    loaihinhCondition = n.loaihinhCondition,
                                    linhvucString = n.linhvucString,
                                    linhvucCondition = n.linhvucCondition,
                                    nganhngheString = n.nganhngheString,
                                    nganhngheCondition = n.nganhngheCondition,
                                    doanhthuString = n.doanhthuString,
                                    doanhthuCondition = n.doanhthuCondition,
                                    quocgiaString = n.quocgiaString,
                                    quocgiaCondition = n.quocgiaCondition,
                                    tinhthanhphoString = n.tinhthanhphoString,
                                    tinhthanhphoCondition = n.tinhthanhphoCondition,
                                    quanhuyenString = n.quanhuyenString,
                                    quanhuyenCondition = n.quanhuyenCondition,
                                    phuongxaString = n.phuongxaString,
                                    phuongxaCondition = n.phuongxaCondition,
                                    sonhaString = n.sonhaString,
                                    sonhaCondition = n.sonhaCondition,
                                    motaString = n.motaString,
                                    motaCondition = n.motaCondition,
                                    dungchungString = n.dungchungString,
                                    dungchungCondition = n.dungchungCondition,
                                }
                            };

            return Ok(await queryText.ToListAsync());
        }

        // GET: /filter/delete xóa danh sách các bộ lọc
        [HttpGet]
        [Route("/filters/delete")]
        public async Task<ActionResult> GetDeleteFilter(int id)
        {
          if (_context.filter == null)
          {
              return NotFound();
          }
            var deleteFilter = await _context.filter.FindAsync(id);
            if (deleteFilter == null)
            {
                return NotFound();
            }

            _context.filter.Remove(deleteFilter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: /filters tạo bộ lọc mới
        [HttpPost]
        [Route("/filters")]
        public async Task<ActionResult<filter>> PostCreateFilter(
            [FromForm] PostFilterBody PostFilterBody
        )
        {
            if (_context.filter == null)
            {
                return Problem("Entity set 'customerDatabaseContext.filter'  is null.");
            }
            filter newFilter = new(){
                filterId = (_context.filter.Count() > 0 )? (_context.filter.OrderByDescending(p => p.filterId).FirstOrDefault().filterId + 1) : 1,
                name = PostFilterBody.name
            };
            filterContent newFilterContent = new(){
                 filterId = newFilter.filterId,
                 filterContentId = (_context.filterContent.Count() > 0) ? (_context.filterContent.OrderByDescending(p => p.filterContentId).FirstOrDefault().filterContentId + 1) : 1,
                 xunghoString = PostFilterBody.xunghoString,
                 xunghoCondition = PostFilterBody.xunghoCondition,  
                 hovademString = PostFilterBody.hovademString,
                 hovademCondition = PostFilterBody.hovademCondition,
                 tenString = PostFilterBody.tenString,  
                 tenCondition = PostFilterBody.tenCondition, 
                 phongbanString = PostFilterBody.phongbanString,
                 phongbanCondition = PostFilterBody.phongbanCondition,  
                 chucdanhString = PostFilterBody.chucdanhString,
                 chucdanhCondition = PostFilterBody.chucdanhCondition, 
                 dtdidongString = PostFilterBody.dtdidongString,
                 dtdidongCondition = PostFilterBody.dtdidongCondition,  
                 dtcoquanString = PostFilterBody.dtcoquanString, 
                 dtcoquanCondition = PostFilterBody.dtcoquanCondition,
                 loaitiemnangString = PostFilterBody.loaitiemnangString,  
                 loaitiemnangCondition = PostFilterBody.loaitiemnangCondition,  
                 theString = PostFilterBody.theString,  
                 theCondition = PostFilterBody.theCondition,  
                 nguongocString = PostFilterBody.nguongocString,  
                 nguongocCondition = PostFilterBody.nguongocCondition,  
                 zaloString = PostFilterBody.zaloString,  
                 zaloCondition = PostFilterBody.zaloCondition, 
                 emailcanhanString = PostFilterBody.emailcanhanString,  
                 emailcanhanCondition = PostFilterBody.emailcanhanCondition,  
                 emailcoquanString = PostFilterBody.emailcoquanString,
                 emailcoquanCondition = PostFilterBody.emailcoquanCondition, 
                 tochucString = PostFilterBody.tochucString,  
                 tochucCondition = PostFilterBody.tochucCondition, 
                 masothueString = PostFilterBody.masothueString,  
                 masothueCondition = PostFilterBody.masothueCondition,  
                 taikhoannganhangString = PostFilterBody.taikhoannganhangString,  
                 taikhoannganhangCondition = PostFilterBody.taikhoannganhangCondition, 
                 motainganhangString = PostFilterBody.motainganhangString,  
                 motainganhangCondition = PostFilterBody.motainganhangCondition, 
                 ngaythanhlapString = PostFilterBody.ngaythanhlapString, 
                 ngaythanhlapCondition = PostFilterBody.ngaythanhlapCondition,  
                 loaihinhString = PostFilterBody.loaihinhString,  
                 loaihinhCondition = PostFilterBody.loaihinhCondition,  
                 linhvucString = PostFilterBody.linhvucString, 
                 linhvucCondition = PostFilterBody.linhvucCondition,  
                 nganhngheString = PostFilterBody.nganhngheString,  
                 nganhngheCondition = PostFilterBody.nganhngheCondition,  
                 doanhthuString = PostFilterBody.doanhthuString,  
                 doanhthuCondition = PostFilterBody.doanhthuCondition,
                 quocgiaString = PostFilterBody.quocgiaString,  
                 quocgiaCondition = PostFilterBody.quocgiaCondition,  
                 tinhthanhphoString = PostFilterBody.tinhthanhphoString, 
                 tinhthanhphoCondition = PostFilterBody.tinhthanhphoCondition,  
                 quanhuyenString = PostFilterBody.quanhuyenString,  
                 quanhuyenCondition = PostFilterBody.quanhuyenCondition,  
                 phuongxaString = PostFilterBody.phuongxaString,  
                 phuongxaCondition = PostFilterBody.phuongxaCondition,  
                 sonhaString = PostFilterBody.sonhaString,  
                 sonhaCondition = PostFilterBody.sonhaCondition,  
                 motaString = PostFilterBody.motaString,  
                 motaCondition = PostFilterBody.motaCondition,  
                 dungchungString = PostFilterBody.dungchungString,  
                 dungchungCondition = PostFilterBody.dungchungCondition,  
            };
            _context.filter.Add(newFilter);
            _context.filterContent.Add(newFilterContent);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // PUT: /filters/edit chỉnh sửa tên của bộ lọc
        [HttpPut]
        [Route("/filters/edit")]
        public async Task<IActionResult> PutEditFilter(int id, string name)
        {
            var filterEdit = _context.filter.Where(s => s.filterId == id).FirstOrDefault<filter>();
            if (filterEdit != null)
            {
                filterEdit.name = name;
            _context.SaveChanges();
            }
            return Ok();
        }
        private bool filterExists(int id)
        {
            return (_context.filter?.Any(e => e.filterId == id)).GetValueOrDefault();
        }
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("customer")]
    public class customer
    {
        [Key]
        public string _id { get; set; } = default!;
        public string anh { get; set; } = default!;
        public string xungho { get; set; } = default!;
        public string hovadem { get; set; } = default!;
        public string ten { get; set; } = default!;
        public string phongban { get; set; } = default!;
        public string dtdidong { get; set; } = default!;
        public string dtcoquan { get; set; } = default!;
        public ICollection<loaitiemnang> loaitiemnang { get; set; } = default!;
        public ICollection<the> the { get; set; } = default!;
        public string nguongoc { get; set; } = default!;
        public string zalo { get; set; } = default!;
        public string emailcanhan { get; set; } = default!;
        public string emailcoquan { get; set; } = default!;
        public string tochuc { get; set; } = default!;
        public string masothue { get; set; } = default!;
        public string taikhoannganhang { get; set; } = default!;
        public string motainganhang { get; set; } = default!;
        public string ngaythanhlap { get; set; } = default!;
        public string loaihinh { get; set; } = default!;
        public string linhvuc { get; set; } = default!;
        public string nganhnghe { get; set; } = default!;
        public string doanhthu { get; set; } = default!;
        public string quocgia { get; set; } = default!;
        public string tinhthanhpho { get; set; } = default!;
        public string quanhuyen { get; set; } = default!;
        public string phuongxa { get; set; } = default!;
        public string sonha { get; set; } = default!;
        public string mota { get; set; } = default!;
        public bool dungchung { get; set; } = default!;
        public ICollection<history> history { get; set; } = default!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("loaitiemnang")]
    public class loaitiemnang
    {
        [Key]
        public string loaitiemnangId { get; set; }
        public string loaitiemnangContent { get; set; }
        public customer customer { get; set; }
    }
}

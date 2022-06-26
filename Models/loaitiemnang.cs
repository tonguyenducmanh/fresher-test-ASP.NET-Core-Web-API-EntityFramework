using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("loaitiemnang")]
    public class loaitiemnang
    {
        [Key]
        public string loaitiemnangId { get; set; } = default!;
        public string loaitiemnangContent { get; set; } = default!;
        [ForeignKey("customer")]
        public string customerId { get; set; } = default!;
        public customer customer { get; set; } = default!;
    }
}

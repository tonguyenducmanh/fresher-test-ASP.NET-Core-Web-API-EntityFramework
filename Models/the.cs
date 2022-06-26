using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("the")]
    public class the
    {
        [Key]
        public string theId { get; set; } = default!;
        public string theContent { get; set; } = default!;
        [ForeignKey("customer")]
        public string customerId { get; set; } = default!;
        public customer customer { get; set; } = default!;
    }
}

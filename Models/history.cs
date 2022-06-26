using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fresher_test_ASP.NET_Core_Web_API.Models
{
    [Table("history")]
    public class history
    {
        [Key]
        public string historyId { get; set; } = default!;
        public string historyContent { get; set; } = default!;
        [ForeignKey("customer")]
        public string customerId { get; set; } = default!;
        public customer customer { get; set; } = default!;
    }
}

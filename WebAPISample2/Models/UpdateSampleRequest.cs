using System.ComponentModel.DataAnnotations;
//được sử dụng để cập nhật thông tin của một thực thể mẫu hiện có
namespace WebAPISample2.Models
{
    public class UpdateSampleRequest
    {
        [StringLength(100)]
        public string? Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime? DueDate { get; set; }
    }
}

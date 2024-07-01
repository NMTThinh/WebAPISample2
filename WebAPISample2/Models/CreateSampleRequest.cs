using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
// dùng để thêm thông tin cho 1 thực  thể 
namespace WebAPISample2.Models
{
    public class CreateSampleRequest
    {
        [Required] //thuộc tính này phải được cung cấp (không thể null hoặc trống).
        [JsonRequired] //thuộc tính là bắt buộc khi đối tượng được tuần tự hóa/giải tuần tự hóa từ JSON.
        [StringLength(100)] //Giới hạn độ dài của chuỗi tối đa là 100 ký tự.

        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [JsonRequired]
        public DateTime DueDate { get; set; }
    }
}

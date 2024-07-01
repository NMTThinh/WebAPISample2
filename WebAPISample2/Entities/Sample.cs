using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPISample2.Entities
    // class này để 
{
    [Table("Sample")] //Đánh dấu đây là một đối tượng ánh xạ tới bảng có tên là "Sample" trong cơ sở dữ liệu. Cho biết cột nào được ánh xạ tới thuộc tính nào

    public class Sample
    {
        [Key] //Thuộc tính này đánh dấu là khóa chính của bảng, trong trường hợp này là ID.
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
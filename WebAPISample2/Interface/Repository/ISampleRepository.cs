using WebAPISample2.Entities;
using WebAPISample2.Infrastructure;
//định nghĩa các phương thức truy cập dữ liệu đặc biệt cho mô hình
namespace WebAPISample2.Interface.Repository
{
    public interface ISampleRepository : IRepository<Sample> // việc kế thừa tất cả các phương thức chung và cho phép mở rộng thêm các phương thức đặc biệt nếu cần thiết cho mô hình Sample.
    {
    }
}
using WebAPISample2.Entities;
using WebAPISample2.Models;
//  giúp đơn giản hóa việc tương tác với mô hình Sample thông qua các phương thức chức năng cơ bản
namespace WebAPISample2.Interface.Service
{
    public interface ISampleService
    {
        Task<IEnumerable<Sample>> GetAllAsync();
        Task<Sample> GetSampleIdAsync(int id);
        Task CreateSampleAsync(CreateSampleRequest request);
        Task UpdateSample(int id, UpdateSampleRequest request);
        Task DeleteSampleAsync(int id);
    }
}
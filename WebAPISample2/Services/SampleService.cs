using AutoMapper;
using WebAPISample2.Entities;
using WebAPISample2.Interface.Repository;
using WebAPISample2.Interface.Service;
using WebAPISample2.Models;
//được thiết kế để thực hiện các hoạt động nghiệp vụ liên quan đến mô hình Sample trong ứng dụng
namespace WebAPISample.Service
{
    public class SampleService : ISampleService 
    {
        private ISampleRepository sampleRepository; // //Sử dụng ISampleRepository để thực hiện các thao tác cơ bản như lấy dữ liệu từ cơ sở dữ liệu, thêm mới, cập nhật và xóa mẫu (Sample)
        private IMapper mapper; // ánh xạ dữ liệu 
        private readonly ILogger<SampleService> logger; //ghi lại các hoạt động quan trọng của dịch vụ
        public SampleService(ISampleRepository sampleRepository, IMapper mapper, ILogger<SampleService> logger)
        {
            this.sampleRepository = sampleRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<IEnumerable<Sample>> GetAllAsync()
        {
            var res = await sampleRepository.GetAllAsync();
            if (res == null)
            {
                logger.LogInformation($" No Sample items found");
            }
            return res;
        }

        public async Task<Sample> GetSampleIdAsync(int id)
        {
            var res = await sampleRepository.GetByIDAsync(id);
            if (res == null)
            {
                logger.LogInformation($"No Sample item with Id {id} found.");
            }
            return res;
        }

        public async Task CreateSampleAsync(CreateSampleRequest request)
        {
            try
            {
                // DATA
                var dataAdd = mapper.Map<Sample>(request);
                dataAdd.CreatedAt = DateTime.Now;

                // CREATE & SAVE
                await sampleRepository.CreateAsync(dataAdd);
                await sampleRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while creating the todo item.");
            }
        }

        public async Task UpdateSample(int id, UpdateSampleRequest request)
        {
            try
            {
                // FINDED
                var dataTable = await sampleRepository.GetByIDAsync(id);
                if (dataTable != null)
                {
                    var dataUpdate = mapper.Map(request, dataTable);
                    dataUpdate.UpdatedAt = DateTime.Now;

                    // UPDATE & SAVE
                    sampleRepository.Update(dataUpdate);
                    await sampleRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($" No Sample items found");
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while updating the todo item.");
            }
        }

        public async Task DeleteSampleAsync(int id)
        {
            try
            {
                // FINDED
                var data = await sampleRepository.GetByIDAsync(id);
                if (data != null)
                {
                    // DELETE & SAVE
                    sampleRepository.Delete(data);
                    await sampleRepository.SaveChangeAsync();
                }
                else
                {
                    logger.LogInformation($"No item found with the id {id}");
                }
            }
            catch (Exception ex)
            {

                logger.LogError(ex, "An error occurred while remove the todo item.");
            }
        }
    }
}
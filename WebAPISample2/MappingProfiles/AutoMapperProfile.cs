using AutoMapper;
using WebAPISample2.Entities;
using WebAPISample2.Models;
// giúp chuyển đổi dữ liệu giữa các lớp DTO và các entity (thực thể) 
namespace WebAPISample2.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateSampleRequest, Sample>() // tạo ánh xạ từ CreateSampleRequest đến  Sample 
                .ForMember(dest => dest.ID, opt => opt.Ignore()) //ForMember: Cấu hình các thuộc tính cần bỏ qua trong quá trình ánh xạ. 
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
           // dest.ID, dest.CreatedAt, dest.UpdatedAt được bỏ qua vì chúng có thể được tạo tự động hoặc không cần thiết phải ánh xạ từ yêu cầu tạo.
            CreateMap<UpdateSampleRequest, Sample>()
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
                .ConvertUsing(new NullValueIgnoringConverter<UpdateSampleRequest, Sample>());
            //ConvertUsing:bỏ qua các giá trị null trong UpdateSampleRequest, chỉ ánh xạ các thuộc tính có giá trị.
        }
    }
}
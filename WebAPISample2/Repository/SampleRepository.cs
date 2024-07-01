﻿using WebAPISample2.EF;
using WebAPISample2.Entities;
using WebAPISample2.Infrastructure;
using WebAPISample2.Interface.Repository;
//thực hiện các phương thức truy cập dữ liệu cho mô hình và đồng thời tuân thủ hợp đồng được định nghĩa bởi interface repository tương ứng. 
namespace WebAPISample.Repository
{
    public class SampleRepository : Repository<Sample>, ISampleRepository
    //SampleRepository kế thừa tất cả các phương thức CRUD đã được triển khai trong Repository<T>.
    {
        // hàm khởi tạo 
        public SampleRepository(SampleDbContext context) : base(context)
            // nhận vào một đối tượng SampleDBContext và truyền qua cho base
        {
        }
    }
}
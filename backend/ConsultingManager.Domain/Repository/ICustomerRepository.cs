﻿using ConsultingManager.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsultingManager.Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> Add(CustomerDto customerDto);
        Task<List<CustomerDto>> GetAll();
        Task<List<ChartResultDto>> GetChartResult();
    }
}
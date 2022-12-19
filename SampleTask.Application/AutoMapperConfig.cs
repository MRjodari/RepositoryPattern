using AutoMapper;
using SampleTask.Application.CQRS.Commands;
using SampleTask.Application.CQRS.Queries;
using SampleTask.Application.DTO;
using SampleTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Application
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            //CreateMap<Customer, GetCustomerDto>()
            //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            //    .ReverseMap();
            CreateMap<Customer, GetCustomerDto>()
                .ReverseMap();

            //CreateMap<SaveCustomerCommand, GetCustomerDto>().ReverseMap();
            CreateMap<RegisterCustomerDto, SaveCustomerCommand>()
                .ForMember(dest => dest.UserName , opt => opt.MapFrom(src => src.Name))
                .ReverseMap();

            CreateMap<Customer, SaveCustomerCommand>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
            CreateMap<Customer, GetCustomerQueryResponse>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();


        }
    }
}

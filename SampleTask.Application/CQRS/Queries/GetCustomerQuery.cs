using AutoMapper;
using MediatR;
using SampleTask.Application.Interfaces.Repos;
using SampleTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Application.CQRS.Queries
{
    public class GetCustomerQuery:IRequest<GetCustomerQueryResponse>
    {
        public long Id { get; set; }

    }
    public class GetCustomerQueryResponse
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }

    }
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Customer> _genericRepository;
        private readonly IMapper _mapper;
        public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IGenericRepository<Customer> genericRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        
        public async Task<GetCustomerQueryResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            var customer = await _genericRepository.GetById(request.Id);
            var response = _mapper.Map<GetCustomerQueryResponse>(customer);
            await _unitOfWork.Save();
            return response;
        }
    }
}

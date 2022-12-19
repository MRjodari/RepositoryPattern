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
    public class GetCustomerListQuery : IRequest<IEnumerable<Customer>>
    {


        public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, IEnumerable<Customer>>
        {

            private readonly IUnitOfWork _unitOfWork;
            private readonly IGenericRepository<Customer> _genericRepository;
            private readonly IMapper _mapper;
            public GetCustomerListQueryHandler(IUnitOfWork unitOfWork, IGenericRepository<Customer> genericRepository, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _genericRepository = genericRepository;
                _mapper = mapper;
            }
            public async Task<IEnumerable<Customer>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
            {
                var customer = await _genericRepository.GetAll();
                var response = _mapper.Map<List<Customer>>(customer.ToList());
                await _unitOfWork.Save();
                return response;
            }

        }



    }
}

using AutoMapper;
using MediatR;
using SampleTask.Application.DTO;
using SampleTask.Application.Interfaces.Repos;
using SampleTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTask.Application.CQRS.Commands
{
    public class SaveCustomerCommand : IRequest<SaveCustomerCommandResponse>
    {
        public string UserName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    public class SaveCustomerCommandResponse
    {
        public long CustomerId { get; set; }
    }
    public class SaveCustomerCommandHandler : IRequestHandler<SaveCustomerCommand, SaveCustomerCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<ICustomerRepository> _genericRepository;
        private readonly IMapper _mapper;

        public SaveCustomerCommandHandler(IUnitOfWork unitOfWork, IGenericRepository<ICustomerRepository> genericRepository, IMapper  mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<SaveCustomerCommandResponse> Handle(SaveCustomerCommand request, CancellationToken cancellationToken)
        {
            //var customer = new Customer
            //{
            //    Name=request.UserName,
            //    Email=request.Email
            //};
            //RegisterCustomerDto registerCustomerDto = new RegisterCustomerDto();
            var customer = _mapper.Map<Customer>(request);


            //await _genericRepository.Add(user);
            await _unitOfWork.CustomerRepository.Add(customer);
            await _unitOfWork.Save();

            var response = new SaveCustomerCommandResponse
            {
                CustomerId = customer.Id
            };

            return response;
        }
    }
}

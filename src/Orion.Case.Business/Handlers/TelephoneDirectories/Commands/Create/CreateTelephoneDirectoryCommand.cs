using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Orion.Case.Core.UnitOfWork;
using Orion.Case.DataAccess.Abstract;
using Orion.Case.Entities.Concrete;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Create
{
    public class CreateTelephoneDirectoryCommand : IRequest<CreateTelephoneDirectoryResponse>
    {
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }

        public class CreateTelephoneNumberCommandHandler : IRequestHandler<CreateTelephoneDirectoryCommand, CreateTelephoneDirectoryResponse>
        {
            private readonly ITelephoneDirectoryRepository _telephoneDirectoryRepository;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            private readonly CreateTelephoneDirectoryValidator _validation;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public CreateTelephoneNumberCommandHandler(ITelephoneDirectoryRepository telephoneDirectoryRepository, IMapper mapper, IUnitOfWork unitOfWork, CreateTelephoneDirectoryValidator validation, IHttpContextAccessor httpContextAccessor)
            {
                _telephoneDirectoryRepository = telephoneDirectoryRepository;
                _mapper = mapper;
                _unitOfWork = unitOfWork;
                _validation = validation;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<CreateTelephoneDirectoryResponse> Handle(CreateTelephoneDirectoryCommand request, CancellationToken cancellationToken)
            {

                _validation.ValidateAndThrow(request);

                var checkPhoneNumber = await _telephoneDirectoryRepository.GetAsync(x => x.PhoneNumber == request.PhoneNumber && x.IsDeleted == false);

                if (checkPhoneNumber != null)
                {
                    throw new Exception("The phone number is registered in the phone book.");
                }

                var userId = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.EndsWith("nameidentifier"))?.Value;

                TelephoneDirectory telephoneDirectory = new()
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    CreatedUserId = userId

                };

                await _telephoneDirectoryRepository.AddAsync(telephoneDirectory);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                CreateTelephoneDirectoryResponse response = _mapper.Map<CreateTelephoneDirectoryResponse>(telephoneDirectory);
                return response;
            }
        }
    }
}

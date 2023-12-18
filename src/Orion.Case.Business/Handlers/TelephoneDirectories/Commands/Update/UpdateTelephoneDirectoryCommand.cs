using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Orion.Case.Core.UnitOfWork;
using Orion.Case.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Update
{
    public class UpdateTelephoneDirectoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }

        public class UpdateTelephoneDirectoryCommandHandler : IRequestHandler<UpdateTelephoneDirectoryCommand, Unit>
        {
            private readonly ITelephoneDirectoryRepository _telephoneDirectoryRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly UpdateTelephoneDirectoryValidator _validation;

            public UpdateTelephoneDirectoryCommandHandler(ITelephoneDirectoryRepository telephoneDirectoryRepository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UpdateTelephoneDirectoryValidator validation)
            {
                _telephoneDirectoryRepository = telephoneDirectoryRepository;
                _unitOfWork = unitOfWork;
                _httpContextAccessor = httpContextAccessor;
                _validation = validation;
            }

            public async Task<Unit> Handle(UpdateTelephoneDirectoryCommand request, CancellationToken cancellationToken)
            {
                _validation.ValidateAndThrow(request);

                var checkTelephoneDirectory = await _telephoneDirectoryRepository.GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

                if (checkTelephoneDirectory == null)
                {
                    throw new Exception("Data not found.");
                }

                var checkTelephone = await _telephoneDirectoryRepository.GetAsync(x => x.Id != request.Id && x.PhoneNumber == request.PhoneNumber && x.IsDeleted == false);

                if (checkTelephone != null)
                {
                    throw new Exception("The phone number is registered in the phone book.");
                }

                var userId = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.EndsWith("nameidentifier"))?.Value;

                checkTelephoneDirectory.UpdatedUserId = userId;
                checkTelephoneDirectory.Name = request.Name;
                checkTelephoneDirectory.LastName = request.LastName;
                checkTelephoneDirectory.PhoneNumber = request.PhoneNumber;
                checkTelephoneDirectory.UpdatedUserId = userId;

                await _telephoneDirectoryRepository.UpdateAsync(checkTelephoneDirectory);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}

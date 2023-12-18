using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Create;
using Orion.Case.Core.UnitOfWork;
using Orion.Case.DataAccess.Abstract;
using Orion.Case.Entities.Concrete;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Commands.Delete
{
    public class DeleteTelephoneDirectoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public class DeleteTelephoneDirectoryCommandHandler : IRequestHandler<DeleteTelephoneDirectoryCommand, Unit>
        {
            private readonly ITelephoneDirectoryRepository _telephoneDirectoryRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public DeleteTelephoneDirectoryCommandHandler(ITelephoneDirectoryRepository telephoneDirectoryRepository, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
            {
                _telephoneDirectoryRepository = telephoneDirectoryRepository;
                _unitOfWork = unitOfWork;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<Unit> Handle(DeleteTelephoneDirectoryCommand request, CancellationToken cancellationToken)
            {

                var checkTelephoneDirectory = await _telephoneDirectoryRepository.GetAsync(x => x.Id == request.Id && x.IsDeleted == false);

                if (checkTelephoneDirectory == null)
                {
                    throw new Exception("Data not found.");
                }

                var userId = _httpContextAccessor.HttpContext?.User?.Claims.FirstOrDefault(x => x.Type.EndsWith("nameidentifier"))?.Value;

                checkTelephoneDirectory.IsDeleted = true;
                checkTelephoneDirectory.UpdatedUserId = userId;

                await _telephoneDirectoryRepository.UpdateAsync(checkTelephoneDirectory);
                await _unitOfWork.SaveChangesAsync(cancellationToken);


                return Unit.Value;
            }
        }
    }
}

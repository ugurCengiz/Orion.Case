using AutoMapper;
using MediatR;
using Orion.Case.Business.Handlers.TelephoneDirectories.Queries.GetList;
using Orion.Case.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Queries.GetById
{
    public class GetByIdTelephoneDirectoryQuery : IRequest<GetByIdTelephoneDirectoryItemDto>
    {
        public int Id { get; set; }
        public class GetByIdTelephoneDirectoryQueryHandler : IRequestHandler<GetByIdTelephoneDirectoryQuery, GetByIdTelephoneDirectoryItemDto>
        {
            private readonly ITelephoneDirectoryRepository _telephoneDirectoryRepository;
            private readonly IMapper _mapper;

            public GetByIdTelephoneDirectoryQueryHandler(ITelephoneDirectoryRepository telephoneDirectoryRepository, IMapper mapper)
            {
                _telephoneDirectoryRepository = telephoneDirectoryRepository;
                _mapper = mapper;
            }

            public async Task<GetByIdTelephoneDirectoryItemDto> Handle(GetByIdTelephoneDirectoryQuery request, CancellationToken cancellationToken)
            {
                var telephoneDirectory = await _telephoneDirectoryRepository.GetByIdAsync(request.Id);

                var response = _mapper.Map<GetByIdTelephoneDirectoryItemDto>(telephoneDirectory);

                return response;

            }
        }
    }
}

using AutoMapper;
using MediatR;
using Orion.Case.DataAccess.Abstract;

namespace Orion.Case.Business.Handlers.TelephoneDirectories.Queries.GetList
{
    public class GetListTelephoneDirectoryQuery : IRequest<IEnumerable<GetListTelephoneDirectoryListItemDto>>
    {

        public class GetListTelephoneDirectoryQueryHandler : IRequestHandler<GetListTelephoneDirectoryQuery, IEnumerable<GetListTelephoneDirectoryListItemDto>>
        {
            private readonly ITelephoneDirectoryRepository _telephoneDirectoryRepository;
            private readonly IMapper _mapper;

            public GetListTelephoneDirectoryQueryHandler(ITelephoneDirectoryRepository telephoneDirectoryRepository, IMapper mapper)
            {
                _telephoneDirectoryRepository = telephoneDirectoryRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<GetListTelephoneDirectoryListItemDto>> Handle(GetListTelephoneDirectoryQuery request, CancellationToken cancellationToken)
            {
                var list = await _telephoneDirectoryRepository.GetAllAsync(x => x.IsDeleted == false);

                var response = _mapper.Map<IEnumerable<GetListTelephoneDirectoryListItemDto>>(list);

                return response;

            }
        }
    }
}

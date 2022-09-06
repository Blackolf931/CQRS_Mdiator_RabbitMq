using AutoMapper;
using BLL.Models;
using BLL.Queries;
using BLL.Requests.Offices;
using DAL.Entities;
using DAL.Interfaces;
using MediatR;

namespace BLL.Handlers.OfficeHandlers
{
    public class OfficeHandlers : IRequestHandler<AddOfficeCommand, Office>,
        IRequestHandler<GetByIdQuery, Office>,
         IRequestHandler<GetAllOfficeQuery, IEnumerable<Office>>,
        IRequestHandler<UpdateOfficeCommand, Office>,
        IRequestHandler<DeleteOfficeCommand>
    {
        private readonly IGenericRepository<OfficeEntity> _genericRepository;
        private readonly IMapper _mapper;

        public OfficeHandlers(IGenericRepository<OfficeEntity> genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }

        public async Task<Office> Handle(AddOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = await _genericRepository.AddAsync(_mapper.Map<OfficeEntity>(request.Office), cancellationToken);
            return _mapper.Map<Office>(office);
        }
        public async Task<IEnumerable<Office>> Handle(GetAllOfficeQuery request, CancellationToken cancellationToken)
        {
            var officeEntity = await _genericRepository.GetAllAsync(cancellationToken);

            return _mapper.Map<IEnumerable<Office>>(officeEntity);
        }
        public async Task<Office> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            var office = await _genericRepository.GetByIdAsync(request.Id, cancellationToken);
            return _mapper.Map<Office>(office);
        }

        public async Task<Office> Handle(UpdateOfficeCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Update(_mapper.Map<OfficeEntity>(request.Office), cancellationToken);
            return request.Office;
        }

        public async Task<Unit> Handle(DeleteOfficeCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.DeleteByIdAsync(_mapper.Map<OfficeEntity>(request.Office), cancellationToken);
            return Unit.Value;
        }
    }
}

using AutoMapper;
using Bll.RabbitMq;
using BLL.Models;
using BLL.Notification;
using BLL.Queries;
using BLL.Requests.Offices;
using CQRS_Mediator.ViewModels.Office;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Mediator.Controllers
{
    [Route("api/office")]
    [ApiController]
    public class OfficeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IRabbitMqService _mqService;
        public OfficeController(IMediator mediator, IMapper mapper, IRabbitMqService mqService)
        {
            _mapper = mapper;
            _mediator = mediator;
            _mqService = mqService;
        }

        [HttpGet]
        public async Task<IEnumerable<OfficeViewModel>> GetAll()
        {
            _mqService.SendMessage("Hello world");
            var office = await _mediator.Send(new GetAllOfficeQuery());
            _mqService.SendMessage(office);
            return _mapper.Map<IEnumerable<OfficeViewModel>>(office);
        }

        [HttpGet("{id}")]
        public async Task<OfficeViewModel> GetById(int id, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetByIdQuery(id));
            return _mapper.Map<OfficeViewModel>(result);
        }

        [HttpPost]
        public async Task<OfficeViewModel> Add([FromBody] OfficeViewModel officeViewModel, CancellationToken ct)
        {
            var result = await _mediator.Send(new AddOfficeCommand(_mapper.Map<Office>(officeViewModel)));
            var offices = await _mediator.Send(new GetAllOfficeQuery());
            var office = offices.FirstOrDefault(x => x.Id == result.Id);
            await _mediator.Publish(new OfficeAddedNotification(offices, office));
            //return CreatedAtRoute("GetProductById", new { id = productToReturn.Id }, productToReturn);
            return _mapper.Map<OfficeViewModel>(office);
        }

        [HttpPut]
        public async Task<OfficeViewModel> Update([FromBody] OfficeViewModel updateViewModel, CancellationToken ct)
        {
            var result = await _mediator.Send(new UpdateOfficeCommand(_mapper.Map<Office>(updateViewModel)));
            return _mapper.Map<OfficeViewModel>(result);
        }

        [HttpDelete("{officeId}")]
        public async Task<IActionResult> Delete(int officeId, CancellationToken ct)
        {
            var result = await _mediator.Send(new GetByIdQuery(officeId));
            await _mediator.Send(new DeleteOfficeCommand(result));
            return Ok();
        }
    }
}

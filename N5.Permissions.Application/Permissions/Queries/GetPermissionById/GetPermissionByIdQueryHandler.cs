using ErrorOr;
using MediatR;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Application.Permissions.Persistence;
using N5.Permissions.Shared.Kafka;

namespace N5.Permissions.Application.Permissions.Commands.Queries.GetPermissionById
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class GetPermissionByIdQueryHandler : IRequestHandler<GetPermissionByIdQuery, ErrorOr<Permission>>
    {
        private readonly IUnitOfWork _unitOfWork;        
        private readonly IKafkaMessageBus<string, Operation> _bus;

        public GetPermissionByIdQueryHandler(IUnitOfWork unitOfWork, IKafkaMessageBus<string, Operation> bus)
        {
            _bus = bus;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<Permission>> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            var operation = new Operation
            {
                Id = Guid.NewGuid(),
                NameOperation = "request"

            };

            var elasticsearch = new Elasticsearch();
            var document = new { Id = 1, NameEmployee = "Johans", SurnameEmployee = "Cuellar", PermissionDate = DateTime.Now, PermissionTypeId = 1 };
            await elasticsearch.AddOrUpdate(document, "elastic-permissions");

            await _bus.PublishAsync(operation.NameOperation, operation);

            return await _unitOfWork.PermissionRepository.GetPermissionById(request.Id);
        }
    }
}

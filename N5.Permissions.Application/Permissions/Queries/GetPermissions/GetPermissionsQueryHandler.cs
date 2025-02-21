using ErrorOr;
using MediatR;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Application.Permissions.Persistence;
using N5.Permissions.Shared.Kafka;

namespace N5.Permissions.Application.Permissions.Commands.Queries.GetPermissions
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class GetPermissionsQueryHandler : IRequestHandler<GetPermissionsQuery, ErrorOr<List<Permission>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKafkaMessageBus<string, Operation> _bus;

        public GetPermissionsQueryHandler(IUnitOfWork unitOfWork, IKafkaMessageBus<string, Operation> bus)
        {
            _bus = bus;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<List<Permission>>> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
        {

            var operation = new Operation
            {
                Id = Guid.NewGuid(),
                NameOperation = "get"

            };

            await _bus.PublishAsync(operation.NameOperation, operation);

            var elasticsearch = new Elasticsearch();
            var document = new { Id = 1, NameEmployee = "Johans", SurnameEmployee = "Cuellar", PermissionDate = DateTime.Now, PermissionTypeId = 1 };
            await elasticsearch.AddOrUpdate(document, "elastic-permissions");            

            return await _unitOfWork.PermissionRepository.GetPermissions();
        }
    }
}

using ErrorOr;
using MediatR;
using N5.Permissions.Application.Permissions.Persistence;
using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Application.PermissionTypes.Queries.GetPermissionTypes
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class GetPermissionTypesQueryHandler : IRequestHandler<GetPermissionTypesQuery, ErrorOr<List<PermissionType>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPermissionTypesQueryHandler(IUnitOfWork unitOfWork)
        {            
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<List<PermissionType>>> Handle(GetPermissionTypesQuery request, CancellationToken cancellationToken)
        {

            return await _unitOfWork.PermissionTypeRepository.GetPermissionTypes();
        }
       
    }
}

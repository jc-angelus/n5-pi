using AutoMapper;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Presentation.DTO;

namespace N5.Permissions.Presentation.Profiles
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionTypesMappingProfile : Profile
    {
        public PermissionTypesMappingProfile()
        {            

            CreateMap<PermissionType, PermissionTypesResponseDto>();
            
        }
    }
}

using AutoMapper;
using N5.Permissions.Domain.Entities;
using N5.Permissions.Presentation.DTO;

namespace N5.Permissions.Presentation.Profiles
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionMappingProfile : Profile
    {
        public PermissionMappingProfile()
        {            

            CreateMap<PermissionRequestDto, Permission>();

            CreateMap<Permission, PermissionResponseDto>()
                .ForMember(dest => dest.PermissionType, opt => opt.MapFrom(src => new PermissionType { Id = src.PermissionType.Id, Description = src.PermissionType.Description }))
                .ForMember(dest => dest.PermissionDate, opt => opt.MapFrom(src => src.PermissionDate.ToString("yyyy-MM-dd"))); 
        }
    }
}

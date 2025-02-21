using N5.Permissions.Domain.Entities;

namespace N5.Permissions.Presentation.DTO
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionResponseDto
    {       
        public int Id { get; set; }               
        public string NameEmployee { get; set; } = null!;                
        public string SurnameEmployee { get; set; } = null!;        
        public DateTime PermissionDate { get; set; }        
        public PermissionType PermissionType { get; set; } = null!;

    }
}

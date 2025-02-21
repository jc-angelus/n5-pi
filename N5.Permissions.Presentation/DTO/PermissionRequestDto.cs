using System.Text.Json.Serialization;

namespace N5.Permissions.Presentation.DTO
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class PermissionRequestDto
    {
        [JsonRequired] 
        public int Id { get; set; }
        
        [JsonRequired]
        public string NameEmployee { get; set; } = null!;
        
        [JsonRequired]
        public string SurnameEmployee { get; set; } = null!;
        
        [JsonRequired]
        public DateTime PermissionDate { get; set; }

        [JsonRequired]
        public int PermissionTypeId { get; set; }        

    }
}

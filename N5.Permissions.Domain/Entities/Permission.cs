namespace N5.Permissions.Domain.Entities
{
    /// <summary>
    /// Developer: Johans Cuellar
    /// Date: 02/19/2025
    /// </summary>
    public class Permission
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; } = null!;        
        public string SurnameEmployee { get; set; } = null!;
        public DateTime PermissionDate { get; set; }
        public int PermissionTypeId { get; set; }        
        public virtual PermissionType PermissionType { get; set; } = null!;
    }
}

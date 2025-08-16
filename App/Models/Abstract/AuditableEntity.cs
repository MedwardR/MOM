namespace MOM.Models.Abstract
{
	public abstract class AuditableEntity
	{
		public DateTime CreatedAt { get; set; }
		public int CreatedBy { get; set; }
		public DateTime ModifiedAt { get; set; }
		public int ModifiedBy { get; set; }
	}
}

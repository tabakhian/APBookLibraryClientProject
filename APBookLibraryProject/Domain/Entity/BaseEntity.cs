namespace APBookLibraryProject.Domain.Entities
{
	public class BaseEntity : System.Object
	{
		public BaseEntity()
		{
			Id = System.Guid.NewGuid();
			Code = System.Guid.NewGuid();
			RegisterDate = System.DateTime.UtcNow;
			IsDeleted = false;
			TemporaryHide = false;
			SortNumber = 0;
			IsEnabled = true;
		}


		public System.Guid Id { get; set; }
		public System.Guid Code { get; set; }
		public System.DateTime RegisterDate { get; set; }
		public bool IsDeleted { get; set; }
		public System.DateTime? DeleteDate { get; set; }
		public System.Guid? DeleterUserId { get; set; }
		public bool TemporaryHide { get; set; }
		public bool IsEnabled { get; set; }
		public int SortNumber { get; set; }
	}
}


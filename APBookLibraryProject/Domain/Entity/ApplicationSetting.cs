namespace APBookLibraryProject.Domain.Entities
{
	public class ApplicationSetting
	{

		public ApplicationSetting()
		{
			RegisterDate = System.DateTime.UtcNow;
			Id = System.Guid.NewGuid();

		}
		public System.Guid Id { get; set; }
		public System.DateTime RegisterDate { get; set; }
		public string LibraryName { get; set; }
		public bool LibraryRegisterdInWS { get; set; }
		public string LibraryAuthCode { get; set; }
	}
}
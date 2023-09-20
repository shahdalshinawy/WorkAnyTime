namespace WebApiProject.DTO
{
	public class JowWithClientDto
	{
		public int OwnerOfAccountIdThatPostedThisJob { get; set; }
		public string jobName { get; set; }
		public double jobPrice { get; set; }
		public string jobDescription { get; set; }
		public int proposalNumber { get; set; }
	    public Boolean isSaved { get; set; }
		public DateTime TimeTheJobWasPostedIn { get; set; }
		public int? totalPriceThatClientPayed { get; set; } // How to Get It ??
		 public string NameOfClient { get; set; }
		public int connectsNeedForThisJob { get; set; }
		public Boolean isHourly { get; set; }
	}
}

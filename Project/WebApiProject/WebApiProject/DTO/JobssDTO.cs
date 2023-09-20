namespace WebApiProject.DTO
{
    public class JobssDTO
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public double Budget { get; set; }
        public string Field { get; set; }
        public string JopBody { get; set; }
        public string ProfileId { get; set; }
        public string Description { get; set; }
        public int connects { get; set; }
        public Boolean IsSaved { get; set; }
        public Boolean IsHourly { get; set; }

        //public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public int LocationId { get; set; }

        public List<ProposalDTO>? Proposals { get; set; }
        public List<ReviewDTO>? Reviews { get; set; }
        public List<ContractDTO>? Contracts { get; set; }
    }

    public class IProposalPost
    {
        public string userID { get; set; }

    }

    public class ProposalDTO
    {
        public string UserId { get; set; }
        public int JobId { get; set; }
        public string CoverLetter { get; set; }
        public double ProposedPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ProposalPostDTO
    {
        public string CoverLetter { get; set; }
        public double ProposedPrice { get; set; }
        public string UserId { get; set; }
        public int JobId { get; set; }

    }

    public class ReviewDTO
    {
        public int UserId { get; set; }
        public int JobId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
    }

    public class ContractDTO
    {
        public int ClientId { get; set; }
        public int FreelancerId { get; set; }
        public int JobId { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}

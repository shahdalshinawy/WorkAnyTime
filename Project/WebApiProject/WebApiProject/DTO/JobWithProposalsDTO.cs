﻿using WebApiProject.Models;

namespace WebApiProject.DTO
{
    public class JobWithProposalsDTO
    {
        public int Id { get; set; }
        public List<ProposalsDTO> proposals { get; set; } = new List<ProposalsDTO>();
        
    }

        public class ProposalsDTO
        {
            public int Id { get; set; }
            public int JobId { get; set; }
            public string CoverLetter { get; set; }
            public double ProposedPrice { get; set; }
            public DateTime CreatedAt { get; set; }
            public string freelancerID { get; set; }
            public string FreelancerName { get;set; }
            public string FreelancerEmail{ get; set; }
            public string FreelancerImage { get; set; }
            public List<string> skills { get; set; }=new List<string>();
    }
   
}

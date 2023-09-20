using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public double Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("ContractId")]
        public virtual Contract Contract { get; set; }
    }
}
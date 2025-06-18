using System.ComponentModel.DataAnnotations.Schema;

namespace IzmirTeknoloji.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; } 
        public ICollection<TransactionHistory> TransactionHistories { get; set; }
    }
}

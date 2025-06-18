using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzmirTeknoloji.Application.Dtos.TransactionHistory
{
    public class TransactionHistoryDto
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string InputNumbers { get; set; }
        public int Result { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzmirTeknoloji.Domain.Entities
{
    public class TransactionHistory
    {
        public int Id { get; set; } 

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public string InputNumbers { get; set; }
        public int Result { get; set; }
        public DateTime Date { get; set; }
    }

}

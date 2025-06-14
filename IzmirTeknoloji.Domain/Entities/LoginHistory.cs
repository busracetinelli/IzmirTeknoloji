using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzmirTeknoloji.Domain.Entities
{
    public class LoginHistory
    {
        public int Id { get; set; }
        public string InputNumbers { get; set; } = default!; // kullanıcıların girdiği sayılar
        public string Result { get; set; } = default!;
        public int UserId { get; set; }
        public DateTime Date { get; set; }

        public User User { get; set; } = default!;
    }
}

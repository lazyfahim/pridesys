using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMan.API.DTOS
{
    public class ShowUserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}

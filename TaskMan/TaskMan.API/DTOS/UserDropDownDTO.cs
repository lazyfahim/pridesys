using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMan.API.DTOS
{
    public class UserDropDownDTO
    {
        public IList<DropUserDTO> Users { get; set; }
    }
}

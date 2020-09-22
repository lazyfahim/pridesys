using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskMan.API.DTOS.Tasks
{
    public class TaskCreateDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AssignedToId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}

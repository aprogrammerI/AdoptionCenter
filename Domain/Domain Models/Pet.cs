using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain_Models
{
    public class Pet:BaseEntity
    {
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public int? Age { get; set; }
        public string? Description  { get; set; }
        public bool? IsVacinated { get; set; }
        

    }
}

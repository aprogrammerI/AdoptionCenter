using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain_Models
{
    public class Shelter:BaseEntity
    {

        public Guid ShelterId { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public int? Capacity { get; set; }

        
        public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();

    }
}
